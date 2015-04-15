using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using System;
using WorkMarketingNet.Web.Data;

namespace WorkMarketingNet.Web.Migrations
{
    [ContextType(typeof(WorkMarketingNet.Web.Data.DataContext))]
    public partial class initial : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201504151138592_initial";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta3-12166";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("WorkMarketingNet.Web.Models.Company", b =>
                    {
                        b.Property<string>("Code");
                        b.Property<Guid>("Id")
                            .GenerateValueOnAdd();
                        b.Property<int?>("LogoId");
                        b.Property<string>("Name");
                        b.Key("Id");
                    });
                
                builder.Entity("WorkMarketingNet.Web.Models.Image", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Url");
                        b.Key("Id");
                    });
                
                builder.Entity("WorkMarketingNet.Web.Models.Company", b =>
                    {
                        b.ForeignKey("WorkMarketingNet.Web.Models.Image", "LogoId");
                    });
                
                return builder.Model;
            }
        }
    }
}