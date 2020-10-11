﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.DataAccess.Concrete.EFCore.Mappings
{
    public class EfCityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(@"Cities", @"dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CountryId).HasColumnName("CountryId");
            builder.Property(x => x.Name).HasColumnName("Name");
        }
    }
}