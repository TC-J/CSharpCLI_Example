using System.CommandLine;

namespace cscli;

class Program
{
    static int Main(string[] argv)
    {
        /*
            Program Root Command.
        */
        var program = new RootCommand("Display a file.");

        /*
            Create Options.
        */
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "File to display."
        );

        /*
            Add Options.
        */
        program.AddOption(fileOption);

        /*
            Set Command Handlers.
        */
        program.SetHandler((file) =>
        {
            DisplayFile(file!);
        }, fileOption);


        /*
            Invoke CLI.
        */
        return program.Invoke(argv);
    }

    static void DisplayFile(FileInfo file)
    {
        File.ReadLines(file.FullName).ToList()
        .ForEach(line => Console.WriteLine(line));
    }
}