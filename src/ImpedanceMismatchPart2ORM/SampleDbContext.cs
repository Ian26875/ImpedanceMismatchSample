using Microsoft.EntityFrameworkCore;

namespace ImpedanceMismatchPart2ORM;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new TeamMemberConfiguration());
    }

    public DbSet<Team> Teams { get; set; }
    
    public DbSet<TeamMember> TeamMembers { get; set; }
}

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TeamMember> TeamMembers { get; set; }
}

public class TeamMember
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TeamId { get; set; }
}