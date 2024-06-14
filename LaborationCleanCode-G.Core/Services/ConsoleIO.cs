using LaborationCleanCode_G.Core.Interfaces;

namespace LaborationCleanCode_G.Core.Services;

public class ConsoleIO : IInputOutput
{
    public string Input()
    {
        return Console.ReadLine()!.Trim();
    }

    public void Output(string s)
    {
        Console.WriteLine(s);
    }

    public void Exit()
    {
        Environment.Exit(0);
    }

    public void Clear()
    {
        Console.Clear();
    }
}
