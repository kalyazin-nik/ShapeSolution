namespace Shape.Interfaces;

/// <summary>
/// Интерфейс геометрических фигур.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Расчет площади.
    /// </summary>
    /// <returns>Площадь.</returns>
    double CalculateArea();
}
