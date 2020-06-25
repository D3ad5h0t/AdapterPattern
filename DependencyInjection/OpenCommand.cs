using System;

namespace DependencyInjection
{
    public class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening file");
        }
    }
}