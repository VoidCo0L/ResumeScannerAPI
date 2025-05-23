using ResumeScannerAPI.Services;
using ResumeScannerAPI.Services.Rules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//register rules
builder.Services.AddSingleton(provider =>
{
    var rules = new List<IScoringRule>
    {
        new KeywordMatchRule(new List<string>{"C#", "ASP.NET", "React", "SQL", "Microservices", "Blazor", "REST API", "Unit Testing"}),
        new ExperienceRule(),
        new TechStackRule(new List<string>{"JavaScript", "Docker", "Kubernetes", "Azure", "Entity Framework", "RabbitMQ", "GraphQL", "TypeScript"}),
        new DegreeRule(new List<string>{"Computer Science", "Software Engineering", "IT"}),
        new SoftSkillsRule(new List<string>{"Team player", "Agile", "Problem-solving", "Communication"}),
        new CertificationRule(new List<string>{"Azure Fundamentals", "AWS Certified", "Scrum Master", "MCSD"})
    };

    return new RuleEngineService(rules);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
