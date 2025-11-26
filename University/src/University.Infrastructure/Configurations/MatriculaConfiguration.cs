using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace University.Infra.Configurations
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matriculas");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Data)
                .IsRequired();

            builder.Property(m => m.StudentId)
                .IsRequired();

            builder.HasOne(m => m.Student)
                   .WithMany(s => s.Matriculas)
                   .HasForeignKey(m => m.StudentId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
