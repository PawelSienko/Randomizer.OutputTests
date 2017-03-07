using System;

namespace Randomizer.OutputTests
{
    public interface IConsoleManager
    {
        void PrintHeader();

        void PrintFooter();

        void PrintLine(string line);

        void PrintErrorMsg(string message);

        ConsoleColor ForegroundColor { get; set; }
    }
}