using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace DataAccessLayer
{
	// '' <summary>
	// '' Provide a tracing function that is helpful to debug on DEV, QAT, UAT and LIVE
	// '' With webservice and js script can provide results directly to browser console
	// '' see: D:\code\ELS\Base\Services\CoursesService.asmx.vb
	// '' see: D:\code\ELS\Base\scripts\Helpers\Profiler.js
	// '' </summary>
	public class Tracer
	{
		private static bool Enabled = true;
		private static List<string> Messages = new List<string>();
		public static string ServerPhisycalPath;
		public static string ServerPhisycalPathParent;

		public static void Add(string message)
		{
			if (Enabled)
			{
				MethodBase method = (new StackTrace().GetFrame(1).GetMethod());
				Messages.Add($"{DateTime.Now,-25}{method.ReflectedType.Name,-30} {method.Name,-20} {message,0}");
			}

		}

		public static void ClearTraces()
		{
			if (Enabled)
			{
				Messages.Clear();
			}

		}

		public static List<string> GetTraces()
		{
			if (Enabled)
			{
				List<string> res = new List<string>(new string[] {$"{"DateTime",-25}{"Class",-30} {"method",-20} {"message",0}"});
				res.AddRange(Messages);
				return res;
			}

			return new List<string>(new string[]
			{
				"Trace is disabled. To enable it use \'EnableTrace(true)\' "
			});
		}

		public static void EnableTrace(bool enable)
		{
			Enabled = enable;
		}
	}
}