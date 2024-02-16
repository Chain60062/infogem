Tech ecommerce store website REST API, built for studying purposes. 
Built with ASP.NET Core using EF-Core with PostgreSQL.

## Running the application
To set up the database you will need to first set the user secret for the connection string using the cli, for instance:

```
dotnet user-secrets set "Infogem:DefaultConnection" "Host=localhost;Port=5432;Database=infogem;Username=myuser;Password=mypassword;"
```

Then, you will need to run the migrations, for that you will also need the ef-core cli tool:

```
#uncomment the command if you need to install the dotnet-ef cli tool
#dotnet tool install --global dotnet-ef

#uncomment if for some reason the migrations aren't under Data/Migrations
#dotnet ef migrations add Initial
dotnet ef database update
```

And finally:

```
dotnet run
```