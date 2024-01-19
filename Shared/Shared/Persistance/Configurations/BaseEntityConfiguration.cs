using BusinessApp.Shared.Domain.Models.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Shared.Persistance.Configurations;

public class BaseEntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TId>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.CreatedDate).IsRequired();
        builder.Property(t => t.UpdatedDate);
        builder.Property(t => t.DeletedDate);
    }
}
