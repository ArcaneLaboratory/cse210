public class Word
{
    private string _text;
    private bool _isHidden;

    /// <summary>
    /// Initializes a <c>Word</c> with its text as<c><paramref name="word"/></c> and <c>_isHidden</c>as false.
    /// </summary>
    /// <param name="word">the text with which to initialize the word.</param>
    public Word(string word)
    {
        _text = word;
        _isHidden = false;
    }
    public bool GetHidden()
    {
        return _isHidden;
    }
    public void SetHidden(bool hidden)
    {
        _isHidden = hidden;
    }
    public void Display()
    {
        if (_isHidden)
        {
            Console.Write(new string('_', _text.Count()));
        }
        else
        {
            Console.Write(_text);
        }
        Console.Write(" ");
    }
}