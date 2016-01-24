using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualcosaConAivEngine
{
	static class Utils
	{
		static Random r = new Random();
		public static int Randomize(int n, int m) => r.Next(n, m);
	}
}
