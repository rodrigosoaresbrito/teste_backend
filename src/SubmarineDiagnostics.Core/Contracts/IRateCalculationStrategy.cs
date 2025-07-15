namespace SubmarineDiagnostics.Core.Contracts;

public interface IRateCalculationStrategy
{
    char DetermineBit(int zeroCount, int oneCount);
}
