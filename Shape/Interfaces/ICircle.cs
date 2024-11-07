namespace Shape.Interfaces;

/// <summary>
/// Интерфейс фигуры круг.
/// </summary>
public interface ICircle : IShape
{
    /// <summary>
    /// Радиус.
    /// </summary>
    double Radius { get; }

    /// <summary>
    /// Площадь.
    /// </summary>
    double Area { get; }

    /// <summary>
    /// Длина окружности.
    /// </summary>
    double Circumference { get; }

    /// <summary>
    /// Вычисление площади сектора круга по углу в радианах.
    /// </summary>
    /// <param name="radiansAngle">Угол в радианах</param>
    /// <returns>Площадь сектора.</returns>
    double GetSectorArea(double radiansAngle);

    /// <summary>
    /// Вычисление площади сектора круга по углу в градусах.
    /// </summary>
    /// <param name="degreesAngle">Угол в градусах</param>
    /// <returns>Площадь сектора.</returns>
    double GetSectorArea(float degreesAngle);
}
