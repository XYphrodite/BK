using Newtonsoft.Json;

namespace BK2;

internal class Counter
{
    public static double ConsumptionSmall(double G)
    {
        double res = Math.Pow(Math.Exp(-0.2 * Math.Log(10 * Math.Abs(G - 75.1))), 2);
        if (double.IsNaN(res)) res = Math.Pow(1e-1, Pres);
        return Math.Round(res, Pres);
    }

    public static double ConsumptionAvg(double G)
    {
        double res = Math.Pow(Math.Exp(-0.2 * Math.Log(10 * Math.Abs(G - 85.1))), 2);
        if (double.IsNaN(res)) res = Math.Pow(1e-1, Pres);
        return Math.Round(res, Pres);
    }

    public static double ConsumptionBig(double G)
    {
        double res = Math.Pow(Math.Exp(-0.2 * Math.Log(10 * Math.Abs(G - 100.1))), 2);
        if (double.IsNaN(res)) res = Math.Pow(1e-1, Pres);
        return Math.Round(res, Pres);
    }

    public static double PressureSmall(double P)
    {
        double res = Math.Abs(1 / (1 + 0.5 * P));
        if (res == double.PositiveInfinity) res = Math.Pow(1e-1, Pres);
        return Math.Round(res, Pres);
    }

    public static double PressureAvg(double P)
    {
        double res = Math.Abs(1 / (1 + 0.5 * Math.Abs(P - 25)));
        if (res == double.PositiveInfinity) res = Math.Pow(1e-1, Pres);
        return Math.Round(res, Pres);
    }

    public static double PressureBig(double P)
    {
        double res = Math.Abs(1 / (1 + 0.5 * Math.Abs(P - 50)));
        if (res == double.PositiveInfinity) res = Math.Pow(1e-1, Pres);
        return Math.Round(res, Pres);
    }

    public static void Count()
    {
        List<double> cxChart = new List<double>();
        List<double> cySmallChart = new List<double>();
        List<double> cyAvgChart = new List<double>();
        List<double> cyBigChart = new List<double>();

        List<double> pxChart = new List<double>();
        List<double> pySmallChart = new List<double>();
        List<double> pyAvgChart = new List<double>();
        List<double> pyBigChart = new List<double>();

        const int consumptionBoundsLower = 70;
        const int consumptionBoundsUpper = 110;
        const int pressureBoundsLower = 0;
        const int pressureBoundsUpper = 50;

        for (int i = consumptionBoundsLower; i <= consumptionBoundsUpper; i++)
        {
            cxChart.Add(i);
            cySmallChart.Add(ConsumptionSmall(i));
            cyAvgChart.Add(ConsumptionAvg(i));
            cyBigChart.Add(ConsumptionBig(i));
        }
        for (int i = pressureBoundsLower; i <= pressureBoundsUpper; i++)
        {
            pxChart.Add(i);
            pySmallChart.Add(PressureSmall(i));
            pyAvgChart.Add(PressureAvg(i));
            pyBigChart.Add(PressureBig(i));
        }

        WriteToJson("cxChart.json", cxChart);
        WriteToJson("cySmallChart.json", cySmallChart);
        WriteToJson("cyAvgChart.json", cyAvgChart);
        WriteToJson("cyBigChart.json", cyBigChart);
        WriteToJson("pxChart.json", pxChart);
        WriteToJson("pySmallChart.json", pySmallChart);
        WriteToJson("pyAvgChart.json", pyAvgChart);
        WriteToJson("pyBigChart.json", pyBigChart);

        const int consumptionValue = consumptionBoundsLower;
        const int pressureValue = pressureBoundsUpper;

        // Assuming these are state management variables in a React component
        List<List<double>> constructions = new List<List<double>>()
        {
            new List<double>(){0, 0, 0, 0, 0, 0},
            new List<double>(){0, 0, 0, 0, 0, 0},
            new List<double>(){0, 0, 0, 0, 0, 0},
            new List<double>(){0, 0, 0, 0}
        };
        List<double> maxs = new List<double>() { 0, 0, 0, 0 };
        double max = 0;

        // Rest of the logic for React components are omitted as they are not relevant in C#
    }

    const int Pres = 4; // Pres is declared as a constant

    static void WriteToJson<T>(string fileName, List<T> data)
    {
        // Сериализуем данные в формат JSON
        string jsonData = JsonConvert.SerializeObject(data);

        // Записываем данные в файл
        System.IO.File.WriteAllText(fileName, jsonData);
    }
}
