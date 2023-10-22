using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sem_3
{
    internal class DZ
    {
        int[,] labirynth1 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
        };

        public bool HasExit(int startI, int startJ)
        {
            int[,] l = labirynth1;
            if (l[startI, startJ] == 1)
            {
                Console.WriteLine("Начальная точка находится в стене!");
                return false;
            }
            else if (l[startI, startJ] == 2)
            {
                Console.WriteLine("Выход ниходится на входе 0_о!");
                return true;
            }

            var stack = new Stack<Tuple<int, int>>();
            stack.Push(new(startI, startJ));
            int exits = 0;
            while (stack.Count > 0)
            {
                var temp = stack.Pop();
                Console.WriteLine(temp);
                /*if (l[temp.Item1, temp.Item2] == 2)
                {
                    Console.WriteLine("Выход найден!");
                    return true;
                }*/

                // очень долго думал как правильно задать следующее условие =) Суть в том, что бы не считать точку входа за выход
                if (!(temp.Item1 == startI && temp.Item2 == startJ))
                {
                    // проверяем, является ли индекс крайним в массиве.
                    if (temp.Item1 == 0 ^ temp.Item1 == l.GetLength(0) - 1
                        ^ temp.Item2 == 0 ^ temp.Item2 == l.GetLength(1) - 1)
                    {
                        Console.WriteLine("Выход найден!");
                        //return true;
                        exits++;
                    }
                }

                l[temp.Item1, temp.Item2] = 1;


                if (temp.Item2 > 0 && l[temp.Item1, temp.Item2 - 1] != 1)
                    stack.Push(new(temp.Item1, temp.Item2 - 1)); // вверх

                if (temp.Item2 + 1 < l.GetLength(1) && l[temp.Item1, temp.Item2 + 1] != 1)
                    stack.Push(new(temp.Item1, temp.Item2 + 1)); // низ

                if (temp.Item1 > 0 && l[temp.Item1 - 1, temp.Item2] != 1)
                    stack.Push(new(temp.Item1 - 1, temp.Item2)); // лево

                if (temp.Item1 + 1 < l.GetLength(0) && l[temp.Item1 + 1, temp.Item2] != 1)
                    stack.Push(new(temp.Item1 + 1, temp.Item2)); // право
            }

            //return false;
            Console.WriteLine($"Выходов: {exits}");
            if (exits > 0) { return true; }
            return false;

        }
    }
}
    
    

