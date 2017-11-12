/*
 * Создано в SharpDevelop.
 * Пользователь: admin
 * Дата: 10.11.2017
 * Время: 10:11
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.IO;
using System.Globalization;

namespace AI.BotAlgoritm
{
	
	/// <summary>
	/// Модель текста
	/// </summary>
	public class TextModel
	{
		
		readonly string[] _paths;
		public TextModelData[] tmds{get; protected set;}
		
		
		
		/// <summary>
		/// Модель
		/// </summary>
		/// <param name="path">Путь до текстовых файлов(файл на класс)</param>
		public TextModel(string path)
		{
			_paths = Directory.GetFiles(path, "*.txt");
			GenerateModels();
		}
		
		public TextModel(TextModelData[] data, string[] paths)
		{
			tmds = data;
			_paths = paths;
		}
		
		//Загрузка
		public static TextModel Load(string path)
		{
			string[] paths = Directory.GetFiles(path, "*.model");
			
			
			TextModelData[] tmds2 = new TextModelData[paths.Length];
			
			for (int i = 0; i < paths.Length; i++) 
			{
				tmds2[i] = new TextModelData();
				tmds2[i].LoadData(paths[i]);
			}
			
			return new TextModel(tmds2, paths);
		}
		
		// Сохранение
		public void Save(string pathDirectory)
		{
			
			string path;
			string[] pathData;
			
			
			for (int i = 0; i < _paths.Length; i++) 
			{
				pathData = _paths[i].Split('\\');
				pathData = pathData[pathData.Length-1].Split('.');
				path = pathDirectory +"\\"+ pathData[pathData.Length-2]+".model";
				tmds[i].SaveData(path);
			}
		}
		
		/// <summary>
		/// Генерирование моделей
		/// </summary>
		void GenerateModels()
		{
			ProbabilityDictionary[] pD = new ProbabilityDictionary[_paths.Length];	
			tmds = new TextModelData[pD.Length];
			
			for (int i = 0; i < _paths.Length; i++)
			{
				tmds[i] = new TextModelData();
				tmds[i].pds = (new ProbabilityDictionary(File.ReadAllText(_paths[i]))).pDictionary;
			}
				
		}
		
		
		
		
		
	}
	
	
	public class TextModelData
	{
		public ProbabilityDictionaryData[] pds{get; set;}
		
		
		
		
		
		
		
		public void LoadData(string path)
		{
			string[] data =  File.ReadAllLines(path), wordAndProb;
			pds = new ProbabilityDictionaryData[data.Length];
			
			NumberFormatInfo provider = new NumberFormatInfo();
			provider.NumberDecimalSeparator = ",";
			provider.NumberGroupSeparator = ".";
			provider.NumberGroupSizes = new int[] { 3 };
			
			
			
			for (int i = 0; i < data.Length; i++)
			{
				wordAndProb = data[i].Split();
				pds[i] = new ProbabilityDictionaryData();
				pds[i].Word = wordAndProb[0];
				pds[i].Probability = Convert.ToDouble(wordAndProb[1], provider);
			}
		}
		
	
		public void SaveData(string path)
		{
			File.WriteAllLines(path, ToStringArray());
		}
		
		string[] ToStringArray()
		{
			int len = pds.Length;
			string[] output = new string[len];
			
			for(int i = 0; i<len; i++)
			{
				output[i] = pds[i].Word+" "+pds[i].Probability;
			}
			
			return output;
		}
		
		
	}
}
