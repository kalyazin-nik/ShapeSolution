namespace Shape;

public class Circle(double radius) : IShape
{
    private double _area = Math.PI * radius * radius;
    private double _perimeter = Math.PI * 2 * radius;

    public double Radius { get; } = radius;
    public double Area => _area;
    public double Perimeter => _perimeter;

    public double GetSectorArea(double radiansAngle)
    {
        return Radius * Radius * (radiansAngle / 2);
    }
    
    public double GetSectorArea(float degreesAngle)
    {
        return _area * degreesAngle / 360;
    }
}
