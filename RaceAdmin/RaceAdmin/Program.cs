using iRacingSdkWrapper;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Windows.Forms;

namespace RaceAdmin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            var command = new RootCommand
            {
                // TODO: these should really be subcommands
                new Option(
                    aliases: new[] { "--record", "-r" },
                    description: "Record session updates and telemetry."),
                new Option(
                    aliases: new[] { "--playback", "-p" },
                    description: "Play back events from specified session log.")
                        { Argument = new Argument<string>() },
                new Option(
                    aliases: new[] { "--session", "-s" },
                    description: "Play back only events from the indexed session within the session log.")
                        { Argument = new Argument<int>(getDefaultValue: () => -1) }
            };

            command.AddValidator(r =>
            {
                if (r.Children.Contains("--record") && r.Children.Contains("--playback"))
                {
                    return "Options '--record' and '--playback' cannot be used together.";
                }
                return null;
            });

            command.Handler = CommandHandler.Create(
                (bool record, string playback, int session) =>
                {
                    ISdkWrapper wrapperProxy;

                    if (playback != null && playback.Length > 0)
                    {
                        // replay mode; for now assume just a filename and look for file in documents folder
                        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        BinaryReader reader = new BinaryReader(File.Open(documentsPath + "\\" + playback, FileMode.Open));
                        wrapperProxy = new SdkReplayProxy(reader, session);
                    }
                    else
                    {
                        wrapperProxy = new SdkWrapperProxy(new SdkWrapper(), record);
                    }

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    RaceAdminMain form = new RaceAdminMain(wrapperProxy);
                    Application.Run(form);
                    wrapperProxy.Stop();
                });

            return command.Invoke(args);
        }
    }
}
