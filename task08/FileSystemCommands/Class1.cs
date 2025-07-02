using CommandLib;
using System;
using System.IO;
using System.Linq;

namespace FileSystemCommands
{
    public class DirectorySizeCommand(string directory) : ICommand
    {
        readonly DirectoryInfo _directory = new(directory);
        public void Execute() => DirectorySize(_directory);
        static long DirectorySize(DirectoryInfo directory)
        {
            if (directory.GetFiles() != null)
                return directory.GetFiles().Sum(file => file.Length);
            else return 0;
        }

    };

    public class FindFilesCommand(string directory, string mask) : ICommand
    {
        readonly DirectoryInfo _directory = new(directory);
        public void Execute()
        {
            if ((_directory.GetFiles() != null) && _directory.Exists)
            {
                FindFiles(_directory, mask);
            }
            else throw new DirectoryNotFoundException("чето пусто");
        }
        static IEnumerable<string> FindFiles(DirectoryInfo directory, string mask)
        {
            foreach (FileInfo file in directory.GetFiles(mask))
            {
                yield return file.Name;
            }
        }
    }
}
