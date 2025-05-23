# 📄ResumeScannerAPI-Bilingual (English & German) CV Scoring API
A C# ASP.NET Core 8 Web API for scanning resumes (PDF or TXT) and evaluating them based on customizable rule-based scoring.

## ✨ Features
- 📤 Upload and scan PDF or TXT resumes via API.
- ⚙️ Evaluate resumes against a set of configurable scoring rules.
- 📊 Returns total scores per rule plus the matching keywords.
- 🌍 Supports English and German keywords.
- 🔍 Easily extendable with new rules and terms.
- 🌐 Swagger UI and Postman collection for quick testing.

 ## 📚 Rules Included
 
  | Rule                  | Description                          | Example Keywords (EN/DE)                  |
| :-------------------- | :----------------------------------- | :---------------------------------------- |
| **KeywordMatchRule**  | Scores based on general tech terms   | `C#`, `REST API`, `Einheitstests`         |
| **ExperienceRule**    | Detects years of experience mentions | `5 years experience`, `7 Jahre Erfahrung` |
| **TechStackRule**     | Looks for specific technologies      | `JavaScript`, `Docker`, `Kubernetes`      |
| **DegreeRule**        | Matches relevant degree titles       | `Computer Science`, `Informatik`          |
| **SoftSkillsRule**    | Scores for soft skills               | `Team player`, `Teamfähigkeit`            |
| **CertificationRule** | Checks for certifications            | `Azure Fundamentals`, `AWS Zertifiziert`  |

## 🛠️ Install Dependencies

```bash
dotnet add package UglyToad.PdfPig
dotnet add package Swashbuckle.AspNetCore
```

## Run API
```bash
dotnet run
```
Swagger UI available at:
```bash
https://localhost:{port}/swagger
```
## 📦 API Endpoints

| Method | Route               | Description                           |
| :----- | :------------------ | :------------------------------------ |
| `POST` | `/resume/scan-file` | Uploads and scans a PDF or TXT resume |

### 📤 Request (Multipart Form-Data)
- Key: `file`
- Value: Your CV (PDF or TXT)

### 📥 Response Example
```json
{
  "FileName": "resume.pdf",
  "Results": [
    {
      "RuleName": "TechStackRule",
      "Score": 20,
      "Matches": [ "JavaScript", "Docker" ]
    },
    {
      "RuleName": "SoftSkillsRule",
      "Score": 10,
      "Matches": [ "Team player" ]
    }
  ]
}
```

## 🌍 Multilingual Support (English & German)
The rules now accept both English and German terms in each category.
You can freely expand the keyword lists in Program.cs like this:
```csharp
new SoftSkillsRule(new List<string>{"Team player", "Teamfähigkeit", "Problem solver", "Problemlöser"})
```
## 📦 Project Structure
```vbnet
ResumeScannerAPI/
├── Controllers/
│   └── ResumeController.cs
├── Models/
│   ├── Resume.cs
│   └── ScoringResult.cs
├── Services/
│   ├── RuleEngineService.cs
│   └── Rules/
│       ├── IScoringRule.cs
│       ├── KeywordMatchRule.cs
│       ├── ExperienceRule.cs
│       ├── TechStackRule.cs
│       ├── DegreeRule.cs
│       ├── SoftSkillsRule.cs
│       └── CertificationRule.cs
└── Program.cs

```

## ✍️ Adding New Rules

- Create a new class in `Services/Rules` implementing `IScoringRule`.
- Implement your own `Evaluate(string content)`  method returning a `ScoringResult`.
- Return a `ScoringResult` containing `ruleName`, `Score` and `Matches`.
- Register your rule in `Program.cs` inside the `AddSingleton` block.

Example:
```csharp
new SoftSkillsRule(new List<string>{"Team player", "Teamfähigkeit", "Leadership"})
```
