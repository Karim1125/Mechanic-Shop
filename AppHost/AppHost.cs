using Projects;

var builder = DistributedApplication.CreateBuilder(args);
var app = builder.AddProject<MechanicShop_Api>("quickgridmeteo");
builder.Build().Run();
