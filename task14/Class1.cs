namespace task14;

using System;
using System.Threading;
using System.Collections.Generic;

public class DefiniteIntegral
{
    public static double Solve(double a, double b, Func<double, double> function, double step, int threadsNumber)
    {
        if (threadsNumber <= 0) throw new Exception("больше нуля потоков должно быть!");

        double totalIntegral = 0;
        double pieceLength = (b - a) / threadsNumber;
        List<(double start, double end)> pieces = [];

        foreach (var threadNum in Enumerable.Range(0, threadsNumber))
        {
            double start = a + threadNum * pieceLength;
            double end = threadNum == threadsNumber - 1 ? b : start + pieceLength;
            pieces.Add((start, end));
        }

        Parallel.ForEach(pieces, piece => // мне кажется так проще, чем через берьер
        {
            double partialIntegral = TrapezialCompute(piece.start, piece.end, function, step);
            Interlocked.Exchange(ref totalIntegral, totalIntegral + partialIntegral);
        });

        return totalIntegral;
    }

    private static double TrapezialCompute(double a, double b, Func<double, double> function, double step)
    {
        double h = step;
        int n = (int)Math.Ceiling((b - a) / h);
        if (n == 0) return 0;
        h = (b - a) / n;
        double integral = (function(a) + function(b)) / 2;
        for (int i = 1; i < n; i++)
        {
            double x = a + i * h;
            integral += function(x);
        }
        return integral * h;
    }
}
