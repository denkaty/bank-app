namespace BankApp.LogProviders.Contracts;

public interface ILogProvider
{
    void Log();
    void Log(string message, bool newLine = true);
    void Clear();
    string ReadLine();
}