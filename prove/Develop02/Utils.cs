/// <summary>
/// A container for simple utility methods for use by various classes in the project as needed.
/// </summary>
public class Utils
{
    /// <summary>
    /// Displays a command-prompt like interface via <c>Utils.GenericPrompt()</c> with a yes or no question on one line, followed by a "> " on the next.
    /// Waits for user input and returns true or false based on their response; true for yes, false for no.
    /// </summary>
    /// <param name="prompt">the yes or no question to display to the user.</param>
    /// <returns><c>GenericPrompt($"{prompt} (y/n)").ToLower().Contains('y')</c></returns>
    public static bool GetYNResponse(string prompt)
    {
        return GenericPrompt($"{prompt} (y/n)").ToLower().Contains('y');
    }
    /// <summary>
    /// Displays a command-prompt like interface with a prompt on one line, followed by a "> " on the next.
    /// Waits for user input and returns it.
    /// </summary>
    /// <param name="prompt">the text to display to the user before taking input.</param>
    /// <returns><c>Console.ReadLine()</c></returns>
    public static string GenericPrompt(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        return Console.ReadLine();
    }
}