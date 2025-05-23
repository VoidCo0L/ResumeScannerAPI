namespace ResumeScannerAPI.Models
{
    public class ScoringResult
    {
        public string RuleName { get; set; }
        public int Score { get; set; }
        public List<string> Matches { get; set; } = new();
    }
}
