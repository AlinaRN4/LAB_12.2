using ClassLibrary10lab;
namespace Лабораторная_работа_12._2
{
    internal class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("1. Создать таблицу");
            Console.WriteLine("2. Напечатать таблицу");
            Console.WriteLine("3. Поиск в таблице");
            Console.WriteLine("4. Удаление в таблице");
            Console.WriteLine("5. Добавление в таблицу");
            Console.WriteLine("6. Очистить таблицу");
        }
        
        static int IsInt(int min, int max) //функция для проверки на минимальное и максимальное значение)
        {
            bool isConvert;
            int number;
            do
            {
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out number);
                if (!isConvert || number < min || number > max)
                {
                    Console.WriteLine($"Неправильно введено число. Введите значение от {min} до {max}");
                }
            } while (!isConvert || number < min || number > max);
            return number;
        }

        static void Main(string[] args)
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            int answer = 1;
            while (answer != 6)
            {
                try
                {
                    PrintMenu();
                    answer = IsInt(1, 6);
                    switch (answer)
                    {
                        case 1:

                            table.CreateRandomTable(10);
                            break;

                        case 2:
                            table.PrintTable();
                            break;

                        case 3:
                            MusicalInstrument musicalForSearch = new MusicalInstrument();
                            Console.WriteLine("Введите объект для поиска");
                            musicalForSearch.Init();
                            Console.WriteLine("Таблица содержит данный объект объект: " + table.ContainsKey(musicalForSearch));
                            break;

                        case 4:
                            MusicalInstrument musicalForRemove = new MusicalInstrument();
                            Console.WriteLine("Введите объект для удаления");
                            musicalForRemove.Init();
                            if (table.RemoveByKey(musicalForRemove) == false)
                                Console.WriteLine("Элемент не найден в таблице");
                            else
                                Console.WriteLine("Удаление прошло успешно");
                            break;

                        case 5:
                            Console.WriteLine("Добавим в таблицу случайный элемент");
                            MusicalInstrument musicalForAdd = new MusicalInstrument();
                            musicalForAdd.RandomInit();
                            table.AddPoint(musicalForAdd);
                            Console.WriteLine($"Элемент {musicalForAdd} добавлен в таблицу!");
                            break;

                        case 6:
                            table.ClearTable();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

    }
}
