using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Point3D testPoint = new Point3D(1.1, 2.4, 3.0);
        //Console.WriteLine(testPoint);
        //Console.WriteLine(Point3D.StartPointToString());
        Point3D sPoint = Point3D.GetStartPoint();
        //Console.WriteLine(sPoint);

        //Console.WriteLine(DistanceCalculator.GetTheDistance(sPoint, testPoint));
        Console.WriteLine(DistanceCalculator.DistanceCalcDetails(sPoint, testPoint));

        try
        {
            List<Point3D> pointsList = new List<Point3D>();
            pointsList.Add(sPoint);
            pointsList.Add(testPoint);
            pointsList.Add(sPoint);
            pointsList.Add(testPoint);
            pointsList.Add(sPoint);
            pointsList.Add(testPoint);
            pointsList.Add(sPoint);
            pointsList.Add(testPoint);
            pointsList.Add(sPoint);
            pointsList.Add(testPoint);
            Path3D testPath = new Path3D(pointsList);
            Storage.StorePath(testPath, "testFile");
            Console.WriteLine("Path Success!");
            Path3D extractedPath = Storage.GetPathFromFile("testFile");
            Console.WriteLine(extractedPath);
        }
        catch (ArgumentNullException arEx)
        {
            Console.WriteLine("Unset List!\n"
                + arEx.Message);
        }
        catch (ArgumentException arEx)
        {
            Console.WriteLine("Zero List Count!\n"
                + arEx.Message);
        }
    }
}