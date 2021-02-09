using iRacingSdkWrapper;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RaceAdmin
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int AttachParentProcess = -1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                AttachConsole(AttachParentProcess);
            }

            var command = new RootCommand
            {
                Handler = CommandHandler.Create(() =>
                {
                    Run(new SdkWrapperProxy(new SdkWrapper(), record: false));
                })
            };

            Command record = new Command(
                name: "record",
                description: "Record session updates and telemetry.")
            {
                Handler = CommandHandler.Create(() =>
                {
                    Run(new SdkWrapperProxy(new SdkWrapper(), record: true));
                })
            };
            command.AddCommand(record);

            Command playback = new Command(
                name: "playback",
                description: "Play back only events from the indexed session within the session log.")
            {
                new Argument<string>(
                    name: "logfile",
                    description: "The RaceAdmin session log file to play back."),
                new Option(
                    aliases: new[] { "--session", "-s" },
                    description: "Play back only events from the indexed session within the session log.")
                {
                    Argument = new Argument<int>(getDefaultValue: () => -1)
                }
            };
            playback.Handler = CommandHandler.Create((string logfile, int session) =>
            {
                // for now assume just a filename and look for file in documents folder
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                BinaryReader reader = new BinaryReader(File.Open(documentsPath + "\\" + logfile, FileMode.Open));
                Run(new SdkReplayProxy(reader, session));
            });
            command.AddCommand(playback);

            return command.Invoke(args);
        }

        private static void Run(ISdkWrapper wrapper)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RaceAdminMain form = new RaceAdminMain(wrapper);
            Application.Run(form);
            wrapper.Stop();
        }
    }

}
