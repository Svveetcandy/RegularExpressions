using System;


namespace RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {

            bool escape = false;
            int choice;

            string menu = "1. Определить, содержится ли в сообщении заданное слово.\n" +
                "2. Вывести все слова заданной длины.\n" +
                "3. Удалить из сообщения все однобуквенные слова.\n" +
                "4. Удалить из сообщения только те русские слова, которые начинаются на гласную букву.\n" +
                "5. Заменить все английские слова на многоточие.\n" +
                "6. Найти сумму всех имеющихся в тексте чисел(целых и вещественных).\n" +
                "7. Вывести все номера телефонов(xxx-xx, xxx - xxx, xx-xx-xx), которые содержатся в сообщении.\n" +
                "8. Вывести на экран все даты(дд.мм.гггг), которые относятся к текущему году.\n" +
                "9. Вывести на экран все адреса web-сайтов, содержащиеся в сообщении.\n" +
                "10.Округлить все время(чч:мм:сс) до минут и вывести собщение на экран.\n" +
                "11.Конкорданс.\n" +
                "0. Выход.\n";
            task1 task = new task1();
            task2 concordance = new task2();
            while (!escape)
            {
                Console.WriteLine(menu);
                Console.Write("Выберите действие: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice) {
                    case 1:
                        {
                            Console.WriteLine(task.Task1());
                            break;
                        }
                    case 2:
                        {
                            
                            task.Task2();
                            break;
                        }
                    case 3:
                        {
                            task.Task3();
                            break;
                        }
                    case 4:
                        {
                            task.Task4();
                            break;
                        }
                    case 5:
                        {
                            task.Task5();
                            break;
                        }
                    case 6:
                        {
                            task.Task6();
                            break;
                        }
                    case 7:
                        {
                            task.Task7();
                            break;
                        }
                    case 8:
                        {
                            task.Task8();
                            break;
                        }
                    case 9:
                        {
                            task.Task9();
                            break;
                        }
                    case 10:
                        {
                            task.Task10();
                            break;
                        }
                    case 11:
                        {
                            concordance.DoConcordance();
                            break;
                        }
                    case 0:
                        {
                            escape = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Такого действия нет.");
                            break;
                        }
                }
                Console.WriteLine("Нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();

            }

            
            
            
        }
    }
}
