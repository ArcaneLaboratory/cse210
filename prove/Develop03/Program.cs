using System.Diagnostics;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = [];
        string[] lines;
        Random rand = new();
        try
        {
            lines = File.ReadAllLines("scriptures.txt");
        }
        catch (FileNotFoundException)
        {
            using StreamWriter file = new("scriptures.txt");
            file.WriteLine("Proverbs 3:5-6");
            file.WriteLine(
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            );
            file.WriteLine(" ");
            file.WriteLine("James 1:5-6");
            file.WriteLine(
                "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tossed."
            );
            file.WriteLine(" ");
            file.WriteLine("Mosiah 2:17");
            file.WriteLine(
                "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."
            );
            file.WriteLine(" ");
            file.WriteLine("D&C 11:3-4, 27");
            file.WriteLine(
                "Behold, the field is white already to harvest; therefore, whoso desireth to reap let him thrust in his sickle with his might, and reap while the day lasts, that he may treasure up for his soul everlasting salvation in the kingdom of God. Yea, whosoever will thrust in his sickle and reap, the same is called of God. Behold, I speak unto all who have good desires, and have thrust in their sickle to reap."
            );
            file.WriteLine(" ");
            file.Close();
            lines = File.ReadAllLines("scriptures.txt");
        }
        for (int i = 0; i < lines.Length; i += 3)
        {
            //Console.WriteLine($"{i}, {lines.Length}");
            string r = lines[i];
            string[] rs = r.Split(":");
            string verses = rs[1];
            int chapter = int.Parse(rs[0].Split(" ").LastOrDefault());
            string book = String.Concat(rs[..^1]);
            string[] text = lines[i + 1].Split(" ");
            List<Word> words = [];
            foreach (string word in text)
            {
                words.Add(new Word(word));
            }
            scriptures.Add(new Scripture(new Reference(book, chapter, verses), words));
        }
        Scripture s = scriptures[rand.Next(0, scriptures.Count)];
        s.Display();
        while ((!Utils.PromptOrEnter("\nPress enter to continue or type \"quit\" to finish", "quit")) && !s.HideThreeRandomWords())
        {
            Console.Clear();
            s.Display();
        }
    }
}
