namespace Shape;

public class Circle(double radius) : IShape
{
    public double Radius { get; } = radius;
    public double Area { get; } = CalculateArea(radius);
    public double Circumference { get; } = GetCircumference(radius);

    public double CalculateArea()
        => CalculateArea(Radius);

    public double GetSectorArea(double radiansAngle)
        => GetSectorArea(Radius, radiansAngle);
    
    public double GetSectorArea(float degreesAngle)
        => GetSectorArea(Radius, degreesAngle);

    public static double GetSectorArea(double radius, double radiansAngle)
    {
        return radius * radius * (radiansAngle / 2);
    }
    
    public static double GetSectorArea(double radius, float degreesAngle)
    {
        return GetCircumference(radius) * degreesAngle / 360;
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
