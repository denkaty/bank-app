using BankApp.LogProviders.Contracts;

namespace BankApp.LogProviders;

public class ConsoleLogProvider : ILogProvider
{
    public void Log()
    {
        Console.WriteLine();
    }
    public void Log(string message, bool newLine = true)
    {
        if (newLine)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.Write(message);
        }
    }

    public void Clear()
    {
        Console.Clear();
    }

    public string? ReadLine()
    {
        string? input = Console.ReadLine();

        return input;
    }
}