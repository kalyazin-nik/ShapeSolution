using Shape.Interfaces;

namespace Shape;

/// <summary>
/// Круг.
/// </summary>
public class Circle : ICircle
{
    /// <inheritdoc />
    public double Radius { get; }

    /// <inheritdoc />
    public double Area { get; }

    /// <inheritdoc />
    public double Circumference { get; }

    /// <summary>
    /// Инициализирует новый экземпляр объекта <see cref="Circle"/>.
    /// </summary>
    /// <remarks>
    /// В случае, если <paramref name="radius"/> будет иметь значение меньшее или равное нулю,<br />
    /// будет выбрашено исключение <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    /// <param name="radius">Радиус.</param>
    /// <exception cref="ArgumentOutOfRangeException" />
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

    /// <inheritdoc />
    public double CalculateArea()
    => CalculateArea(Radius);

    /// <inheritdoc />
    public double GetSectorArea(double radiansAngle)
        => GetSectorArea(Radius, radiansAngle);

    /// <inheritdoc />
    public double GetSectorArea(float degreesAngle)
        => GetSectorArea(Radius, degreesAngle);

    /// <summary>
    /// Вычисление площади сектора круга по углу в радианах.
    /// </summary>
    /// <param name="radius">Радиус.</param>
    /// <param name="radiansAngle">Угол в радианах.</param>
    /// <returns>Площадь сектора.</returns>
    public static double GetSectorArea(double radius, double radiansAngle)
    {
        radiansAngle = Math.Abs(radiansAngle);
        radiansAngle = radiansAngle - Math.Tau * Math.Floor(radiansAngle / Math.Tau);
        return radius * radius * (radiansAngle / 2);
    }

    /// <summary>
    /// Вычисление площади сектора круга по углу в градусах.
    /// </summary>
    /// <param name="radius">Радиус.</param>
    /// <param name="degreesAngle">Угол в градусах.</param>
    /// <returns>Площадь сектора.</returns>
    public static double GetSectorArea(double radius, float degreesAngle)
    {
        degreesAngle = Math.Abs(degreesAngle);
        degreesAngle = (float)(degreesAngle - 360 * Math.Floor(degreesAngle / 360));
        return CalculateArea(radius) * (degreesAngle / 360);
    }

    /// <summary>
    /// Вычисление площади круга.
    /// </summary>
    /// <param name="radius">Радиус.</param>
    /// <returns>Площадь круга.</returns>
    public static double CalculateArea(double radius)
    {
        return Math.PI * radius * radius;
    }

    /// <summary>
    /// Вычисление длины окружности.
    /// </summary>
    /// <param name="radius">Радиус.</param>
    /// <returns>Длина окружности.</returns>
    public static double GetCircumference(double radius)
    {
        return Math.PI * 2 * radius;
    }
}
