using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Dictionar.Backend
{
    public class EnglishDictionary
    {
        public List<Word> ListOfWords {  get; set; }

        public Dictionary<string, List<Word>> dictionaryByCategory { get; set; }

        public Dictionary<char, List<Word>> dictionaryByLetter { get; set; }

        public EnglishDictionary()
        {
            ListOfWords = new List<Word>();
            dictionaryByCategory = new Dictionary<string, List<Word>>();
            dictionaryByLetter = new Dictionary<char, List<Word>>();
        }

        public void LoadFromFile(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);

                List<Word> wordsList = JsonConvert.DeserializeObject<List<Word>>(jsonData);

                foreach(Word word in  wordsList )
                {
                    ListOfWords.Add(word);

                    if (!dictionaryByCategory.ContainsKey(word.Category))
                    {
                        dictionaryByCategory[word.Category] = new List<Word>();
                    }
                    dictionaryByCategory[word.Category].Add(word);

                    if (!dictionaryByLetter.ContainsKey(word.Name[0]))
                    {
                        dictionaryByLetter[word.Name[0]] = new List<Word>();                     
                    }
                    dictionaryByLetter[word.Name[0]].Add(word);
                }

                Console.WriteLine("Data loaded successfully from file.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (JsonException)
            {
                Console.WriteLine("Error deserializing JSON data.");
            }
        }

        public List<string> GetWordListFromCategory(string category)
        {
            List<string> words = new List<string>();
            if (dictionaryByCategory.ContainsKey(category))
            {
                foreach (Word word in dictionaryByCategory[category])
                {
                    words.Add(word.Name);
                }
            }
            else
            {
                foreach (Word word in ListOfWords)
                {
                    words.Add(word.Name);
                }
            }
            return words;
        }

    }
}
