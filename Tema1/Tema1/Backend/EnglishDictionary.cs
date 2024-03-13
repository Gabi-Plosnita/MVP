using System.Collections.Generic;

namespace Dictionar.Backend
{
    public class EnglishDictionary
    {
        public Dictionary<string, List<Word>> dictionaryByCategory {  get; set; }

        public Dictionary<string, List<Word>> dictionaryByLetter { get; set; }



    }
}
