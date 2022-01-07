using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Helicopter.DAL.Entities;

namespace Helicopter.DAL.Configurations
{
    class GameConfiguration : BaseEntityConfiguration<Game>
    {
        public override void Configure(EntityTypeBuilder<Game> builder)
        {
            base.Configure(builder);

            builder
                .Property(m=>m.CreatedAt)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("getdate()");

            builder
                .Property(m => m.GameName)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(m => m.Year)
                .IsRequired()
                .HasColumnType("Text");

            builder
                .Property(m => m.DisplayName)
                .HasComputedColumnSql("[GameName] + ' - ' + convert(nvarchar, Year, 101)");

            builder
                .Property("Timestamp")
                .IsRowVersion();

            builder
                .HasOne(m => m.GameCategoryNavigation)
                .WithMany(m=>m.Game)
                .HasForeignKey(m => m.GameCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("Game");
        }
    }
}
