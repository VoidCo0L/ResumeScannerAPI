using ResumeScannerAPI.Services;
using ResumeScannerAPI.Services.Rules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//register rules both in german & english
builder.Services.AddSingleton(provider =>
{
    var rules = new List<IScoringRule>
    {
        new KeywordMatchRule(new List<string>{
            "C#", "ASP.NET", "React", "SQL", "Microservices", "Blazor", "REST API", "Unit Testing",
            "Mikroservices", "Schnittstellen", "Einheitstests"
        }),
        new ExperienceRule(),
        new TechStackRule(new List<string>{
            "JavaScript", "Docker", "Kubernetes", "Azure", "Entity Framework", "RabbitMQ", "GraphQL", "TypeScript",
            "JavaScript", "Docker", "Kubernetes", "Azure", "Entity Framework", "RabbitMQ", "GraphQL", "TypeScript"
        }),
        new DegreeRule(new List<string>{
            "Computer Science", "Software Engineering", "IT",
            "Informatik", "Softwareentwicklung", "Informationstechnologie"
        }),
        new SoftSkillsRule(new List<string>{
            "Team player", "Agile", "Problem-solving", "Communication",
            "Teamfähigkeit", "Agil", "Problemlösung", "Kommunikation"
        }),
        new CertificationRule(new List<string>{
            "Azure Fundamentals", "AWS Certified", "Scrum Master", "MCSD",
            "Azure Grundlagen", "AWS Zertifiziert", "Scrum Master", "Microsoft Certified"
        })
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
