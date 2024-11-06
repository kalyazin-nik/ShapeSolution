namespace Shape;

public class Triangle : IShape
{
    public readonly double SideA;
    public readonly double SideB;
    public readonly double SideC;

    public double Area { get; }
    public double Perimeter { get; }
    public bool IsRightAngle { get; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        var perimeter = (sideA + sideB + sideC) / 2;
        Area = Math.Sqrt(perimeter * (perimeter - sideA) * (perimeter - sideB) * (perimeter - sideC));
        Perimeter = perimeter;
        IsRightAngle = IsTriangleRectangular(sideA, sideB, sideC);
    }

    public double GetMaximumLengthSide()
        => GetMaximumLengthSide(SideA, SideB, SideC);

    public double GetMediumLengthSide()
        => GetMediumLengthSide(SideA, SideB, SideC);

    public double GetMinimumLengthSide()
        => GetMinimumLengthSide(SideA, SideB, SideC);

    public static bool IsTriangleRectangular(double sideA, double sideB, double sideC)
    {
        var hypotenuse = GetMaximumLengthSide(sideA, sideB, sideC);
        var legA = GetMediumLengthSide(sideA, sideB, sideC);
        var legB = GetMinimumLengthSide(sideA, sideB, sideC);

        return Math.Abs((hypotenuse * hypotenuse) - Math.Sqrt(legA * legA + legB * legB)) <= 1e-9;
    }

    public static double GetMaximumLengthSide(double sideA, double sideB, double sideC)
    {
        return sideA > sideB
            ? (sideA > sideC ? sideA : sideC)
            : (sideB > sideC ? sideB : sideC);
    }

    public static double GetMediumLengthSide(double sideA, double sideB, double sideC)
    {
        return sideA < sideB
            ? (sideC < sideA ? sideA : (sideC > sideB ? sideB : sideC))
            : (sideC < sideB ? sideB : (sideC > sideA ? sideA : sideC));
    }

    public static double GetMinimumLengthSide(double sideA, double sideB, double sideC)
    {
        return sideA < sideB
            ? (sideA < sideC ? sideA : sideC)
            : (sideB < sideC ? sideB : sideC);
    }
}
