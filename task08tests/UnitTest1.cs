namespace task08tests;

using Xunit;
using System;
using FileSystemCommands;
using CommandLib;
using CommandRunner;

// переписал var'ы, т.к по мне без них лучше выглядит и читается
public class FileSystemCommandsTests : IDisposable //интерфейс чтоб удобнее чистить было
{
    private readonly string _testDir;

    public FileSystemCommandsTests()
    {
        _testDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(_testDir);
    }

    public void Dispose()
    {
        if (Directory.Exists(_testDir))
        {
            Directory.Delete(_testDir, true);
        }
    }

    [Fact]
    public void DirectorySizeCommand_ShouldCalculateSize()
    {
        string testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "test1.txt"), "Hello");
        File.WriteAllText(Path.Combine(testDir, "test2.txt"), "World");

        DirectorySizeCommand command = new(testDir);
        command.Execute(); // Проверяем, что не возникает исключений

        Directory.Delete(testDir, true);
    }

    [Fact]
    public void FindFilesCommand_ShouldFindMatchingFiles()
    {
        string testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "file1.txt"), "Text");
        File.WriteAllText(Path.Combine(testDir, "file2.log"), "Log");

        FindFilesCommand command = new FindFilesCommand(testDir, "*.txt");
        command.Execute(); // Должен найти 1 файл

        Directory.Delete(testDir, true);
    }

    [Fact]
    public void DirectorySizeCommand_CalculatesForEmptyDirr()
    {
        DirectorySizeCommand command = new(_testDir);
        Exception exception = Record.Exception(() => command.Execute());
        Assert.Null(exception);
    }

    [Fact]
    public void FindFilesCommand_NoEx_WhenNoFilesMatch()
    {
        FindFilesCommand command = new(_testDir, "*.txt");
        Exception exception = Record.Exception(() => command.Execute());
        Assert.Null(exception);
    }

    [Fact]
    public void FindFilesCommand_Ex_ForNonExistentDirectory()
    {
        string nonExistentDir = Path.Combine(_testDir, "nonexistent");
        FindFilesCommand command = new(nonExistentDir, "*.*");
        Assert.Throws<DirectoryNotFoundException>(() => command.Execute());
    }
}
