public class Program
{
    static void Main(string[] args)
    {
        List<int> nums = [0, 1, 2, 3, 4, 5, 6];
        nums.RemoveRange(5, nums.Count -5);
        Console.Write(nums.Count);
    }
}