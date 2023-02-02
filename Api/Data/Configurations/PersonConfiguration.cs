using CVGeneratorApp.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGeneratorApp.Api.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x=>x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(255);
            builder.Property(x=>x.CVFilePath).HasMaxLength(500).IsRequired();
            builder.Property(x => x.CVFileName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
        }
    }
}
