using AssignmentNo2.NetCore;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup();
startup.HelloServices(builder.Services);
var app = builder.Build();
startup.Configure(app, builder.Environment);