using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Helicopter.DAL.Entities;

namespace Helicopter.DAL.Configurations
{
    class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        { 
            //builder.Property<byte[]?>("Timestamp");
            builder.Property<bool>("IsDeleted").HasDefaultValue(false);
            builder.HasQueryFilter(m => !EF.Property<bool>(m, "IsDeleted"));
        }
    }
}
