using System;
using System.Reflection;
using CommandLib;

namespace CommandRunner
{
    public static class CommandRunner
    {
        public static void Execute(ICommand command)
        {
            try
            {
                command.Execute();
            }
            catch
            {
                throw new Exception("oh no");
            }
        }
        static void Main() {}
    }
}
