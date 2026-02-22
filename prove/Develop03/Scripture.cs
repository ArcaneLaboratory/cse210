public class Scripture
{
    private Reference _reference;
    private List<Word> _text;
    private bool _fullyHidden = false;

    public Scripture(Reference refc, List<Word> words)
    {
        _reference = refc;
        _text = words;
    }

    public void Display()
    {
        _reference.Display();
        foreach (Word w in _text)
        {
            w.Display();
        }
    }

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
                    _fullyHidden = true;
                    return true;
                }
            }
            _text[temp].SetHidden(true);
        }
        return false;
    }

    public bool GetHidden()
    {
        return _fullyHidden;
    }
}
