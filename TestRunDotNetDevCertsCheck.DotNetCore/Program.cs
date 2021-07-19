using System;
using System.Diagnostics;

namespace TestRunDotNetDevCertsCheck.DotNetCore
{
	class Program
	{
		public static void Main (string[] args)
		{
			try {
				Run ();
			} catch (Exception ex) {
				Console.WriteLine (ex);
			}
		}

		/// <summary>
		/// This works fine.
		/// </summary>
		static void Run ()
		{
			using (var process = new Process ()) {

				var info = new ProcessStartInfo ();
				info.FileName = "/usr/local/share/dotnet/dotnet";
				info.Arguments = "dev-certs https --trust --check";

				process.StartInfo = info;
				process.Start ();
				process.WaitForExit ();

				int exitCode = process.ExitCode;
				Console.WriteLine (exitCode);
			}
		}
	}
}
