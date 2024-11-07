namespace Shape.Test;

[TestFixture]
internal class TriangleTest
{
    private const double Inaccuracy = 1e-5;

    [TestCase(6, 3, 4, 5)]
    [TestCase(8.255073783399824, 3.56, 5.28, 7.65)]
    [TestCase(2677.901125415201, 96, 58, 125)]
    public void CalculateAreaTest(double expected, double sideA, double sideB, double sideC)
    {
        var actual = new Triangle(sideA, sideB, sideC).CalculateArea();
        Assert.That(Math.Abs(actual - expected), Is.LessThanOrEqualTo(Inaccuracy));
    }

    [TestCase(50, 12, 6, 32)]
    [TestCase(37.45606, 11.56, 16.896, 9.00006)]
    [TestCase(387.5009, 125.9657, 86.3698, 175.1654)]
    public void GetPerimeterTest(double expected, double sideA, double sideB, double sideC)
    {
        var actual = new Triangle(sideA, sideB, sideC).Perimeter;
        Assert.That(Math.Abs(actual - expected), Is.LessThanOrEqualTo(Inaccuracy));
    }

    [TestCase(true, 3, 4, 5)]
    [TestCase(true, 6, 8, 10)]
    [TestCase(true, 42.17548102867352, 23.568, 34.976)]
    [TestCase(true, 44.96856009480401, 36.751, 25.914)]
    [TestCase(false, 2, 8, 9)]
    [TestCase(false, 6, 7, 1)]
    public void IsTriangleRectangularTest(bool expected, double sideA, double sideB, double sideC)
    {
        var actual = new Triangle(sideA, sideB, sideC).IsRightAngle;
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(6, 6, 5, 3)]
    [TestCase(9, 6, 5, 9)]
    [TestCase(12, 6, 12, 3)]
    [TestCase(12, 6, 12, 12)]
    public void GetMaximumLengthSideTest(double expected, double sideA, double sideB, double sideC)
    {
        var actual = new Triangle(sideA, sideB, sideC).GetMaximumLengthSide();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(8, 12, 8, 6)]
    [TestCase(8, 6, 12, 8)]
    [TestCase(8, 6, 8, 12)]
    [TestCase(8, 6, 8, 8)]
    public void GetMediumLengthSideTest(double expected, double sideA, double sideB, double sideC)
    {
        var actual = new Triangle(sideA, sideB, sideC).GetMediumLengthSide();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(6, 12, 8, 6)]
    [TestCase(6, 6, 12, 8)]
    [TestCase(6, 6, 8, 12)]
    [TestCase(6, 6, 8, 8)]
    public void GetMinimumLengthSideTest(double expected, double sideA, double sideB, double sideC)
    {
        var actual = new Triangle(sideA, sideB, sideC).GetMinimumLengthSide();
        Assert.That(actual, Is.EqualTo(expected));
    }
}
