public class HandBuilder
{
    // It turns out that efficiently doing this is kinda hard. Working on better options.
    // Ideally I would use a preexisting library, but I haven't been able to get one to work on my system.
    // Another option would be to generate a lookup table to quickly check any hand against...
    public RankedHand GetBestHand(List<Card> lc)
    {
        //Console.WriteLine(lc.Count);
        lc = SortHand(lc);
        int handrank1 = 0;
        int handrank2 = 0;
        var temp = ContainsHighCard(lc);
        var currentBest = temp;
        temp = ContainsPair(lc);
        if (temp.Count == 5)
        {
            currentBest = temp; 
            Console.WriteLine("Found pair");
            handrank1 += 0b1;
            handrank2 = currentBest[0].GetValue() * 1000 + currentBest[2].GetValue()*100 + currentBest[3].GetValue()*10 + currentBest[4].GetValue();
        }
        //Console.WriteLine(lc.Count);    
        temp = ContainsTwoPair(lc);
        if (temp.Count == 5)
        {
            currentBest = temp; 
            Console.WriteLine("Found two pair");
            handrank1 += 0b10;
            handrank2 = currentBest[0].GetValue() * 100 + currentBest[2].GetValue() * 10 + currentBest[4].GetValue();
        } 
        //Console.WriteLine(lc.Count);
        temp = ContainsTrips(lc);
        if (temp.Count == 5)
        {
            currentBest = temp; 
            Console.WriteLine("Found trips");
            handrank1 += 0b100;
            handrank2 = currentBest[0].GetValue() * 100 + currentBest[3].GetValue()*10 + currentBest[4].GetValue(); 
        } 
        //Console.WriteLine(lc.Count);
        temp = ContainsStraight(lc);
        if (temp.Count == 5)
        {
            currentBest = temp; 
            Console.WriteLine("Found straight");
            handrank1 += 0b1000;
            handrank2 = currentBest[0].GetValue();
        } 
        //Console.WriteLine(lc.Count);
        temp = ContainsFlush(lc);
        if (temp.Count == 5)
        {
            currentBest = temp; 
            Console.WriteLine("Found flush");
            handrank1 += 0b10000;
            handrank2 = currentBest[0].GetValue() * 10000 + currentBest[1].GetValue()*1000 + currentBest[2].GetValue() *100 + currentBest[3].GetValue() * 10 + currentBest[4].GetValue();
        } 
        //Console.WriteLine(lc.Count);
        temp = ContainsFullHouse(lc);
        if (temp.Count == 5)
        {
            currentBest = temp; 
            Console.WriteLine("Found full house");
            handrank1 += 0b100000;
            handrank2 = currentBest[0].GetValue() * 100 + currentBest[2].GetValue() * 10 + currentBest[3].GetValue();
        } 
        //Console.WriteLine(lc.Count);
        temp = ContainsQuads(lc);
        if (temp.Count == 5)
        {
            currentBest = temp; 
            Console.WriteLine("Found quads");
            handrank1 += 0b1000000;
            handrank2 = currentBest[0].GetValue() * 10 + currentBest[4].GetValue();
        } 
        //Console.WriteLine(lc.Count);
        temp = ContainsStraightFlush(lc);
        if (temp.Count == 5)
        {
            currentBest = temp; 
            Console.WriteLine("Found straight flush");
            handrank1 += 0b10000000;
            handrank2 = currentBest[0].GetValue();
        }
        handrank1 *= 20000;
        handrank1 += handrank2;
        return new RankedHand(currentBest, handrank1);
    }

    // sort hand by value
    // since this is called before evaluating potential hands, all individual hand eval methods assume an already sorted hand
    public List<Card> SortHand(List<Card> lc)
    {
        lc.Sort((o1, o2) => o2.GetValue().CompareTo(o1.GetValue()));
        return lc;
    }

    // I may need to use these methods elsewhere, so they are public for now, but this may change

    // public List<Card> ContainsRoyalFlush(List<Card> lc)
    // {
    // Turns out this is actually covered by ContainsStraightFlush, who knew 🫠
    // }

    public List<Card> ContainsStraightFlush(List<Card> lc)
    {
        var x = ContainsFlush(lc, lc.Count);
        if(x.Count >= 5)
            return ContainsStraight(ContainsFlush(lc, lc.Count));
        else
            return [];
    }

    public List<Card> ContainsStraight(List<Card> lc)
    {
        List<Card> cards = [];
        for (int i = 0; i <= lc.Count - 5; i++)
        {
            //Console.Write(i);
            List<Card> temp3 = [];
            foreach(Card c in lc)
                temp3.Add(c);
            cards.Add(temp3[i]);
            int val = temp3[i].GetValue();
            for (int j = i + 1; j < temp3.Count; j++)
            {
                if (temp3[j].GetValue() == val)
                {
                    temp3.RemoveAt(j);
                    j--;
                    continue;
                }
                else if (temp3[j].GetValue() < val - 1)
                {
                    cards = [];
                    break;
                }
                else
                {
                    cards.Add(temp3[j]);
                }
                if (cards.Count == 5)
                {
                    return cards;
                }
            }
        }
        return cards;
    }

    public List<Card> ContainsFlush(List<Card> lc, int num = 5)
    {
        int suits = 0000;
        char suit = 'N';
        List<Card> cards = [];
        foreach (Card c in lc)
        {
            switch (c.GetSuit())
            {
                case 'H':
                    suits += 1000;
                    break;
                case 'S':
                    suits += 100;
                    break;
                case 'D':
                    suits += 10;
                    break;
                case 'C':
                    suits++;
                    break;
            }
        }
        if (suits >= 5000)
        {
            suit = 'H';
        }
        suits %= 1000;
        if (suits >= 500)
        {
            suit = 'S';
        }
        suits %= 100;
        if (suits >= 50)
        {
            suit = 'D';
        }
        suits %= 10;
        if (suits >= 5)
        {
            suit = 'C';
        }
        //Console.WriteLine(lc.Count);
        for (int k = 0; k < num; k++)
        {
            //Console.WriteLine(k);
            if (lc[k].GetSuit() == suit)
            {
                cards.Add(lc[k]);
            }
        }
        return cards;
    }

    public List<Card> ContainsQuads(List<Card> lc)
    {
        List<Card> cards = [];
        for (byte i = 14; i >= 2; i--)
        {
            for (int j = 0; j < lc.Count - 3; j++)
            {
                if (lc[j].GetValue() == i)
                {
                    if (lc[j + 1].GetValue() == i)
                    {
                        if (lc[j + 2].GetValue() == i)
                        {
                            if (lc[j + 3].GetValue() == i)
                            {
                                cards.Add(lc[j + 3]);
                                cards.Add(lc[j + 2]);
                                cards.Add(lc[j + 1]);
                                cards.Add(lc[j]);
                                lc.RemoveRange(j, 3);
                                cards.Add(lc[0]);
                                return cards;
                            }
                        }
                    }
                }
            }
        }
        return cards;
    }

    public List<Card> ContainsFullHouse(List<Card> lc)
    {
        List<Card> cards = [];
        for (byte i = 14; i >= 2; i--)
        {
            for (int j = 0; j < lc.Count - 2; j++)
            {
                if (lc[j].GetValue() == i)
                {
                    if (lc[j + 1].GetValue() == i)
                    {
                        if (lc[j + 2].GetValue() == i)
                        {
                            cards.Add(lc[j + 2]);
                            cards.Add(lc[j + 1]);
                            cards.Add(lc[j]);
                            List<Card> temp2 = [];
                            foreach(Card c in lc)
                                temp2.Add(new Card(c.GetSuit(), c.GetValue()));
                            temp2.RemoveRange(j, 3);
                            var t = ContainsPair(temp2);
                            if (t.Count == 5)
                            {
                                cards.Add(t[0]);
                                cards.Add(t[1]);
                                return cards;
                            }
                            else
                            {
                                cards = [];
                            }
                        }
                    }
                }
            }
        }
        return cards;
    }

    public List<Card> ContainsTrips(List<Card> lc)
    {
        List<Card> cards = [];
        for (byte i = 14; i >= 2; i--)
        {
            for (int j = 0; j < lc.Count - 2; j++)
            {
                if (lc[j].GetValue() == i)
                {
                    if (lc[j + 1].GetValue() == i)
                    {
                        if (lc[j + 2].GetValue() == i)
                        {
                            cards.Add(lc[j + 2]);
                            cards.Add(lc[j + 1]);
                            cards.Add(lc[j]);
                            List<Card> temp2 = [];
                            foreach(Card c in lc)
                                temp2.Add(new Card(c.GetSuit(), c.GetValue()));
                            temp2.RemoveRange(j, 3);
                            cards.Add(temp2[0]);
                            cards.Add(temp2[1]);
                            return cards;
                        }
                    }
                }
            }
        }
        return cards;
    }

    public List<Card> ContainsTwoPair(List<Card> lc)
    {
        List<Card> cards = [];
        for (byte i = 14; i >= 3; i--)
        {
            for (int j = 0; j < lc.Count - 1; j++)
            {
                if (lc[j].GetValue() == i)
                {
                    if (lc[j + 1].GetValue() == i)
                    {
                        cards.Add(lc[j + 1]);
                        cards.Add(lc[j]);
                        List<Card> temp2 = [];
                        foreach(Card c in lc)
                            temp2.Add(new Card(c.GetSuit(), c.GetValue()));
                        temp2.RemoveRange(j, 2);
                        var t = ContainsPair(temp2);
                        if (t.Count == 5)
                        {
                            cards.Add(t[0]);
                            cards.Add(t[1]);
                            cards.Add(t[2]);
                            return cards;
                        }
                        else
                        {
                            cards = [];
                        }
                    }
                }
            }
        }
        return cards;
    }

    public List<Card> ContainsPair(List<Card> lc)
    {
        List<Card> cards = [];
        for (byte i = 14; i >= 2; i--)
        {
            //Console.WriteLine($"Checking value {i}");
            for (int j = 0; j < lc.Count - 1; j++)
            {
                if (lc[j].GetValue() == i)
                {
                    if (lc[j + 1].GetValue() == i)
                    {
                        cards.Add(lc[j + 1]);
                        cards.Add(lc[j]);
                        List<Card> temp2 = [];
                        foreach(Card c in lc)
                            temp2.Add(new Card(c.GetSuit(), c.GetValue()));
                        temp2.RemoveRange(j, 2);
                        cards.Add(temp2[0]);
                        cards.Add(temp2[1]);
                        cards.Add(temp2[2]);
                        //Console.WriteLine($"found {i} pair. {cards.Count}");
                        return cards;
                    }
                }
            }
        }
        return cards;
    }

    public List<Card> ContainsHighCard(List<Card> lc)
    {
        return lc.Take(5).ToList(); // since a sorted hand is assumed, simply return first five cards
    }
}
