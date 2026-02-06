// Sod Farm Activity
using System.IO;
// TODO:
// 1. Create a Plot class that has the dimensions of a rectangular sod farm plot in feet
// 2. Complete the TODO in Run
// 3. Complete the SavePlot() function
// Stretch Activities
// 1. Add a name to plot
// 2. How would the plots be loaded from file?

namespace SodFarm
{
    // The Plot Class

    public class Plot
    {
        public double length;
        public double width;

        public string name;

        public Plot()
        {
            length = 1;
            width = 1;
            name = "x";
        }

        public Plot(double dim)
        {
            length = dim;
            width = dim;
            name = "x";
        }

        public Plot(double l, double w)
        {
            length = l;
            width = w;
            name = "x";
        }
        public Plot(string n)
        {
            length = 1;
            width = 1;
            name = n;
        }

        public Plot(double dim, string n)
        {
            length = dim;
            width = dim;
            name = n;
        }

        public Plot(double l, double w, string n)
        {
            length = l;
            width = w;
            name = n;
        }

        public double GetArea()
        {
            return length * width;
        }

        override public string ToString()
        {
            return $"Plot {name} : {length} by {width}, {GetArea()} ft^2";
        }
    }

    class PlotManager
    {
        public string _fileName = "sodfarm.txt";

        public List<Plot> _plots = new List<Plot>();

        /// <summary>
        /// Run the program, collecting dimensions for
        /// </summary>
        public void Run()
        {
            Console.Write("Load existing plots? (y/n)");
            if(Console.ReadLine().ToLower() == "y")
            {
                _plots = LoadPlots();
                DisplayPlots();
            }
            do
            {
                Console.Write("Add a plot? (y/n) ");

                if (Console.ReadLine().ToLower() == "n")
                    break;
                try
                {
                    Console.Write("Enter Length (ft): ");
                    double l = double.Parse(Console.ReadLine());
                    Console.Write("Enter Width (ft): ");
                    double w = double.Parse(Console.ReadLine());
                    Console.Write("Enter name:");
                    string n = Console.ReadLine();
                    n = n.Replace(" ", "_");
                    _plots.Add(new Plot(l, w, n));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter numeric values.");
                }
            } while (true);
            // Display Plot list
            DisplayPlots();
            // Display total area
            Console.WriteLine($"Total Area is: {CalculateTotalArea()} ft^2");
            // Save the plots to disk
            SavePlots();
        }

        /// <summary>
        /// Iterate through the plots and calculate the total area
        /// </summary>
        /// <returns></returns>
        public double CalculateTotalArea()
        {
            double totalArea = 0;

            foreach (Plot p in _plots)
            {
                totalArea += p.GetArea();
            }

            return totalArea;
        }

        /// <summary>
        /// Displays all plots, including dimensions and area
        /// </summary>
        public void DisplayPlots()
        {
            if (_plots.Count == 0)
            {
                Console.WriteLine("No plots found.");

                return;
            }

            foreach (Plot p in _plots)
            {
                Console.WriteLine(p.ToString());
            }
        }

        /// <summary>
        /// Writes all plots to a file, one plot per line
        /// Note: _filename is the output file path
        /// </summary>
        public void SavePlots()
        {
            using (StreamWriter file = new StreamWriter(_fileName))
            {
                foreach(Plot p in _plots)
                {
                    file.WriteLine(p.ToString());
                }
            }
        }
        public List<Plot> LoadPlots()
        {
            List<Plot> LPlots = new();
            string[] lines = File.ReadAllLines(_fileName);
            foreach(string line in lines)
            {
                string[] parts = line.Split(" ");
                string name = parts[1];
                double length = double.Parse(parts[3]);
                double width = double.Parse(parts[5]);
                LPlots.Add(new Plot(length, width, name));
            }
            return LPlots;
        }
    }
    class Program
    {
        public static PlotManager pm = new();
        public static void Main(string[] args)
        {
            pm.Run();
        }
    }
}
