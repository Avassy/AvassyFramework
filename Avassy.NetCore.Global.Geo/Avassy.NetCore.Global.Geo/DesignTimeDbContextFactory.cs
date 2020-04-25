using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Avassy.NetCore.Global.Geo.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Avassy.NetCore.Global.Geo
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GeoDbContext>
    {
        public GeoDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<GeoDbContext>();

            var connectionString = configuration.GetConnectionString("Geo");

            builder.UseSqlServer(connectionString);

            return new GeoDbContext(builder.Options);
        }
    }
}
