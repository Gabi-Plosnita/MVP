using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Dictionar.Backend
{
    public class EnglishDictionary
    {
        public Dictionary<string, List<Word>> dictionaryByCategory { get; set; }

        public Dictionary<char, List<Word>> dictionaryByLetter { get; set; }

        public void LoadFromFile(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);

                List<Word> wordsList = JsonConvert.DeserializeObject<List<Word>>(jsonData);

                foreach(Word word in  wordsList )
                {
                    dictionaryByCategory[word.Category].Add(word);
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

    }
}
