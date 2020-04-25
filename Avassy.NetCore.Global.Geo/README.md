# Avassy.NetCore.Global.Geo

See [http://www.avassy.com/framework/components/Avassy.NetCore.Global.Geo](http://www.avassy.com/framework/components/Avassy.NetCore.Global.Geo) for more info.

## Classes

- `Avassy.NetCore.Global.Geo.Data.Contexts.GeoDbContext`
- `Avassy.NetCore.Global.Geo.Data.Entities.Base`
- `Avassy.NetCore.Global.Geo.Data.Entities.Country`
- `Avassy.NetCore.Global.Geo.Data.Entities.State`
- `Avassy.NetCore.Global.Geo.Data.Migrations.InitialCreate`
- `Avassy.NetCore.Global.Geo.Data.Migrations.GeoDbContextModelSnapshot`
- `Avassy.NetCore.Global.Geo.Models.Base`
- `Avassy.NetCore.Global.Geo.Models.Country`
- `Avassy.NetCore.Global.Geo.Models.State`

## Usage

First addd your connectionstring pointing to your database:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "ConnectionStrings": {   
    "Geo": "Server=;Database=;Initial Catalog=;User ID=sa;Password=;Persist Security Info=True;Connection Timeout=5;"
  }
}
```

Then add the 'Avassy.NetCore.Global.Geo.Data.Contexts.GeoDbContext' to your Asp.Net Core project or .Net Core project.

Asp.Net Core (2.1):

```

// Startup.cs (in method ConfigureServices)

// ...

services
	.AddDbContext<Avassy.NetCore.Global.Geo.Data.Contexts.GeoDbContext>(
		options =>
		{
			options.UseSqlServer(this.Configuration.GetConnectionString("Geo"), sqlOptions =>
			{
				sqlOptions.EnableRetryOnFailure(
					maxRetryCount: 5,
					maxRetryDelay: TimeSpan.FromSeconds(5),
					errorNumbersToAdd: null);
			});
		}, ServiceLifetime.Transient)
```

.Net Core (2.1):

```

// DesignTimeDbContextFactory.cs (create yourself)

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Avassy.NetCore.Global.Geo.Data.Contexts.GeoDbContext>
{
    public Avassy.NetCore.Global.Geo.Data.Contexts.GeoDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<Avassy.NetCore.Global.Geo.Data.Contexts.GeoDbContext>();

        var connectionString = configuration.GetConnectionString("Geo");

        builder.UseSqlServer(connectionString);

        return new Avassy.NetCore.Global.Geo.Data.Contexts.GeoDbContext(builder.Options);
    }
}

```

At last use the Package Manager to create the database:

> PM > Update-Database -context "Avassy.NetCore.Global.Geo.Data.Contexts.GeoDbContext"

The database will be created and the data will be seeded to your new database.
