using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace RegularExpression
{
    class task2
    {
        string textFile = "TextRus.txt";
        string concordance = "Concordance.txt";

        public void DoConcordance()
        {
            Console.WriteLine("Введит количество строк в странице: ");
            int.TryParse(Console.ReadLine(), out int lineInPage);
            FindAllWords(lineInPage);
        }

        void FindAllWords(int lineInPage)
        {
            string line;
            List<string> allWords = new List<string>();
            List<int> locationOfAllWords = new List<int>();
            
            List<int> locationOfWord;

            Regex reg = new Regex(@"\b\w+\b");
            int numOfLine = 1, numOfPage = 1;
            using (StreamReader sr = new StreamReader(textFile, Encoding.Default))
            {
                while ((line = sr.ReadLine())!=null)
                {
                    var matches = reg.Matches(line);
                    foreach (Match item in matches)
                    {
                        allWords.Add(item.ToString().ToLower());
                        locationOfAllWords.Add(numOfPage);
                    }
                    if (numOfLine == lineInPage)
                    {
                        numOfPage++;
                        numOfLine = 0;
                    }
                    numOfLine++;
                }
            }


            int bufNum;
            string word;

            for (int i = 0; i < allWords.Count - 1; i++)
            {
                for (int j = i + 1; j < allWords.Count; j++)
                {

                    if (string.Compare(allWords[i], allWords[j]) == 1)//wordsConcordanceFinal[i] > wordsConcordanceFinal[j])
                    {

                        word = allWords[i];


                        allWords[i] = allWords[j];
                        allWords[j] = word;

                        bufNum = locationOfAllWords[i];
                        locationOfAllWords[i] = locationOfAllWords[j];                                          // Сортировка списка слов и их местанахождений
                        locationOfAllWords[j] = bufNum;
                    }
                }
            }


            char firstLetter = 'а';
            bool isNewLetter = false, isFirstEntry = true;
            while (allWords.Count != 0)
            {
                word = allWords[0];
                locationOfWord = new List<int>(SearchForDuplicateWords(word, allWords, locationOfAllWords));

                if (isFirstEntry)
                {
                    WriteConcordanceWord(word, false, locationOfWord, isFirstEntry);
                    isFirstEntry = false;
                }
                else
                {
                    if (word[0] != firstLetter)
                    {
                        isNewLetter = true;
                        firstLetter = word[0];
                    }
                    WriteConcordanceWord(word, isNewLetter, locationOfWord, isFirstEntry);
                    isNewLetter = false;
                }

            }
        }

        List<int> SearchForDuplicateWords(string word, List<string> listOfAllWords, List<int> location)
        {
            int index;
            List<int> numOfHitsThisWord = new List<int>();
            while (listOfAllWords.Contains(word))
            {
                index = listOfAllWords.IndexOf(word);
                numOfHitsThisWord.Add(location[index]);
                listOfAllWords.RemoveAt(index);
                location.RemoveAt(index);
            }
            return numOfHitsThisWord;
        }
        void WriteConcordanceWord(string word, bool isNewLetter, List<int> location, bool isFirstEntry)
        {

            if (isFirstEntry)
            {
                using (StreamWriter sw = new StreamWriter(File.Open(concordance, FileMode.Create)))
                {
                    sw.Write(word[0].ToString().ToUpper() + "\r\n\r\n");
                    sw.Write(word + "...................................." + location.Count + ":");
                    location = new List<int>(location.Distinct());
                    location.Sort();
                    for (int i = 0; i < location.Count; i++)
                    {
                        sw.Write(location[i] + " ");
                    }
                    sw.Write("\r\n\r\n");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(File.Open(concordance, FileMode.Append)))
                {

                    if (isNewLetter)
                    {
                        sw.Write(word[0].ToString().ToUpper() + "\r\n\r\n");
                    }
                    sw.Write(word + "...................................." + location.Count + ":");
                    location = new List<int>(location.Distinct());
                    location.Sort();
                    for (int i = 0; i < location.Count; i++)
                    {
                        sw.Write(location[i] + " ");
                    }
                    sw.Write("\r\n\r\n");
                }

            }
        }
    }
}
