﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skunkworks.Domain.Entities;
using SomeService.Api.Data;

namespace SomeService.Api.Users;


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
        builder.Property(u => u.IsTeacher);
    }
}