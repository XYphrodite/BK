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


    }

    const int Pres = 4; // Pres is declared as a constant

    static void WriteToJson<T>(string fileName, List<T> data)
    {
        // Сериализуем данные в формат JSON
        string jsonData = JsonConvert.SerializeObject(data);

        // Записываем данные в файл
        System.IO.File.WriteAllText(fileName, jsonData);
    }

    internal static List<string> Get(string g, string p)
    {
        
        List<string> outs = new List<string>();

        double max = 0;

        double G = double.Parse(g);
        double P = double.Parse(p);

        double c_big, c_avg, c_small;
        double p_big, p_avg, p_small;

        // Присваиваем значения переменным с использованием функций
        c_big = ConsumptionBig(G);
        c_avg = ConsumptionAvg(G);
        c_small = ConsumptionSmall(G);

        p_big = PressureBig(P);
        p_avg = PressureAvg(P);
        p_small = PressureSmall(P);

        double[][] cnsts = new double[4][];
        double[] mxs = new double[4];
        double mx;

        // Заполнение массива cnsts
        cnsts[0] = new double[] { c_small, p_small, c_small, p_avg, c_avg, p_small };
        cnsts[1] = new double[] { c_small, p_big, c_avg, p_avg, c_big, p_small };
        cnsts[2] = new double[] { c_avg, p_big, c_big, p_avg, c_big, p_big };
        cnsts[3] = new double[] { Math.Sqrt(Math.Abs(1 - c_avg)), p_small, p_avg, p_small };

        // Расчет максимальных значений
        mxs[0] = Math.Max(cnsts[0][0] + cnsts[0][1], Math.Max(cnsts[0][2] + cnsts[0][3], cnsts[0][4] + cnsts[0][5]));
        mxs[1] = Math.Max(cnsts[1][0] + cnsts[1][1], Math.Max(cnsts[1][2] + cnsts[1][3], cnsts[1][4] + cnsts[1][5]));
        mxs[2] = Math.Max(cnsts[2][0] + cnsts[2][1], Math.Max(cnsts[2][2] + cnsts[2][3], cnsts[2][4] + cnsts[2][5]));
        mxs[3] = Math.Max(cnsts[3][0] + cnsts[3][1], Math.Max(cnsts[3][2], cnsts[0][3]));

        // Находим максимальное значение из mxs
        mx = mxs.Max();

        int maxIndex = Array.IndexOf(mxs, mx);
        outs.Add($"Расход сырья = малый ({cnsts[0][0]}) | Давление = малое ({cnsts[0][1]}) | {cnsts[0][0] + cnsts[0][1]}"+Environment.NewLine
            +$"Расход сырья = малый ({cnsts[0][2]}) | Давление = среднее ({cnsts[0][3]}) | {cnsts[0][2] + cnsts[0][3]}" + Environment.NewLine
            +$"Расход сырья = средний ({cnsts[0][4]}) | Давление = малое ({cnsts[0][5]}) | {cnsts[0][4] + cnsts[0][5]}" + Environment.NewLine
            +$"Максимальное: {mxs[0]}");

        outs.Add($"Расход сырья = малый ({cnsts[1][0]}) | Давление = малое ({cnsts[1][1]}) | {cnsts[1][0] + cnsts[1][1]}" + Environment.NewLine
    + $"Расход сырья = средний ({cnsts[1][2]}) | Давление = среднее ({cnsts[1][3]}) | {cnsts[1][2] + cnsts[1][3]}" + Environment.NewLine
    + $"Расход сырья = большой ({cnsts[1][4]}) | Давление = малое ({cnsts[1][5]}) | {cnsts[1][4] + cnsts[1][5]}" + Environment.NewLine
    + $"Максимальное: {mxs[1]}");

        outs.Add($"Расход сырья = средний ({cnsts[2][0]}) | Давление = большое ({cnsts[2][1]}) | {cnsts[2][0] + cnsts[2][1]}" + Environment.NewLine
    + $"Расход сырья = большой ({cnsts[2][2]}) | Давление = среднее ({cnsts[2][3]}) | {cnsts[2][2] + cnsts[2][3]}" + Environment.NewLine
    + $"Расход сырья = большой ({cnsts[2][4]}) | Давление = большое ({cnsts[2][5]}) | {cnsts[2][4] + cnsts[2][5]}" + Environment.NewLine
    + $"Максимальное: {mxs[2]}");

        outs.Add($"Расход сырья = слегка не средний ({cnsts[3][0]}) | Давление = малое ({cnsts[3][1]}) | {cnsts[3][0] + cnsts[3][1]}" + Environment.NewLine
    + $"Давление = среднее ({cnsts[3][2]})" + Environment.NewLine
    + $"Давление = большое ({cnsts[3][3]})" + Environment.NewLine
    + $"Максимальное: {mxs[3]}");

        outs.Add($"Вам следует использовать конструкцию номер {maxIndex+1 } (Вероятность: {mx})");


        return outs;
    }
}
