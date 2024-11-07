namespace Shape.Test;

[TestFixture]
internal class CircleTest
{
    private const double Inaccuracy = 1e-5;

    [TestCase(-1)]
    [TestCase(-Inaccuracy)]
    [TestCase(default(double))]
    public void ThrowingExceptionByZeroOrNegativeRadiusTest(double radius)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
    }

    [TestCase(Math.PI, 1)]
    [TestCase(12.566370614359172, 2)]
    [TestCase(201.06192982974676, 8)]
    [TestCase(820.4130984772987, 16.16)]
    public void AreaTest(double expected, double radius)
    {
        var actual = new Circle(radius).Area;
        Assert.That(Math.Abs(actual - expected), Is.LessThanOrEqualTo(Inaccuracy));
    }

    [TestCase(Math.Tau, 1)]
    [TestCase(12.566370614359172, 2)]
    [TestCase(100.53096491487338, 16)]
    [TestCase(157.07963267948966, 25)]
    public void CircumferenceTest(double expected, double radius)
    {
        var actual = new Circle(radius).Circumference;
        Assert.That(Math.Abs(actual - expected), Is.LessThanOrEqualTo(Inaccuracy));
    }

    [TestCase(5.45415391248228, 5, -25f)]
    [TestCase(4.1887902047863905, 4, -30f)]
    [TestCase(14.144697827436913, 11.36, 12.56f)]
    [TestCase(0.04487911154804826, 1.256, 3.26f)]
    [TestCase(76.420784225481, 11.36, 67.859f)]
    [TestCase(0, 3, 0f)]
    [TestCase(14.137166941154067, 3, 540f)]
    public void SectorAreaByDegreesTest(double expected, double radius, float angle)
    {
        var actual = new Circle(radius).GetSectorArea(angle);
        Assert.That(Math.Abs(actual - expected), Is.LessThanOrEqualTo(Inaccuracy));
    }

    [TestCase(1, 2, -0.5)]
    [TestCase(2, 2, -1d)]
    [TestCase(12.738207743999999, 3.456, 2.133)]
    [TestCase(15.1104, 4, 1.8888)]
    [TestCase(0, 3, 0d)]
    [TestCase(14.137166941154067, 3, 9.42477796076938)]
    public void SectorAreaByRadiansTest(double expected, double radius, double angle)
    {
        var actual = new Circle(radius).GetSectorArea(angle);
        Assert.That(Math.Abs(actual - expected), Is.LessThanOrEqualTo(Inaccuracy));
    }

    [TestCase(true, 2, Math.PI, 180f)]
    [TestCase(false, 12, Math.PI, 180.00001f)]
    public void SectorAreaByRadiansCompareToSectorAreaByDegreesTest(bool expected, double radius, double radiansAngle, float degreesAngle)
    {
        var circle = new Circle(radius);
        var actual = Math.Abs(circle.GetSectorArea(radiansAngle) - circle.GetSectorArea(degreesAngle)) <= Inaccuracy;
        Assert.That(actual, Is.EqualTo(expected));
    }
}
