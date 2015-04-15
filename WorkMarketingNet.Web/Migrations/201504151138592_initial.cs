using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace WorkMarketingNet.Web.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Company",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        LogoId = c.Int()
                    })
                .PrimaryKey("PK_Company", t => t.Id);
            
            migrationBuilder.CreateTable("Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String()
                    })
                .PrimaryKey("PK_Image", t => t.Id);
            
            migrationBuilder.AddForeignKey(
                "Company",
                "FK_Company_Image_LogoId",
                new[] { "LogoId" },
                "Image",
                new[] { "Id" },
                cascadeDelete: false);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("Company", "FK_Company_Image_LogoId");
            
            migrationBuilder.DropTable("Company");
            
            migrationBuilder.DropTable("Image");
        }
    }
}