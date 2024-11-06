namespace Shape;

public class Triangle(double sideA, double sideB, double sideC) : IShape
{
    public readonly double SideA = sideA;
    public readonly double SideB = sideB;
    public readonly double SideC = sideC;

    public double Area { get; } = CalculateArea(sideA, sideB, sideC);
    public double Perimeter { get; } = GetPerimeter(sideA, sideB, sideC);
    public bool IsRightAngle { get; } = IsTriangleRectangular(sideA, sideB, sideC);

    public double CalculateArea()
        => CalculateArea(SideA, SideB, SideC);

    public double GetMaximumLengthSide()
        => GetMaximumLengthSide(SideA, SideB, SideC);

    public double GetMediumLengthSide()
        => GetMediumLengthSide(SideA, SideB, SideC);

    public double GetMinimumLengthSide()
        => GetMinimumLengthSide(SideA, SideB, SideC);

    public static double CalculateArea(double sideA, double sideB, double sideC)
    {
        var perimeter = GetPerimeter(sideA, sideB, sideC);
        return Math.Sqrt(perimeter * (perimeter - sideA) * (perimeter - sideB) * (perimeter - sideC));
    }

    public static double GetPerimeter(double sideA, double sideB, double sideC)
    {
        return (sideA + sideB + sideC) / 2;
    }

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
