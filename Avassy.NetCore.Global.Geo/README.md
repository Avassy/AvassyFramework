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

First addd your connection string pointing to your database:

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

Then add the `Avassy.NetCore.Global.Geo.Data.Contexts.GeoDbContext` to your Asp.Net Core project or .Net Core project.

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


### `GeoDbContext`

#### `GetCountry` gets the country by ID.

##### Parameters:

- id (int, required): The ID of the country.
- includeStates (boolean, optional, default false): Specifies if you want to include the States IEnumerable in the Country object.

#### `GetCountryAsync` gets the country by ID asynchronously.

##### Parameters:

- id (int, required): The ID of the country.
- includeStates (boolean, optional, default false): Specifies if you want to include the States IEnumerable in the Country object.

#### `GetCountry` gets the country by iso code.

##### Parameters:

- isoCode (string, required): The iso code of the country.
- includeStates (boolean, optional, default false): Specifies if you want to include the States IEnumerable in the Country object.

#### `GetCountryAsync` gets the country by iso code.

##### Parameters:

- isoCode (string, required): The iso code of the country asynchronously.
- includeStates (boolean, optional, default false): Specifies if you want to include the States IEnumerable in the Country object.

#### `GetCountries` gets all the countries.

##### Parameters:

- includeStates (boolean, optional, default false): Specifies if you want to include the States IEnumerable in the Country object.

#### `GetState` gets the state by ID.

##### Parameters:

- id (int, required): The ID of the state.
- includeCountry (boolean, optional, default false): Specifies if you want to include the Country object in the State object.

#### `GetStateAsync` gets the state by ID asynchronously.

##### Parameters:

- id (int, required): The ID of the state.
- includeCountry (boolean, optional, default false): Specifies if you want to include the Country object in the State object.

#### `GetState` gets the state by iso code.

##### Parameters:

- isoCode (string, required): The iso code of the state.
- includeCountry (boolean, optional, default false): Specifies if you want to include the Country object in the State object.

#### `GetStateAsync` gets the state by iso code asynchronously.

##### Parameters:

- isoCode (string, required): The iso code of the state.
- includeCountry (boolean, optional, default false): Specifies if you want to include the Country object in the State object.

#### `GetStates` gets all the states.

##### Parameters:

- includeCountries (boolean, optional, default false): Specifies if you want to include the Country object in the State object.

#### `GetStatesForCountry` gets all the states for a specific country by ID.

##### Parameters:

- countryId (int, required): The ID of the country
- includeCountries (boolean, optional, default false): Specifies if you want to include the Country object in the State object.

#### `GetStatesForCountry` gets all the states for a specific country by country code.

##### Parameters:

- countryCode (string, required): The country code
- includeCountries (boolean, optional, default false): Specifies if you want to include the Country object in the State object.

