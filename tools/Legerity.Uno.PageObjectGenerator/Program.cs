namespace Legerity.Uno;

using CommandLine;
using Features.Generator;
using Infrastructure.Configuration;
using Infrastructure.Logging;
using Serilog;

public class Program
{
    public static void Main(string[] args)
    {
        SerilogConfigurator.ConfigureLogging();
        Parser.Default.ParseArguments<Options>(args)
            .WithNotParsed(errors =>
            {
                foreach (Error? error in errors)
                {
                    if (error.Tag == ErrorType.MissingRequiredOptionError)
                    {
                        Log.Error("Missing required option: {0}", error.ToString());
                    }
                }
            })
            .WithParsedAsync(async options =>
            {
                Log.Information($"Locating XAML page files in {options.InputPath}...");

                if (!Directory.Exists(options.OutputPath))
                {
                    Directory.CreateDirectory(options.OutputPath);
                }
                
                await new XamlPageObjectGenerator().GenerateAsync(options.Namespace, options.InputPath, options.OutputPath);

                Log.Information("Finished generating Legerity for Uno Platform page objects!");
            });
    }
}