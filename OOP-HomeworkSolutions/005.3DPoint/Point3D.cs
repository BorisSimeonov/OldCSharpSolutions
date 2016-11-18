using System;

public class Point3D
{
    private double xAxisField = 0d;

    private double yAxisField = 0d;

    private double zAxisField = 0d;

    private static readonly Point3D startPoint = new Point3D(0.0, 0.0, 0.0);

    public Point3D(double x, double y, double z)
    {
        this.XAxis = x;
        this.YAxis = y;
        this.ZAxis = z;
    }

    public double XAxis
    {
        get { return this.xAxisField; }
        set
        {
            xAxisField = value;
        }
    }

    public double YAxis
    {
        get { return this.yAxisField; }
        set
        {
            yAxisField = value;
        }
    }

    public double ZAxis
    {
        get { return this.zAxisField; }
        set
        {
            zAxisField = value;
        }
    }

    public override string ToString()
    {
        return string.Format("Point(x:{0}, y:{1}, z:{2})",
            this.XAxis, this.YAxis, this.ZAxis);
    }

    public static string StartPointToString()
    {
        return "Start " + startPoint.ToString();
    }

    public static Point3D GetStartPoint()
    {
        return startPoint;
    }
}