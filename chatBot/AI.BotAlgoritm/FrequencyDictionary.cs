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
	
	public class FrequencyDictionaryStruct
	{
		public string word;
		public double frequency;
	
	}
	
	/// <summary>
	/// Частотный/вероятностный словарь
	/// </summary>
	public class FrequencyDictionary
	{
		
		
		
		
		
		public FrequencyDictionaryStruct[] fDictionary;
		List<FrequencyDictionaryStruct> list = new List<FrequencyDictionaryStruct>();	
		List<string> words = new List<string>();
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
			
			
		
		
		
		public FrequencyDictionary(string text)
		{
			GetWords(text);
			Analis();
			list.Sort((a, b) => a.frequency.CompareTo(b.frequency)*-1); // Сортировка массива
			fDictionary = list.ToArray(); // создание массива
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
			
				words.RemoveAll(DigialPredickat);// Удаление строк с числами
				
			
				
				foreach(string str in stop){
						do
						{
							flag = words.Remove(str);
						}
						while(flag);
				}
			
			

				flag = false;
				
				
			// Составление словаря	
			while(words.Count != 0)
			{
				string str = words[0];
				double count = 0;
				FrequencyDictionaryStruct fD = new FrequencyDictionaryStruct();
				
				for(int i = 0; i<words.Count; i++)
				{
					if(words[i] == str) 
					{
						count ++;
					}
				}
				
				
				fD.frequency = count;
				fD.word = str;
				
				list.Add(fD); // Добавление элемента
				
				
				// Удаление данных
				do
				{
				flag = words.Remove(str);
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
			
			int len = (fDictionary.Length<index)? fDictionary.Length:index;
			
			for(int i = 0; i<len; i++)
			{
				output += fDictionary[i].word+" ";
			}
			
			return output.Trim();
		}
		
		
		
		
		public void GetWords(string text)
		{
			
			string[] strs = text.ToLower().Replace("\r","").Split(new char[] {' ','\n','\t'});
			n = strs.Length;
			
			// 
			foreach(string str in strs)
				words.Add(
					str.ToLower().Trim(new char[]{'?','!','.',',',' ', '\t', '(',')'}
				));
		}
		
		
	}
}
