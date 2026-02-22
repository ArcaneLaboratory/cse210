public class Reference
{
    private string _book;
    private int _chapter;
    private string _verses;

    // These constructors provided as per requirements, though only the fourth is used or needed.
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

    /// <summary>
    /// Initializes a Reference with its book, chapter, and span of verses in text format.
    /// </summary>
    /// <param name="book">the name of the scripture reference's book</param>
    /// <param name="chapter">the number of the scripture reference's chapter</param>
    /// <param name="verses">the text format of the span of verses of the reference, e.g. "2, 4-7" </param>
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
