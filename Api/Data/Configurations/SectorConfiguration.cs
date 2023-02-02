using CVGeneratorApp.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGeneratorApp.Api.Data.Configurations
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        }
    }
}
