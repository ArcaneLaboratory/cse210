public abstract class Shape
{
    protected string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public void SetColor(string c)
    {
        _color = c;
    }

    public string GetColor()
    {
        return _color;
    }

    public abstract double GetArea();
}