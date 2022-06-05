namespace Legerity.Uno.Infrastructure.Configuration;

using CommandLine;

internal class Options
{
    [Option('i', "input",
        HelpText =
            "The path to the folder where platform pages exist that will be generating page objects for. Default to the executing folder.")]
    public string InputPath { get; set; } = @"C:\S\Personal\MADE\legerity-uno\samples\UnoSampleApp\UnoSampleApp\UnoSampleApp.Shared";

    [Option('o', "output",
        HelpText =
            "The path to the folder where the generated page object files should be stored. Default to the 'Generated' folder in the executing folder.")]
    public string OutputPath { get; set; } = System.IO.Path.Combine(Environment.CurrentDirectory, "Generated");

    [Option('n', "namespace",
        HelpText =
            "The namespace to apply to the output page objects. Default to 'LegerityUnoTests.Pages'.")]
    public string Namespace { get; set; } = "LegerityUnoTests.Pages";
}