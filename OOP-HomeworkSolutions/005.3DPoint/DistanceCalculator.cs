using System;

public static class DistanceCalculator
{
    public static double GetTheDistance(Point3D fstPoint, Point3D sndPoint)
    {
        double x = fstPoint.XAxis - sndPoint.XAxis;
        double y = fstPoint.YAxis - sndPoint.YAxis;
        double z = fstPoint.ZAxis - sndPoint.ZAxis;
        double distance = Math.Sqrt((x * x) + (y * y) + (z * z));
        return Math.Round(distance, 4);
    }

    public static string DistanceCalcDetails(Point3D fstPoint, Point3D sndPoint)
    {
        string result = string.Format("Distance between {0} and {1}:",
            fstPoint.ToString(), sndPoint.ToString());

        result += string.Format(
        "\nd = Sqrt(({0} - {1})^2 + ({2} - {3})^2 + ({4} - {5})^2)",
        fstPoint.XAxis, sndPoint.XAxis, fstPoint.YAxis, sndPoint.YAxis,
        fstPoint.ZAxis, sndPoint.ZAxis);
        double x = fstPoint.XAxis - sndPoint.XAxis;
        double y = fstPoint.YAxis - sndPoint.YAxis;
        double z = fstPoint.ZAxis - sndPoint.ZAxis;
        result += string.Format(
            "\nd = Sqrt(({0})^2 + ({1})^2 + ({2})^2)",
            x, y, z);
        x *= x;
        y *= y;
        z *= z;
        result += string.Format(
            "\nd = Sqrt({0} + {1} + {2})",
            x, y, z);
        result += string.Format(
            "\nd = Sqrt({0})",
            x + y + z);
        double distance = Math.Sqrt(x + y + z);
        result += string.Format(
            "\nd = {0}",
            Math.Round(distance, 5));
        return result;
    }
}