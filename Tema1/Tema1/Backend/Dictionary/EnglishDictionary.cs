using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using Tema1.Backend;

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

        
        public List<string> GetWordListFromLetter(char letter)
        {
            List<string> words = new List<string>();
            if(dictionaryByLetter.ContainsKey(letter))
            {
                foreach(Word word in dictionaryByLetter[letter])
                {
                    words.Add(word.Name);
                }
            }
            return words;
        }

        public List<string> GetAllWords()
        {
            List<string> words = new List<string>();
            foreach (Word word in ListOfWords)
            {
                words.Add(word.Name);
            }
            return words;
        }


        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            categories.Add("All");
            foreach (string category in dictionaryByCategory.Keys)
            {
                categories.Add(category);
            }
            return categories;
        }

        public Word GetWord(string name)
        {
            return ListOfWords.FirstOrDefault(x => x.Name == name);
        }

        
        public void AddWord(string name, string category, string description, string image)
        {
            Word newWord = new Word(name, category, description, image);

            foreach(Word word in ListOfWords)
            {
                if(word.IsEqual(newWord))
                {
                    return;
                }
            }

            ListOfWords.Add(newWord);

            if (!dictionaryByLetter.ContainsKey(name[0]))
            {
                dictionaryByLetter[name[0]] = new List<Word>();
            }
            dictionaryByLetter[name[0]].Add(newWord);

            if(!dictionaryByCategory.ContainsKey(category))
            {
                dictionaryByCategory[category] = new List<Word>();
            }
            dictionaryByCategory[category].Add(newWord);
        }

        public void UpdateWord(string name, string category, string description, string image)
        {
            Word word = ListOfWords.FirstOrDefault(x =>x.Name == name);
            if (word == null)
            {
                return;
            }
            Word updatedWord = new Word(name, category, description, image);
            word.Copy(updatedWord);
        }

        public void DeleteWord(string name, string category, string description, string image)
        {
            Word word = ListOfWords.FirstOrDefault(x => x.Name == name);
            if (word == null)
            {
                return;
            }
            
            ListOfWords.Remove(word);
            dictionaryByCategory[category].Remove(word);
            dictionaryByLetter[name[0]].Remove(word);
        }

        public List<Word> GenerateWords(int numberOfWords)
        {
            List<Word> words = new List<Word>();
            List<Word> ListOfWordsCopy = ListOfWords;
            List<int> positions = new List<int>();

            for (int i = 0; i < numberOfWords; i++)
            {
                positions.Add(i);
            }

            Random random = new Random();

            for (int i = 0; i < numberOfWords; i++)
            {
                int randomPosition = random.Next(0, positions.Count);
                words.Add(ListOfWordsCopy[randomPosition]);
                ListOfWordsCopy.RemoveAt(randomPosition);
            }

            return words;
        }
    }
}
