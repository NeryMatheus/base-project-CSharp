﻿using FluentMigrator;

namespace base_project_CSharp.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_USER, "Create table to save user`s information")]
    public class Version0000001 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Users")                
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Password").AsString(2000).NotNullable();
        }
    }
}
