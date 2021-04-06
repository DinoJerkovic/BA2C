using System;
using System.Linq;
using System.Collections.Generic;

namespace BA2C
{
	class Program
	{
		public static string ProfileProbable(string text, int k, decimal[,]matrix)
		{
			List<decimal> lista = new List<decimal>();
			for (int i = 0; i < text.Length - k+1; i++)
			{
				string s = text.Substring(i, k);
				decimal suma = 1;
				for (int j = 0; j < s.Length; j++)
				{
					if (s.Substring(j, 1) == "A")
						suma *= matrix[0, j];
					if (s.Substring(j, 1) == "C")
						suma *= matrix[1, j];
					if (s.Substring(j, 1) == "G")
						suma *= matrix[2, j];
					if (s.Substring(j, 1) == "T")
						suma *= matrix[3, j];
				}
				lista.Add(suma);
			}
			decimal max = lista.Max();
			string r = "";
			for (int i = 0; i < lista.Count; i++)
			{
				if (lista[i] == max)
				{
					r= text.Substring(i, k);
					break;
					
				}
			}
			return r;

		}
		static void Main(string[] args)
		{
			int k = 5;
			decimal[,] matrix = new decimal[4, k];
			matrix[0, 0] = (decimal)0.2;
			matrix[0, 1] = (decimal)0.2;
			matrix[0, 2] = (decimal)0.3;
			matrix[0, 3] = (decimal)0.2;
			matrix[0, 4] = (decimal)0.3;
			matrix[1, 0] = (decimal)0.4;
			matrix[1, 1] = (decimal)0.3;
			matrix[1, 2] = (decimal)0.1;
			matrix[1, 3] = (decimal)0.5;
			matrix[1, 4] = (decimal)0.1;
			matrix[2, 0] = (decimal)0.3;
			matrix[2, 1] = (decimal)0.3;
			matrix[2, 2] = (decimal)0.5;
			matrix[2, 3] = (decimal)0.2;
			matrix[2, 4] = (decimal)0.4;
			matrix[3, 0] = (decimal)0.1;
			matrix[3, 1] = (decimal)0.2;
			matrix[3, 2] = (decimal)0.1;
			matrix[3, 3] = (decimal)0.1;
			matrix[3, 4] = (decimal)0.2;
			string text = "ACCTGTTTATTGCCTAAGTTCCGAACAAACCCAATATAGCCCGAGGGCCT";
			string s = ProfileProbable(text, k, matrix);
			Console.WriteLine(s);
			Console.WriteLine("kraj");
		}
	}
}
