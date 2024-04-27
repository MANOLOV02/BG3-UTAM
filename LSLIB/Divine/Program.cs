﻿using System;
using Divine.CLI;

namespace Divine;

internal class Program
{
    // ReSharper disable once InconsistentNaming
    public static CommandLineArguments argv;

    private static void Main(string[] args)
    {
        System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
        customCulture.NumberFormat.NumberDecimalSeparator = ".";
        System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

        CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser
        {
            IgnoreCase = true,
            ShowUsageOnEmptyCommandline = true
        };

        argv = new CommandLineArguments();

        parser.ExtractArgumentAttributes(argv);

#if !DEBUG
        try
        {
#endif
            parser.ParseCommandLine(args);
#if !DEBUG
        }
        catch (Exception e)
        {
            Console.WriteLine($"[FATAL] {e.Message}");
        }
#endif

        if (parser.ParsingSucceeded)
        {
            CommandLineActions.Run(argv);
        }
    }
}
