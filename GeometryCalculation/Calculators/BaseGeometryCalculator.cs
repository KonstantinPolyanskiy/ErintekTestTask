namespace GeometryCalculator.Calculators;

public static class BaseGeometryCalculator
{
    /// <summary>
    /// Площадь круга по радиусу.
    /// </summary>
    /// <param name="r">Радиус круга.</param>
    /// <returns>Площадь круга.</returns>
    /// <exception cref="ArgumentOutOfRangeException">В случае невалидного значения радиуса.</exception>
    public static double CircleArea(double r)
    {
        if (r < 0
            || double.IsNaN(r)
            || double.IsInfinity(r))
        {
            throw new ArgumentOutOfRangeException(nameof(r), "Радиус должен быть неотрицательным конечным числом.");
        }

        return Math.PI * r * r;
    }

    /// <summary>
    /// Площадь треугольника по трем сторонам.
    /// </summary>
    /// <param name="a">Сторона A.</param>
    /// <param name="b">Сторона B.</param>
    /// <param name="c">Сторона C.</param>
    /// <returns>Площадь треугольника.</returns>
    public static double TriangleArea(double a, double b, double c)
    {
        if (!IsTriangle(a, b, c))
        {
            throw new ArgumentException("Треугольник с такими сторонами недопустим.");
        }

        double p = (a + b + c) / 2;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        return s;
    }

    /// <summary>
    /// Объем шара по его радиусу.
    /// </summary>
    /// <param name="r">Радиус шара.</param>
    /// <returns>Объем шара.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static double SphereVolume(double r)
    {
        if (r < 0 ||
            double.IsNaN(r) ||
            double.IsInfinity(r))
        {
            throw new ArgumentOutOfRangeException(nameof(r), "Радиус должен быть неотрицательным конечным числом.");
        }

        return (4.0 / 3.0) * Math.PI * r * r * r;
    }

    /// <summary>
    /// Вспомогательный метод, контроллирующий, что треугольник с переданными сторонами может существовать.
    /// </summary>
    /// <param name="a">Сторона A.</param>
    /// <param name="b">Сторона B.</param>
    /// <param name="c">Сторона C.</param>
    /// <returns>Может ли такой треугольник существовать.</returns>
    public static bool IsTriangle(double a, double b, double c)
    {
        if (!(a > 0) 
            || !(b > 0) 
            || !(c > 0))
        {
            return false;
        }

        if (!double.IsFinite(a)
            || !double.IsFinite(b)
            || !double.IsFinite(c))
        {
            return false;
        }

        return a + b > c && a + c > b && b + c > a;
    }
}