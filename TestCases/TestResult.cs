namespace RegexMaster.TestCases;

public class TestResult
{
    public bool Successful { get; set; }
    public TestResult(bool successful)
    {
        Successful = successful;
    }
}