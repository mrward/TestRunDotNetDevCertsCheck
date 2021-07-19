﻿//
// Program.cs
//
// Author:
//       Matt Ward <matt.ward@microsoft.com>
//
// Copyright (c) 2021 Microsoft Corporation
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Diagnostics;

namespace TestRunDotNetDevCertsCheck
{
	class MainClass
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
		/// This never gets passed WaitForExit. dotnet process runs at 100% CPU
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