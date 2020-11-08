using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace RegularExpression
{
    class task1
    {
        public string Task1()
        {
            string line = "Глубокая тьма, в которой все неподвижно. Как кучка серых притаившихся мышей, смутно намечаются серые силуэты Старух в странных покрывалах и очертания большой высокой комнаты. Тихими голосами, пересмеиваясь, Старухи ведут беседу.";
            Console.WriteLine(line+"\n");
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine();
            Regex regex = new Regex(@"\b" + word + @"\b", RegexOptions.IgnoreCase);
            if (regex.IsMatch(line))
            {
                return word+" cодержится.";
            }
            return word + " не содержится.";
        }
        public void Task2()
        {
            string line = "Глубокая тьма, в которой все неподвижно. Как кучка серых притаившихся мышей, смутно намечаются серые силуэты Старух в странных покрывалах и очертания большой высокой комнаты. Тихими голосами, пересмеиваясь, Старухи ведут беседу.";
            Console.WriteLine(line + "\n");
            Console.WriteLine("Введите длину слова: ");
            int.TryParse(Console.ReadLine(), out int num);
            Regex regex = new Regex(@"\b(\w){4}\b");
            Match wordRegex = regex.Match(line);
            while (wordRegex.Success)
            {
                Console.WriteLine(wordRegex);
                wordRegex = wordRegex.NextMatch();
            }
        }
        public void Task3()
        {
            string line = "Глубокая тьма, в которой все неподвижно. Как кучка серых притаившихся мышей, смутно намечаются серые силуэты Старух в странных покрывалах и очертания большой высокой комнаты. Тихими голосами, пересмеиваясь, Старухи ведут беседу.";
            Console.WriteLine(line + "\n");
            line = Regex.Replace(line, @"\b\w\b", "");
            line = Regex.Replace(line, @"\s+", " ");
            Console.WriteLine(line);

        }
        public void Task4()
        {
            string line = "Глубокая тьма, в которой все неподвижно. Как кучка серых притаившихся мышей, смутно намечаются серые силуэты Старух в странных покрывалах и очертания большой высокой комнаты. Тихими голосами, пересмеиваясь, Старухи ведут беседу.";
            Console.WriteLine(line + "\n");
            line = Regex.Replace(line, @"\b[уеыаоэяию][а-яё]+\b", "", RegexOptions.IgnoreCase);
            Console.WriteLine(line + "\n");

        }
        public void Task5()
        {
            string line = "Глубокая тьма, в которой все неподвижно. Как кучка серых притаившихся mouses, смутно намечаются серые силуэты Старух в странных покрывалах и очертания большой высокой комнаты. Тихими голосами, пересмеиваясь, Старухи ведут беседу.";
            Console.WriteLine(line + "\n");
            line = Regex.Replace(line, @"[a-zA-Z]+", "...", RegexOptions.IgnoreCase);
            Console.WriteLine(line + "\n");
        }
        public void Task6()
        {
            string line = "5 плюс 6 это будет равно 11 , и если это умножить на 100, то будет 11000";
            Console.WriteLine(line + "\n");
            var matches = Regex.Matches(line, @"[-+]?\d+(?:\.\d+)?(?:[eE][-+]?\d+)?");
            double sum = 0;
            foreach (Match item in matches)
            {
                sum += double.Parse(item.Value);
            }
            Console.WriteLine(sum + "\n");
        }
        public void Task7()
        {
            List<string> phoneNumber = new List<string>();
            string line = "Мой номер: 12-12-12, а номеру моего друга это 321-857, а у его друга - 521-54-87, а у врага того друга 12-342-12.";
            Console.WriteLine(line + "\n");
            var result = Regex.Matches(line, @"\d{3}-\d{3}|\d{2,3}-\d{2}-\d{2}");
            foreach (var item in result)
            {
                Console.WriteLine(phoneNumber);
            }
        }
        public void Task8()
        {
            string line = "22.11.2020, в этот день родился Иван. Катя же родилась чуть раньше - 32.11.2000. Мама Ивана 22.13.2000, а ее дедушка 22.11.1805. Я родился 31.11.2020";
            Console.WriteLine(line + "\n");
            string todayYear = "2020";
            Regex reg = new Regex(@"([0-2][\d]|3[0-1])\.(0[\d]|1[0-2])\."+ todayYear);
            var matches = reg.Matches(line);
            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }
        }
        public void Task9()
        {
            string line = "Для того что бы прочитать эту информацию https://edu.grsu.by/pluginfile, вам нужно воспользоваться данной ссылкой https://translate.google.com/?hl=ru#view=home&op=translate&sl=ru&tl=en&text=.";
            Console.WriteLine(line + "\n");
            Regex reg = new Regex(@"((https?|ftp)\:\/\/)?([a-z0-9]{1})((\.[a-z0-9-])|([a-z0-9-]))*\.([a-z]{2,6})(\/?)");
            var matches = reg.Matches(line);
            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }
        }

        public void Task10()
        {
            string line = "23:11:22, в это время родился Иван. Катя же родилась чуть раньше - 32:11:20: Мама Ивана в 22:65:20, а ее дедушка в 22:11:56. Я родился в 31:111:20";
            Console.WriteLine(line + "\n");
            var pattern = "(?<hour>0[0-9]|1[0-9]|2[0-3]):(?<min>[0-5][0-9]):(?<sec>[0-5][0-9])";
            line = Regex.Replace(line, pattern, (m) =>
            {
                var h = int.Parse(m.Groups["hour"].Value);
                var min = int.Parse(m.Groups["min"].Value);
                var sec = int.Parse(m.Groups["sec"].Value);
                if (sec >= 30) min++;
                return string.Format("{0:00}:{1:00}", h, min);
            });
            Console.WriteLine(line + "\n");

        }
    }
}
