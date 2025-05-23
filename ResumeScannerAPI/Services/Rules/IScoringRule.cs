namespace ResumeScannerAPI.Services.Rules
{
    public interface IScoringRule
    {
        int CalculateScore(string content);
        string RuleName { get; }
    }
}
