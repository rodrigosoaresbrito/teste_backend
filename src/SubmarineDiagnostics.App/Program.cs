using SubmarineDiagnostics.Core.Services;

Console.WriteLine("--- Relatório de Diagnostico do Submarino ---");


var diagnosticData = new List<string>
            {
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
            };

var calculator = new DiagnosticReportCalculator();
int powerConsumption = calculator.CalculatePowerConsumption(diagnosticData);


Console.WriteLine($"Analisando {diagnosticData.Count} dados");
Console.WriteLine($"Consumo calculado: {powerConsumption}");