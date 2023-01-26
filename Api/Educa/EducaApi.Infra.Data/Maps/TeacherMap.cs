﻿using EducaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducaApi.Infra.Data.Maps
{
    public class TeacherMap : IEntityTypeConfiguration<Teacher>
    {

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasMany(t => t.Students)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId);

        } 
    }
}
