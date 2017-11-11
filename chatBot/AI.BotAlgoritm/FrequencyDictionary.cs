/*
 * Created by SharpDevelop.
 * User: 01
 * Date: 11.09.2013
 * Time: 17:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace AI.BotAlgoritm
{
	
	public class ProbabilityDictionaryData
	{
		public string Word{get; set;}
		public double Probability{get; set;}
	
	}
	
	/// <summary>
	/// Вероятностный словарь
	/// </summary>
	public class ProbabilityDictionary
	{
		
		
		
		
		
		public ProbabilityDictionaryData[] pDictionary{get; private set;}
		List<ProbabilityDictionaryData> list = new List<ProbabilityDictionaryData>();	
		List<string> Words = new List<string>();
		int n;
		
			// удаление слов не несущих смысла
			static string[] stop =  {"–", "—", "\n", "\t", "\v",""};
			
			/// <summary>
			/// Слова не несущие смысла при стат. анализе
			/// </summary>
			public static string[] StopWords
			{
				get{return stop;}
			}
			
			
		
		
		
		public ProbabilityDictionary(string text)
		{
			GetWords(text);
			Analis();
			list.Sort((a, b) => a.Probability.CompareTo(b.Probability)*-1); // Сортировка массива
			pDictionary = list.ToArray(); // создание массива
		}
		
		
		/// <summary>
		/// Возвращает true если в сторке есть цифры
		/// </summary>
		/// <param name="str">Строка</param>
		public static bool DigialPredickat(string str)
		{
			
			foreach(char ch in str) if(char.IsDigit(ch)||char.IsSeparator(ch)) return true;
				
				return false;
		}
		
		
		/// <summary>
		/// Анализ текста
		/// </summary>
		void Analis()
		{
		
				bool flag;
			
				Words.RemoveAll(DigialPredickat);// Удаление строк с числами
				
			
				
				foreach(string str in stop){
						do
						{
							flag = Words.Remove(str);
						}
						while(flag);
				}
			
			

				flag = false;
				
				
			// Составление словаря	
			while(Words.Count != 0)
			{
				string str = Words[0];
				double count = 0;
				ProbabilityDictionaryData fD = new ProbabilityDictionaryData();
				
				for(int i = 0; i<Words.Count; i++)
				{
					if(Words[i] == str) 
					{
						count ++;
					}
				}
				
				
				fD.Probability = (double)count/(double)n;
				fD.Word = str;
				
				list.Add(fD); // Добавление элемента
				
				
				// Удаление данных
				do
				{
				flag = Words.Remove(str);
				}
				while(flag);
					
			}
			
		}
		
		
		
		
		
		
		
		
		/// <summary>
		/// Переводит частотный словарь в строку
		/// </summary>
		/// <param name="index">До какого индекса</param>
		/// <returns></returns>
		public string ToString(int index)
		{
			string output = "";
			
			int len = (pDictionary.Length<index)? pDictionary.Length:index;
			
			for(int i = 0; i<len; i++)
			{
				output += pDictionary[i].Word+" "+pDictionary[i].Probability+"\n";
			}
			
			return output.Trim();
		}
		
		
		
		
		
		
		
		public void GetWords(string text)
		{
			
			string[] strs = text.ToLower().Replace("\r","").Split(new char[] {' ','\n','\t'});
			n = strs.Length;
			
			// 
			foreach(string str in strs)
				Words.Add(
					str.ToLower().Trim(new char[]{'?','!','.',',',' ', '\t', '(',')'}
				));
		}
		
		
	}
}
