using SubmarineDiagnostics.Core.Contracts;
using SubmarineDiagnostics.Core.Strategies;
using System.Text;

namespace SubmarineDiagnostics.Core.Services;

public class DiagnosticReportCalculator
{
    public int CalculatePowerConsumption(IReadOnlyList<string>? binaryReport)
    {
        if (binaryReport == null || !binaryReport.Any() || string.IsNullOrEmpty(binaryReport[0]))
        {
            return 0;
        }

        string gammaRateBinary = GenerateRate(binaryReport, new MostCommonBitStrategy());

        string epsilonRateBinary = GenerateRate(binaryReport, new LeastCommonBitStrategy());

        int gammaRateDecimal = Convert.ToInt32(gammaRateBinary, 2);
        int epsilonRateDecimal = Convert.ToInt32(epsilonRateBinary, 2);

        return gammaRateDecimal * epsilonRateDecimal;
    }

    private static string GenerateRate(IReadOnlyList<string> binaryReport,
                                IRateCalculationStrategy strategy)
    {
        int bitLength = binaryReport[0].Length;
        var rateBuilder = new StringBuilder(bitLength);

        for (int i = 0; i < bitLength; i++)
        {
            int zeroCount = 0;
            int oneCount = 0;

            foreach (string binaryNumber in binaryReport)
            {
                if (binaryNumber[i] == '1')
                    oneCount++;
                else
                    zeroCount++;
            }
            char bit = strategy.DetermineBit(zeroCount, oneCount);
            rateBuilder.Append(bit);
        }
        return rateBuilder.ToString();
    }
}
