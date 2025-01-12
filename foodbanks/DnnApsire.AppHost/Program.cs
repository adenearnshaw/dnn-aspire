var builder = DistributedApplication.CreateBuilder(args);

// Postgres
var pgUsername = builder.AddParameter("pgUsername", secret: true);
var pgPassword = builder.AddParameter("pgPassword", secret: true);

var postgres = builder.AddPostgres("postgres", pgUsername, pgPassword)
    .WithDataBindMount(source: "../volumes/postgres/data", isReadOnly: false)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithPgAdmin()
    .WithPgWeb();

var postgresDb = postgres.AddDatabase("userPreferencesDb");

// Keycloak Server
var kcUsername = builder.AddParameter("kcUsername", secret: true);
var kcPassword = builder.AddParameter("kcPassword", secret: true);

var keycloak = builder.AddKeycloak("idp", 7001, kcUsername, kcPassword)
    .WithDataVolume()
    .WithRealmImport("./Keycloak");
    //.WithLifetime(ContainerLifetime.Persistent);

var foodbanksApi = builder.AddProject<Projects.DnnApsire_Foodbanks_Api>("foodbanksapi")
    .WithHttpsHealthCheck("/health");

var userPreferencesApi = builder.AddProject<Projects.DnnAspire_UserPreferences_Api>("userpreferencesapi")
    .WithReference(postgresDb)
    .WaitFor(postgresDb)
    .WithHttpsHealthCheck("/health");

builder.AddProject<Projects.DnnAspire_Foodbanks_Web>("foodbanksweb")
       .WithExternalHttpEndpoints()
       .WithReference(keycloak)
       .WithReference(foodbanksApi)
       .WithReference(userPreferencesApi)
       .WaitFor(userPreferencesApi)
       .WaitFor(foodbanksApi);

builder.Build().Run();
