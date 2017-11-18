/*
 * Создано в SharpDevelop.
 * Пользователь: admin
 * Дата: 11.11.2017
 * Время: 0:08
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace AI.BotAlgoritm
{
	/// <summary>
	/// Description of TextClassifier.
	/// </summary>
	public class TextClassifier
	{
		public TextModel textModel;
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="path">путь до файлов для определения класса</param>
		/// 
		public TextClassifier(string path)
		{
			textModel = TextModel.Load(path);
		}
		public int RecognClass(string text)
		{
			int class_ = 0;
			ProbabilityDictionary pd = new ProbabilityDictionary(text);
			double maxProb = CalcProbability(pd, 0);
			
			for(int i = 1; i < textModel.tmds.Length; i++)
			{
				double prob = CalcProbability(pd, i);
				if(maxProb < prob)
				{
					maxProb = prob;
					class_ = i;
				}
			}
			return class_;
		}
		
	    double CalcProbability(ProbabilityDictionary pd, int index)
	    {
			double b = 0.0;
			for (int i = 0; i < pd.pDictionary.Length; i++) {
				b += pd.pDictionary[i].Probability * SearchProb(pd.pDictionary[i].Word, index);
			}
			return b;
		}
	    
	    double SearchProb(string word, int index)
	    {
	    	for(int i =0; i < textModel.tmds[index].pds.Length; i++)
	    		if(word == textModel.tmds[index].pds[i].Word)
	    			return textModel.tmds[index].pds[i].Probability;
	    	
	    	return 0.0;
	    }
	}
}

