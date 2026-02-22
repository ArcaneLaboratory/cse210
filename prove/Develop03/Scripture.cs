public class Scripture
{
    private Reference _reference;
    private List<Word> _text;

    public Scripture(Reference refc, List<Word> words)
    {
        _reference = refc;
        _text = words;
    }

    public void Display(bool hidePunctuation)
    {
        _reference.Display();
        foreach (Word w in _text)
        {
            w.Display(hidePunctuation);
        }
    }

    /// <summary>
    /// Hides three psuedorandomly chosen words not already hidden.
    /// If a word is chosen to be hidden that is already hidden, it will find the next available word to hide.
    /// If there is no word available to hide, it will return false.
    /// Otherwise, returns true.
    /// </summary>
    /// <returns>false if all words are hidden, otherwise true.</returns>
    public bool HideThreeRandomWords()
    {
        Random r = new();
        for (int i = 0; i < 3; i++)
        {
            //Console.WriteLine("Hiding a word");
            int temp = r.Next(0, _text.Count);
            int all = temp;
            while (_text[temp].GetHidden())
            {
                temp += 1;
                temp %= _text.Count;
                if (temp == all)
                {
                    return false;
                }
            }
            _text[temp].SetHidden(true);
        }
        return true;
    }
}
