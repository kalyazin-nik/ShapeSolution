using Shape.Interfaces;

namespace Shape;

/// <summary>
/// Треугольник.
/// </summary>
public class Triangle : ITriangle
{
    /// <summary>
    /// Сторона A.
    /// </summary>
    public readonly double SideA;

    /// <summary>
    /// Сторона B.
    /// </summary>
    public readonly double SideB;

    /// <summary>
    /// Сторона C.
    /// </summary>
    public readonly double SideC;

    /// <inheritdoc />
    public double Area { get; }

    /// <inheritdoc />
    public double Perimeter { get; }

    /// <inheritdoc />
    public bool IsRightAngle { get; }

    /// <summary>
    /// Инициализирует новый экземпляр объекта треугольник.
    /// </summary>
    /// <param name="sideA">Сторона A.</param>
    /// <param name="sideB">Сторона B.</param>
    /// <param name="sideC">Сторона C.</param>
    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        Area = CalculateArea(sideA, sideB, sideC);
        Perimeter = GetPerimeter(sideA, sideB, sideC);
        IsRightAngle = IsTriangleRectangular(sideA, sideB, sideC);
    }

    /// <inheritdoc />
    public double CalculateArea()
        => CalculateArea(SideA, SideB, SideC);

    /// <inheritdoc />
    public double GetMaximumLengthSide()
        => GetMaximumLengthSide(SideA, SideB, SideC);

    /// <inheritdoc />
    public double GetMediumLengthSide()
        => GetMediumLengthSide(SideA, SideB, SideC);

    /// <inheritdoc />
    public double GetMinimumLengthSide()
        => GetMinimumLengthSide(SideA, SideB, SideC);

    /// <summary>
    /// Расчет площади.
    /// </summary>
    /// <param name="sideA">Сторона A.</param>
    /// <param name="sideB">Сторона B.</param>
    /// <param name="sideC">Сторона C.</param>
    /// <returns>Площадь.</returns>
    public static double CalculateArea(double sideA, double sideB, double sideC)
    {
        var halfPerimeter = GetPerimeter(sideA, sideB, sideC) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
    }

    /// <summary>
    /// Получение периметра.
    /// </summary>
    /// <param name="sideA">Сторона A.</param>
    /// <param name="sideB">Сторона B.</param>
    /// <param name="sideC">Сторона C.</param>
    /// <returns>Периметр.</returns>
    public static double GetPerimeter(double sideA, double sideB, double sideC)
    {
        return sideA + sideB + sideC;
    }

    /// <summary>
    /// Вычисление является ли треугольник прямоугольным.
    /// </summary>
    /// <param name="sideA">Сторона A.</param>
    /// <param name="sideB">Сторона B.</param>
    /// <param name="sideC">Сторона C.</param>
    /// <returns>Вернет <see langword="true"/>, если треугольник является прямоугольным, иначе <see langword="false"/>.</returns>
    public static bool IsTriangleRectangular(double sideA, double sideB, double sideC)
    {
        var hypotenuse = GetMaximumLengthSide(sideA, sideB, sideC);
        var legA = GetMediumLengthSide(sideA, sideB, sideC);
        var legB = GetMinimumLengthSide(sideA, sideB, sideC);

        return Math.Abs((hypotenuse * hypotenuse) - (legA * legA + legB * legB)) <= 1e-5;
    }

    /// <summary>
    /// Получение длинной стороны треугольника.
    /// </summary>
    /// <param name="sideA">Сторона A.</param>
    /// <param name="sideB">Сторона B.</param>
    /// <param name="sideC">Сторона C.</param>
    /// <returns>Длинная сторона.</returns>
    public static double GetMaximumLengthSide(double sideA, double sideB, double sideC)
    {
        return sideA > sideB
            ? (sideA > sideC ? sideA : sideC)
            : (sideB > sideC ? sideB : sideC);
    }

    /// <summary>
    /// Получение срредней стороны треугольника.
    /// </summary>
    /// <param name="sideA">Сторона A.</param>
    /// <param name="sideB">Сторона B.</param>
    /// <param name="sideC">Сторона C.</param>
    /// <returns>Средняя сторона.</returns>
    public static double GetMediumLengthSide(double sideA, double sideB, double sideC)
    {
        return sideA < sideB
            ? (sideC < sideA ? sideA : (sideC > sideB ? sideB : sideC))
            : (sideC < sideB ? sideB : (sideC > sideA ? sideA : sideC));
    }

    /// <summary>
    /// Получение короткой стороны треугольника.
    /// </summary>
    /// <param name="sideA">Сторона A.</param>
    /// <param name="sideB">Сторона B.</param>
    /// <param name="sideC">Сторона C.</param>
    /// <returns>Короткая сторона.</returns>
    public static double GetMinimumLengthSide(double sideA, double sideB, double sideC)
    {
        return sideA < sideB
            ? (sideA < sideC ? sideA : sideC)
            : (sideB < sideC ? sideB : sideC);
    }
}
