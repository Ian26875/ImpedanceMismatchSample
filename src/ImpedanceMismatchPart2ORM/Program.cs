// See https://aka.ms/new-console-template for more information

using ImpedanceMismatchPart2ORM;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<SampleDbContext>()
    .UseSqlServer("Your Connection String")
    .Options;


// -- Part 1
using (var db = new SampleDbContext(options))
{
    // Create A Table 
    var team = new Team
    {
        Name = "CRM Team"
    };
    db.Teams.Add(team);
    db.SaveChanges();

    // Create B Table 

    var teamMembers = new List<TeamMember>
    {
        new()
        {
            TeamId = team.Id, 
            Name = "Alex"
        },
        new()
        {
            TeamId = team.Id, 
            Name = "Jeff"
        }
    };
    db.TeamMembers.AddRange(teamMembers);
    db.SaveChanges();
}

Console.WriteLine("Create CRM Team Success");

// -- Part 2
using (var db = new SampleDbContext(options))
{
    var team = new Team
    {
        Name = "Sale Team",
        TeamMembers =
        [
            new TeamMember {Name = "Alex"},
            new TeamMember {Name = "Jeff"}
        ]
    };

    db.Teams.Add(team);
    db.SaveChanges();
}

Console.WriteLine("Create Sale Team Success");