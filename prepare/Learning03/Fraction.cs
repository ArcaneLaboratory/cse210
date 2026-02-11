using System.Dynamic;

class Fraction
{
    private int _n,
        _d;

    public Fraction()
    {
        _n = 1;
        _d = 1;
    }

    public Fraction(int whole)
    {
        _n = whole;
        _d = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _n = numerator;
        SetDenominator(denominator);
    }

    public Fraction(Fraction numerator, Fraction denominator)
    {
        _n = numerator._n * denominator._d;
        SetDenominator(numerator._d*denominator._n);
    }

    public int GetNumerator()
    {
        return _n;
    }

    public int GetDenominator()
    {
        return _d;
    }

    public void SetNumerator(int n)
    {
        _n = n;
    }

    public void SetDenominator(int d)
    {
        if (d == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.", nameof(d));
        }
        else
        {
            _d = d;
        }
    }

    public string GetFractionString()
    {
        return $"{_n}/{_d}";
    }

    public double GetDecimalValue()
    {
        return (double)_n / (double)_d;
    }

    public override string ToString()
    {
        return $"String: {GetFractionString()} Decimal: {GetDecimalValue()}";
    }
}
