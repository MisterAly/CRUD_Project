using CRUD_project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_project.Infra.Context.Types
{
    public class DesenvolvedoresTypeConfiguration : IEntityTypeConfiguration<Desenvolvedores>
    { 
        public void Configure(EntityTypeBuilder<Desenvolvedores> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id).HasDefaultValueSql("newid()");
            builder.Property(q => q.Nome).IsRequired().HasMaxLength(500);
            builder.Property(q => q.Idade).IsRequired();
            builder.Property(q => q.Hobby).IsRequired().HasMaxLength(1000);
            builder.Property(q => q.Sexo).IsRequired().HasMaxLength(30);
            builder.Property(q => q.Datanascimento).IsRequired();

        }
    }
}
