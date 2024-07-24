using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImpedanceMismatchPart2ORM;

public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
{
    public void Configure(EntityTypeBuilder<TeamMember> builder)
    {
        builder.ToTable("TeamMember");

        builder.HasKey(tm => tm.Id);

        builder.Property(tm => tm.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(tm => tm.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(tm => tm.TeamId)
            .HasColumnName("TeamID");
    }
}