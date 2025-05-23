using ResumeScannerAPI.Models;

namespace ResumeScannerAPI.Services.Rules
{
    public interface IScoringRule
    {
        ScoringResult Evaluate(string content);
        string RuleName { get; }
    }
}
