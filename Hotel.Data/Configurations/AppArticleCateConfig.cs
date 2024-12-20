using Hotel.Data.Entities;
using Hotel.Share.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Configurations
{
	public class appArticleCateConfig : IEntityTypeConfiguration<AppArticleCate>
	{
		public void Configure(EntityTypeBuilder<AppArticleCate> builder)
		{
			builder.HasKey(x => x.Id);
            // ten danh muc
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        }
    }
}
