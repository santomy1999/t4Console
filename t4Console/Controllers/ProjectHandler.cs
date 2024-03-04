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
           

			// Check if the working directory was changed properly
			if (!Directory.Exists(location) )
			{
				Directory.CreateDirectory(location);
				Console.WriteLine("Created new directory -\t" + location);
			}
			/*Change directory*/
			_process.StartInfo.WorkingDirectory = location;

			if (!Directory.Exists(location+ "\\" + projectName))           {
				Directory.CreateDirectory(location + "\\" + projectName);
				_process.StartInfo.WorkingDirectory = location+ "\\" + projectName;
				var result = RunCmdCommand("dotnet", $"new sln -n {projectName}");
                    result = RunCmdCommand("dotnet", $"new mvc -o {projectName}");
					result = RunCmdCommand("dotnet", $"sln add {projectName}/{projectName}.csproj");
				// Dispose the process
				_process.Dispose();
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

           

            // Display the exit code
            /*Console.WriteLine($"Process exited with code {exitCode}");*/


            return exitCode;
        }
        public int RunScaffoldCmd(List<string> Tables)
        {
			// Path to dotnet.exe
			string dotnetPath = "path/to/dotnet.exe";

			// Scaffold-DbContext command
			string scaffoldCommand = "ef";

			// Arguments for the Scaffold-DbContext command
			string arguments = $"dbcontext scaffold \"server=localhost;database=new_schema;uid=root;password=root\" Pomelo.EntityFrameworkCore.MySql -o Models -c CGDBContext";

			// Create process start info
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = dotnetPath,
				Arguments = $"{scaffoldCommand} {arguments}",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			// Start the process
			using (Process process = Process.Start(startInfo))
			{
				// Read the output and error streams
				string output = process.StandardOutput.ReadToEnd();
				string error = process.StandardError.ReadToEnd();

				// Wait for the process to exit
				process.WaitForExit();

				// Output the result
				Console.WriteLine("Output:");
				Console.WriteLine(output);
				Console.WriteLine("Error:");
				Console.WriteLine(error);
			}
            return 0;
		}
    }
}
