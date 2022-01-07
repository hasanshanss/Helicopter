using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Helicopter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helicopter.DAL.Configurations
{
    class GameCategoryConfiguration : BaseEntityConfiguration<GameCategory>
    {
        public override void Configure(EntityTypeBuilder<GameCategory> builder)
        {
            base.Configure(builder);

            builder
                .Property(m => m.CategoryName)
                .IsRequired()
                .HasMaxLength(50);

            builder.ToTable("GameCategories");
        }
    }
}
