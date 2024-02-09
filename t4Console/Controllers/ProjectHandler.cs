using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t4Console.Controllers
{
    public class ProjectHandler
    {
        public readonly Process _process;
        public ProjectHandler()
        {
            _process = new Process();
        }
        public int CreateProject(string projectName,string location)
        {
            /*Change directory*/
            _process.StartInfo.WorkingDirectory = location;
            if(!Directory.Exists(location+ "\\" + projectName))           {
                var result = RunCmdCommand("dotnet", $"new mvc -o {projectName}");
                return result;
            }
            return -1;
            
        }
        public int RunCmdCommand(string command, string Arguments)
        {
            _process.StartInfo.FileName = command;

            _process.StartInfo.Arguments = Arguments ;


            // Redirect standard output and error streams
            _process.StartInfo.RedirectStandardOutput = true;
            _process.StartInfo.RedirectStandardError = true;

            // Enable shell execution
            _process.StartInfo.UseShellExecute = false;

            // Handle output data received event
            _process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            _process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);

            // Start the process
            _process.Start();


            // Wait for the process to exit
            _process.WaitForExit();

            // Get the exit code
            int exitCode = _process.ExitCode;

            // Dispose the process
            _process.Dispose();

            // Display the exit code
            /*Console.WriteLine($"Process exited with code {exitCode}");*/


            return exitCode;
        }
    }
}
