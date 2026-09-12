using AIImpactAnalysis.Services;
using AIImpactAnalysis.Tools;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<ConfluenceSearchTool>();
builder.Services.AddScoped<ConfluenceSearchService>();
builder.Services.AddScoped<IOrchestrationService,
                           OrchestrationService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();