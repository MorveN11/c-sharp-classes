public struct Coordinate
{
    private readonly double _x;
    private readonly double _y;

    public Coordinate(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public double DistanceTo(Coordinate other)
    {
        return System.Math.Sqrt(
            System.Math.Pow(_x - other._x, 2) + System.Math.Pow(_y - other._y, 2)
        );
    }

    public double AngleTo(Coordinate other)
    {
        return System.Math.Atan2(other._y - _y, other._x - _x);
    }

    public override string ToString()
    {
        return $"({_x}, {_y})";
    }
}
