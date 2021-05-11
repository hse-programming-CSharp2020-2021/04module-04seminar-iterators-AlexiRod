using System;
using System.Collections;
using System.Text;

/* На вход подается число N.
 * Нужно создать коллекцию из N элементов последовательного ряда натуральных чисел, возведенных в 10 степень, 
 * и вывести ее на экран ТРИЖДЫ. Инвертировать порядок элементов при каждом последующем выводе.
 * Элементы коллекции разделять пробелом. 
 * Очередной вывод коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 2
 * 
 * Пример выходных данных:
 * 1 1024
 * 1024 1
 * 1 1024
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * В других ситуациях выбрасывайте 
*/
namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyDigits myDigits = new MyDigits();
                if (!long.TryParse(Console.ReadLine(), out long value) || value <= 0)
                    throw new ArgumentException();

                IEnumerator enumerator = myDigits.MyEnumerator(value);

                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("ooops");
            }
        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            StringBuilder sb = new StringBuilder();

            if (enumerator.MoveNext())
                sb.Append(enumerator.Current);

            while (enumerator.MoveNext())
                sb.Append($" {enumerator.Current}");

            Console.Write(sb.ToString());
        }
    }

    class MyDigits : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        long step = 1, cur = 0, max = 0;

        public void Reset()
        {
            step *= -1;
            cur = step > 0 ? 0 : max + 1;
        }

        public bool MoveNext()
        {
            long next = cur + step;
            if (next > 0 && next <= max)
            {
                cur = next;
                return true;
            }

            Reset();
            return false;
        }


        public IEnumerator MyEnumerator(long limit)
        {
            max = limit;
            return this;
        }

        public object Current
        {
            get
            {
                long res = 1;
                for (long i = 1; i <= 10; i++)
                    res = checked(res * cur);

                return res;
            }
        }

    }
}
