﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JettisonClassLibrary
{
	public static class JFLog
	{
		private static string logFile = Environment.GetEnvironmentVariable("AppData") + @"\Jettison\log.txt";

		public static void Log(string type, string msg)
		{
			DateTime time = DateTime.Now;
			string format = "yyyy-MM-dd HH:mm:ss";
			string log = String.Format(@"[{0}] {1} {2}", time.ToString(format), type, msg);
			FileInfo logInfo = new FileInfo(logFile);
			if (File.Exists(logFile)) {
				if (getSizeInMb(logInfo.Length) >= 100) {
					try {
						File.Delete(logFile);
					} catch {
						throw new Exception("Failed to delete the log file.");
					}
					try {
						var l = File.Create(logFile);
						l.Close();
					} catch {
						throw new Exception("Failed to create the log file.");
					}
				}
			} else {
				try {
					using (StreamWriter s = File.AppendText(logFile)) {
						s.WriteLine(log);
					}
				} catch {
					throw new Exception("Failed to write to the log file.");
				}
			}
		}

		private static long getSizeInMb(long size)
		{
			return size / 1024;
		}
	}
}