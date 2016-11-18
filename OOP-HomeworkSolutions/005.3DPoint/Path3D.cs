using System;
using System.Collections.Generic;
using System.Linq;

public class Path3D
{
    private List<Point3D> pointsListField = null;

    public Path3D(List<Point3D> pointsList)
    {
        this.PathPointList = pointsList;
    }

    public Point3D this[int number]
    {
        get
        {
            if (number >= 0 && number < this.pointsListField.Count)
            {
                return pointsListField[number];
            }

            throw new IndexOutOfRangeException("Invalid Path Index.");
        }
        set
        {
            if (number >= 0 && number < this.pointsListField.Count)
            {
                this.pointsListField[number] = value;
            }
        }
    }

    public List<Point3D> PathPointList
    {
        get { return this.pointsListField; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Only list holding one or more points can be set in the path.");
            }
            else if (value.Count == 0)
            {
                throw new ArgumentException(
                    "Only list holding one or more points can be set in the path.");
            }

            this.pointsListField = value;
        }
    }

    public int GetLength()
    {
        return this.pointsListField.Count;
    }

    public override string ToString()
    {
        string result = "";
        for (int idx = 0; idx < this.pointsListField.Count; idx++)
        {
            if (idx < this.pointsListField.Count - 1)
            {
                result += (idx + "  " + this.pointsListField[idx].ToString() + "\n");
                continue;
            }
            result += (idx + "  " + this.pointsListField[idx].ToString());
        }
        return result;
    }
}