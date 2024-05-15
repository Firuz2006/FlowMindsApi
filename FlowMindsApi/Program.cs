using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;
using FlowMindsApi.Repositories;

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Department>();
modelBuilder.EntitySet<Department>("Departments");
modelBuilder.EntityType<Category>();
modelBuilder.EntitySet<Category>("Categories");
modelBuilder.EntityType<Document>();
modelBuilder.EntitySet<Document>("Documents");
modelBuilder.EntityType<Field>();
modelBuilder.EntitySet<Field>("Fields");
modelBuilder.EntityType<FlowStep>();
modelBuilder.EntitySet<FlowStep>("FlowSteps");
modelBuilder.EntityType<Role>();
modelBuilder.EntitySet<Role>("Roles");
modelBuilder.EntityType<StackHolder>();
modelBuilder.EntitySet<StackHolder>("StackHolders");
modelBuilder.EntityType<Template>();
modelBuilder.EntitySet<Template>("Templates");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddOData(options => options
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(null)
        .Count()
        .Expand()
        .AddRouteComponents("odata", modelBuilder.GetEdmModel())
    );

builder.Services.AddScoped<IMongoClient>(_ =>
{
    var connectionString = "mongodb://localhost:27017";
    return new MongoClient(connectionString);
});
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IFieldRepository, FieldRepository>();
builder.Services.AddScoped<IFlowStepRepository, FlowStepRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IStackHolderRepository, StackHolderRepository>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.Run();