using SubmarineDiagnostics.Core.Services;

namespace SubmarineDiagnostics.Core.Tests;

public class DiagnosticReportCalculatorTests
{
    private readonly DiagnosticReportCalculator _calculator;
    private readonly List<string> _sampleReport;

    public DiagnosticReportCalculatorTests()
    {
        _calculator = new DiagnosticReportCalculator();

        _sampleReport =
            [
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            ];
    }

    [Fact]
    public void CalculatePowerConsumption_WithSampleData_ShouldReturnCorrectResult()
    {
        int result = _calculator.CalculatePowerConsumption(_sampleReport);
        Assert.Equal(198, result);
    }

    [Fact]
    public void CalculatePowerConsumption_WithEmptyReport_ShouldReturnZero()
    {
        var emptyReport = new List<string>();
        int result = _calculator.CalculatePowerConsumption(emptyReport);
        Assert.Equal(0, result);
    }
    [Fact]
    public void CalculatePowerConsumption_WithNullReport_ShouldReturnZero()
    {
        List<string>? nullReport = null;
        int result = _calculator.CalculatePowerConsumption(nullReport);
        Assert.Equal(0, result);
    }
}
