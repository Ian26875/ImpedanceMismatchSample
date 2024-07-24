namespace ImpedanceMismatchSample1.Data;

public class Teams
{
    public int Id { get; set; }

    public string Name { get; set; }
    
}

public class TeamMembers
{
    public string Name { get; set; }
    
    public int TeamId { get; set; }
    
    public int Id { get; set; }
}