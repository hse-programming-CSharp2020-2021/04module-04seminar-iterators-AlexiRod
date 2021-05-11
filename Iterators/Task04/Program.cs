using System;
using System.Collections;

/* На вход подается число N.
 * Нужно создать коллекцию из N квадратов последовательного ряда натуральных чисел 
 * и вывести ее на экран дважды. Элементы коллекции разделять пробелом. 
 * Выводы всей коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 3
 * 
 * Пример выходных данных:
 * 1 4 9
 * 1 4 9
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int value = 0;
                if (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
                    throw new ArgumentException();
                MyInts myInts = new MyInts();
                IEnumerator enumerator = myInts.GetIntEnumerator(value);

                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }

        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            if (enumerator.MoveNext())
                Console.Write(enumerator.Current);

            while (enumerator.MoveNext())
                Console.Write($" {enumerator.Current}");
        }
    }

    class MyInts : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        int cur = 0, max = -1;
        public bool MoveNext()
        {
            if (cur < max)
            {
                cur++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            cur = 0;
        }

        public IEnumerator GetIntEnumerator(int limit)
        {
            this.max = limit;
            return this;
        }

        public object Current
        {
            get => cur * cur;
        }
    }
}
