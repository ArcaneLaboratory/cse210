using System.Numerics;

class Fraction
{
    private int _n, _d;
    public Fraction()
    {
        _n = 1;
        _d = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        _n = numerator;
        _d = denominator;
    }
    
    // public int Numerator
    // {
    //     get{return _numer;}
    // }
    // public int Denominator
    // {
    //     get{return _denom;}
    // }
}