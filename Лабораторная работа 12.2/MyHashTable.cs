using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10lab;
namespace Лабораторная_работа_12._2
{
    public class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        Point<T>?[] table;
        public int Capacity => table.Length;

        public MyHashTable(int length = 10)
        {
            table = new Point<T>[length];
        }

        public void PrintTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine($"{i}:");
                if (table[i] != null)
                {
                    Console.WriteLine(table[i].Data);
                    if (table[i].Next != null)
                    {
                        Point<T>? current = table[i].Next;
                        while (current != null)
                        {
                            Console.WriteLine(current.Data);
                            current = current.Next;
                        }
                    }
                }
            }
        }

        public void AddPoint(T data)
        {
            // Проверяем индекс, где должна быть добавлена точка
            int index = GetIndex(data);

            // Если в указанном индексе нет точки, создаем новую точку и присваиваем ей данные
            if (table[index] == null)
            {
                table[index] = new Point<T>(data);
                table[index].Data = data;
            }
            else // В противном случае идем по цепочке точек и добавляем новую точку в конец
            {
                Point<T>? current = table[index];

                // При этом устанавливаем связи между текущей и новой точкой
                while (current.Next != null)
                {
                    if (current.Equals(data))
                        return;
                    current = current.Next;
                }
                current.Next = new Point<T>(data);
                current.Next.Pred = current;
            }
        }
        public void CreateRandomTable(int numberOfElements)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                T data = new T();
                data.RandomInit();
                AddPoint(data);
            }
        }
        
        public bool Contains(T data)
        {
            // Получаем индекс, где должна быть искомая точка
            int index = GetIndex(data);

            if (table == null)
                throw new Exception("empty table");

            // Если в указанном индексе нет точки, возвращаем false
            if (table[index] == null)
                return false;

            // Если данные точки в указанном индексе совпадают с искомыми данными, возвращаем true
            if (table[index].Data.Equals(data))
                return true;

            // Иначе проходим по цепочке точек и проверяем каждую точку на совпадение данных
            else
            {
                Point<T>? current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
            }
            return false;
        }

        int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        public bool RemoveByKey(T data)
        {
            int index = GetIndex(data);

            if (table[index] == null)
            {
                return false; // Элемент не найден по данному ключу
            }
            else if (table[index].Data.Equals(data))
            {
                // Элемент найден в начале цепочки
                table[index] = table[index].Next;
                return true;
            }
            else
            {
                // Элемент найден в середине или в конце цепочки
                Point<T>? current = table[index];
                while (current.Next != null)
                {
                    if (current.Next.Data.Equals(data))
                    {
                        current.Next = current.Next.Next; // Удаление элемента из цепочки
                        return true;
                    }
                    current = current.Next;
                }
                return false; // Элемент не найден по данному ключу
            }
        }

        public bool ContainsKey(T data)
        {
            int index = GetIndex(data);

            if (table[index] == null)
            {
                return false; // Элемент не найден по данному ключу
            }
            else
            {
                // Проверяем цепочку на наличие элемента с данными
                Point<T>? current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        return true; // Элемент найден
                    }
                    current = current.Next;
                }
                return false; // Элемент не найден по данному ключу
            }
        }

        public void ClearTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = null;
            }
        }
    }
}
