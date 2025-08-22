using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ofernandoavila.Academy.Business.Models.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofernandoavila.Academy.Data.Mappings.AccessControl;

public class SessionMapping : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Ignore(r => r.ValidationResult);
        //builder.Ignore(r => r.UserId);

        //builder.Property(r => r.Description)
        //        .IsRequired()
        //        .HasColumnType("varchar(50)");

        //builder.Property(r => r.Active)
        //        .IsRequired()
        //        .HasColumnType("int");

        //builder.HasIndex(r => r.Description)
        //        .HasDatabaseName("IX_DESCRIPTION_TB_ROLE")
        //        .IsUnique();

        builder.ToTable("Sessions");
    }
}