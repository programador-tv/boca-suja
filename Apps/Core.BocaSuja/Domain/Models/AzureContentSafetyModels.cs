namespace Core.BocaSuja.Models;
public class ContentSafetyResult
{
    public List<BlocklistMatchResult> BlocklistsMatchResults { get; set; }
    public SafetyResult HateResult { get; set; }
    public SafetyResult SelfHarmResult { get; set; }
    public SafetyResult SexualResult { get; set; }
    public SafetyResult ViolenceResult { get; set; }
}

public class BlocklistMatchResult
{
    // Propriedades relevantes para o BlocklistMatchResult, se houver.
}

public class SafetyResult
{
    public string Category { get; set; }
    public int Severity { get; set; }
}