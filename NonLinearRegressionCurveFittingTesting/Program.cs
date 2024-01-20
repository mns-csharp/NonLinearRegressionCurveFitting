using NonLinearRegressionCurveFittingTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

class Program
{
    static void Main()
    {
        string outputPath = Path.Combine(Constants.SolutionDirectory, "[ExpCurveFitting]");
        string strPattern_ = @"run\d+_inner\d+_outer\d+_factor\d+_residue\d+";
        FileFilter filter = new FileFilter(".", strPattern_);

        var expPoints = FileReader.ReadTwoColumns("", "DataSet.txt");
        
        List<string> autocorrFiles = filter.GetMatchingFiles();
        List<double> xValues = expPoints.Item1;
        List<double> yValues = expPoints.Item1;
        
        for (int i = 0 ; i < yValues.Count ; i++)
        {
            double a = xValues[i];
            double b = yValues[i];

            var autoCorrPoints = FileReader.ReadTwoColumns("", autocorrFiles[i]);

            var expDecay = MathUtils.GetExponentialDecayLine(10, 0, 1000, a, b);
            DataPlotter plotter = new DataPlotter();
            plotter.AddCurve($"AutoCorr{i}", autoCorrPoints.Item1, autoCorrPoints.Item2, Color.Red, IsSymbolVisible: false);
            plotter.AddCurve($"ExpDecay{i}", expDecay.Item1, expDecay.Item2, Color.Blue, IsSymbolVisible: false);
            plotter.ZoomXaxis(0, 1000);
            plotter.SavePlot(outputPath, $"{autocorrFiles[i]}.png");
        }

        //Console.ReadKey();
    }
}

