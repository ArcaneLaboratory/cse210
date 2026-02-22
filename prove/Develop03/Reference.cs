using System.ComponentModel;
using System.Net;

public class Reference
{
    private string _book;
    private int _chapter;
    private string _verses;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verses = verse.ToString();
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verses = $"{verseStart}-{verseEnd}";
    }

    public Reference(string book, int chapter, List<int> verses)
    {
        _book = book;
        _chapter = chapter;
        _verses = "";
        if (!(verses.Count == 1))
        {
            // this code adapted from DesiChoza
            // https://stackoverflow.com/a/20612877
            int temp;

            for (int i = 0; i < verses.Count; i++)
            {
                temp = verses[i];

                //add a number
                _verses += verses[i];

                //skip number(s) between a range
                while (i < verses.Count - 1 && verses[i + 1] == verses[i] + 1)
                    i++;

                //add the range
                if (temp != verses[i])
                    _verses += "-";
                    _verses += verses[i];

                //add comma
                if (i != verses.Count - 1)
                    _verses += ", ";
            }
        }
        else
        {
            _verses = verses[0].ToString();
        }
    }
    public Reference(string book, int chapter, string verses)
    {
        _book = book;
        _chapter = chapter;
        _verses = verses;
    }

    public override string ToString()
    {
        return $"{_book} {_chapter}:{_verses}";
    }

    public void Display()
    {
        Console.WriteLine(ToString());
    }
}
