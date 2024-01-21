var builder = DistributedApplication.CreateBuilder(args);

var postgresPassword = "p0wrd";
var postgresdb = builder.AddPostgresContainer("postgres", password: postgresPassword)
                        .WithVolumeMount("../volumes/postgres/data", "/var/lib/postgresql/data", VolumeMountType.Bind)
                        .AddDatabase("userPreferencesDb");

var idp = builder.AddProject<Projects.DnnAspire_Idp>("idp");

var foodbanksApi = builder.AddProject<Projects.DnnApsire_Foodbanks_Api>("foodbanksapi");

var userPreferencesApi = builder.AddProject<Projects.DnnAspire_UserPreferences_Api>("userpreferencesapi")
                                .WithReference(postgresdb);

builder.AddProject<Projects.DnnAspire_Foodbanks_Web>("foodbanksweb")
       .WithReference(idp)
       .WithReference(foodbanksApi)
       .WithReference(userPreferencesApi);

builder.Build().Run();