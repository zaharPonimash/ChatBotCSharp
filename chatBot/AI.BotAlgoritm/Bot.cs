/*
 * Создано в SharpDevelop.
 * Пользователь: admin
 * Дата: 11.11.2017
 * Время: 0:08
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace AI.BotAlgoritm
{
	/// <summary>
	/// Description of Bot.
	/// </summary>
	public class BotBase
	{
		
		public List<string> baseQA = new List<string>();
		
		public BotBase(string path)
		{
			baseQA.AddRange(File.ReadAllLines(path));
		}
		
		
		public string GetAnswer(string q)
		{
			double[] similar = new double[baseQA.Count/2];
			
			
			for (int i = 0; i < similar.Length; i++)
				similar[i] = TextDataGenerator.GetStringDistance(q, baseQA[2*i]);
			
			int maxInd = 0;
			
			for (int i = 1; i < similar.Length; i++)
				if(similar[maxInd] < similar[i]) maxInd =i;
			
			return baseQA[2*maxInd+1];
		}
		
	}
}
