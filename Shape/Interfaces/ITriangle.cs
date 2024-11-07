namespace Shape.Interfaces;

/// <summary>
/// Интерфейс фигуры треугольник.
/// </summary>
public interface ITriangle : IShape
{
    /// <summary>
    /// Площадь.
    /// </summary>
    double Area { get; }

    /// <summary>
    /// Периметр.
    /// </summary>
    double Perimeter { get; }

    /// <summary>
    /// Является ли треугольник прямоугольным.
    /// </summary>
    bool IsRightAngle { get; }

    /// <summary>
    /// Получение длинной стороны треугольника.
    /// </summary>
    /// <returns>Длинная сторона.</returns>
    public double GetMaximumLengthSide();

    /// <summary>
    /// Получение срредней стороны треугольника.
    /// </summary>
    /// <returns>Средняя сторона.</returns>
    public double GetMediumLengthSide();

    /// <summary>
    /// Получение короткой стороны треугольника.
    /// </summary>
    /// <returns>Короткая сторона.</returns>
    public double GetMinimumLengthSide();
}
