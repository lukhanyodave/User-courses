var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder
    .AddSqlServer(name: "demo-sql", port: 3456)
    .PublishAsContainer()
    .WithContainerName(name: "demo-sql-container")
    .WithDataVolume(name: "demo-sql-data")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDbGate();

var backEndDb = sqlServer
    .AddDatabase(name: "demo-backend-db");

builder.AddProject<Projects.SomeService_Api>("demo-api")
    .WithReference(backEndDb)
    .WaitFor(backEndDb)
    ;

builder.Build().Run();
