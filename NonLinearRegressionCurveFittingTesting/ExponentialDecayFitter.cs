using System;
using System.Collections.Generic;
using System.Linq;

public class ExponentialLeastSquares
{
    // Method to fit an exponential curve to the data points.
    // Assumes that the data points are (x, y) pairs following y = a * exp(b * x).
    public static (double a, double b) FitCurve(IEnumerable<double> dataPointsX, IEnumerable<double> dataPointsY)
    {
        // Take the natural log of the y values to linearize the problem (ln(y) = ln(a) + b * x).
        var lnDataPointsY = dataPointsY.Select(y => Math.Log(y)).ToList();

        // Calculate the means of the x values and the log-transformed y values.
        double xMean = dataPointsX.Average();
        double yMean = lnDataPointsY.Average();

        // Calculate the sums needed for the linear regression coefficients.
        double sumXY = 0, sumX2 = 0;
        int n = dataPointsX.Count();
        for (int i = 0; i < n; i++)
        {
            var x = dataPointsX.ElementAt(i);
            var y = lnDataPointsY.ElementAt(i);
            sumXY += (x - xMean) * (y - yMean);
            sumX2 += Math.Pow(x - xMean, 2);
        }

        // Calculate b (the slope of the linear regression line).
        double b = sumXY / sumX2;

        // Calculate a (exp(intercept) of the regression line).
        // The intercept is ln(a), so we need to exponentiate the intercept to solve for a.
        double lnA = yMean - b * xMean;
        double a = Math.Exp(lnA);

        return (a, b);
    }
}