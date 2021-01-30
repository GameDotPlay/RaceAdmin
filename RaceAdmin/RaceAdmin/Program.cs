using iRacingSdkWrapper;
using System;
using System.IO;
using System.CommandLine;
using System.CommandLine.Invocation;
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
                new Option("--source") { Argument = new Argument<string>() }
            };

            command.Handler = CommandHandler.Create(
                (string source) => {
                    ISdkWrapper proxy;

                    if (source.Length > 0)
                    {
                        // replay mode; for now assume just a filename and look for file in documents folder
                        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        BinaryReader reader = new BinaryReader(File.Open(documentsPath + "\\" + source, FileMode.Open));
                        proxy = new SdkReplayProxy(reader);
                    }
                    else
                    {
                        proxy = new SdkWrapperProxy(new SdkWrapper());
                    }

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // create the main form and add a proxy layer between our application and the iRacingSdkWrapper;
                    // this will make it easier for us to add both unit tests and full system tests with wrapper event
                    // replay later
                    RaceAdminMain form = new RaceAdminMain(proxy);

                    Application.Run(form);

                    Console.WriteLine("cleanup");
                    proxy.Stop();
                });

            return command.Invoke(args);

        }
    }
}
