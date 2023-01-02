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
            Define Options For Commands.
        */
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "File to display."
        );

        /*
            Define Sub-Commands.
        */
        var subcmdA = new Command("A", "Sub-Command A");
        var subcmdB = new Command("B", "Sub-Command B");
        var subcmdC = new Command("C", "Sub-Command C");
        var nestedSubcmdD = new Command("D", "Nested Sub-Command D");

        /*
            Bind Options & Nested Sub-Commands To Commands. 
        */
        // option must be bound to the nested command before the
        // before the nested-subcommand is bound to its parent
        // command.
        nestedSubcmdD.AddOption(fileOption);
        subcmdA.AddCommand(nestedSubcmdD);
        // binding the commands to the program. This happens after the
        // options have been bound to the subcommands.
        program.AddCommand(subcmdA);
        program.AddCommand(subcmdB);
        program.AddCommand(subcmdC);

        /*
            Set Command Handlers.
        */

        subcmdA.SetHandler(() =>
        {
            DemoExplain();
        });

        subcmdB.SetHandler(() =>
        {
            DemoExplain();
        });

        subcmdC.SetHandler(() =>
        {
            DemoExplain();
        });

        // the option variables go after the lambda is defined.
        nestedSubcmdD.SetHandler((file) =>
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

    static void DemoExplain()
    {
        Console.WriteLine("\n\t\tDisplay a file by running:");
        Console.WriteLine("<executable> A D --file <file>\n");
    }
}