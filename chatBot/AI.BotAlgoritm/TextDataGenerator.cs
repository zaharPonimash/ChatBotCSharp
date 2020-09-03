/*
 * Создано в SharpDevelop.
 * Пользователь: admin
 * Дата: 10.11.2017
 * Время: 10:12
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace AI.BotAlgoritm
{
	/// <summary>
	/// Description of TextDataGenerator.
	/// </summary>
	public class TextDataGenerator
	{
		public TextDataGenerator()
		{
			
		}
		
		
		public static double GetStringDistance(string str1, string str2)
		{
			string str1N = ObVid(str1);
			string str2N = ObVid(str2);
			return LevenshteinDistance(str1N, str2N);
		}
		
		// Реализация расстояния Левенштейна взята отсюда https://ru.wikibooks.org/wiki/%D0%A0%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D0%B8_%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC%D0%BE%D0%B2/%D0%A0%D0%B0%D1%81%D1%81%D1%82%D0%BE%D1%8F%D0%BD%D0%B8%D0%B5_%D0%9B%D0%B5%D0%B2%D0%B5%D0%BD%D1%88%D1%82%D0%B5%D0%B9%D0%BD%D0%B0#C# 
		static double LevenshteinDistance(string str1,string str2)
		{
			if (str1==null) throw new ArgumentNullException("str1");
			if (str2==null) throw new ArgumentNullException("str2");
			int diff;
			int [,] m = new int[str1.Length+1,str2.Length+1];

			for (int i=0;i<=str1.Length;i++) { m[i,0]=i; }
			for (int j=0;j<=str2.Length;j++) { m[0,j]=j; }

			for (int i=1;i<=str1.Length;i++) {
				for (int j=1;j<=str2.Length;j++)
				{
					diff=(str1[i-1]==str2[j-1])?0:1;

					m[i,j]=Math.Min(Math.Min(m[i-1,j]+1,
					                         m[i,j-1]+1),
					                         m[i-1,j-1]+diff);
				}
                        }
			return 1.0/(1+2*(double)m[str1.Length,str2.Length]/(double)(str1.Length+str2.Length));
		}
		
		
		static string ObVid(string inp)
		{
			string output = inp.ToLower();
			string[] trowsim = {".",",","!","&","?",")","(","1","2","3","4","5","6","7","8",
				"9","0","-",":",";","{","}","[","]","&","*","^","%","#"};
			
			foreach (var element in trowsim)
				output = output.Replace(element, "");
			
			return output;
		}
		
		
	}
}
