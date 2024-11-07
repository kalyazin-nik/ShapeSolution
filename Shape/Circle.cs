namespace Shape;

public class Circle : IShape
{
    public double Radius { get; }
    public double Area { get; }
    public double Circumference { get; }

    public Circle(double radius)
    {
        ThrowIfRadiusIsLessThanOrEqualZero(radius);
        Radius = radius;
        Area = CalculateArea(radius);
        Circumference = GetCircumference(radius);
    }

    private static void ThrowIfRadiusIsLessThanOrEqualZero(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(radius, 0);
    }

    public double CalculateArea()
        => CalculateArea(Radius);

    public double GetSectorArea(double radiansAngle)
        => GetSectorArea(Radius, radiansAngle);

    public double GetSectorArea(float degreesAngle)
        => GetSectorArea(Radius, degreesAngle);

    public static double GetSectorArea(double radius, double radiansAngle)
    {
        radiansAngle = Math.Abs(radiansAngle);
        radiansAngle = radiansAngle - Math.Tau * Math.Floor(radiansAngle / Math.Tau);
        return radius * radius * (radiansAngle / 2);
    }

    public static double GetSectorArea(double radius, float degreesAngle)
    {
        degreesAngle = Math.Abs(degreesAngle);
        degreesAngle = (float)(degreesAngle - 360 * Math.Floor(degreesAngle / 360));
        return CalculateArea(radius) * (degreesAngle / 360);
    }

    public static double CalculateArea(double radius)
    {
        return Math.PI * radius * radius;
    }

    public static double GetCircumference(double radius)
    {
        return Math.PI * 2 * radius;
    }
}
