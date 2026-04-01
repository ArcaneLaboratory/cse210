public class ChipStack
{
    private string _color; // maybe don't need this? depends on if I have tiem for graphics or just go text-based
    private int _value;
    private int _quantity;

    public ChipStack(string c, int v, int q)
    {
        _color = c;
        _value = v;
        _quantity = q;
    }

    public string GetColor()
    {
        return _color;
    }

    public int GetValue()
    {
        return _value;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public int GetStackValue()
    {
        return _value * _quantity;
    }
}