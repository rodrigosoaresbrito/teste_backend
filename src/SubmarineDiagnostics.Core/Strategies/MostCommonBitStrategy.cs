using SubmarineDiagnostics.Core.Contracts;

namespace SubmarineDiagnostics.Core.Strategies;

public class MostCommonBitStrategy : IRateCalculationStrategy
{
    public char DetermineBit(int zeroCount, int oneCount)
    {
        return oneCount >= zeroCount ? '1' : '0';
    }
}
