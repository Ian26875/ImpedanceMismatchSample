
using Dapper;
using Microsoft.Data.SqlClient;

var connectionString = "Server=localhost,1433;Database=master;User Id=sa;Password=1qaz@WSX;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True;";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();
    using (var transaction = connection.BeginTransaction())
    {
        try
        {
            var team = new Team
            {
                Name = "Development Team",
                TeamMembers = new List<TeamMember>
                {
                    new() { Name = "Alice" },
                    new() { Name = "Bob" }
                }
            };

            var teamInsertQuery = "INSERT INTO Team (Name) OUTPUT INSERTED.Id VALUES (@Name);";
            int teamId = connection.QuerySingle<int>(teamInsertQuery, team, transaction: transaction);

            foreach (var teamMember in team.TeamMembers)
            {
                var teamMemberInsertQuery = "INSERT INTO TeamMember (Name, TeamId) VALUES (@Name, @TeamId);";
                connection.Execute(teamMemberInsertQuery, new { teamMember.Name, TeamId = teamId }, transaction: transaction);
            }
            transaction.Commit();

        }
        catch
        {
            transaction.Rollback();
        }
    }
    connection.Close();
}


Console.WriteLine("Successful !");

public class Team
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<TeamMember> TeamMembers { get; set; }

}

public class TeamMember
{
    public string Name { get; set; }
    
    public int TeamId { get; set; }
    
    public int Id { get; set; }
}