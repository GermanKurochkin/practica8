using System;

namespace practica8
{
    class Program
    {
        static bool[,] matr= new bool[1,1];
        static int count;
        static int InputMenu(int maxNum)
        {
            int menu;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = int.TryParse(input, out menu);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (menu < 0 || menu > maxNum) Console.WriteLine($"Некорректный ввод.Выберите вариант от 0 до {maxNum} из меню");
            } while (!ok || menu < 0 || menu > maxNum);

            return menu;
        }
        static int InputNum(int maxNum)
        {
            int num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = int.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (num < 5 || num > maxNum) Console.WriteLine($"Некорректный ввод. Введите число не больше {maxNum}");
            } while (!ok || num < 5 || num > maxNum);

            return num;

        }
        static void GetCycle()
        {
            Random rand = new Random();
            int num, numOfLink,n;

            int size = matr.GetLength(0);
            for (int j=1;j<=size;j++)
            {
                num = 0;
                for(int i=1;i<=j;i++)
                {
                    if (matr[i - 1, j - 1]) num++;
                }
                if (j < size - 2) n = rand.Next(2)*2;
                else n = 0;
                numOfLink = rand.Next((size - j) / 2 ) * 2+n + num % 2;
                while(numOfLink!=0)
                {
                    for (int i = size; i >j; i--)
                    {
                        if (!matr[i - 1, j - 1]&& numOfLink != 0)
                        {
                            numOfLink--;
                            matr[i - 1, j - 1] = true;
                            matr[j - 1, i - 1] = true;
                        }
                    }
                }

            }

        }
        //static void Write(bool cycle)
        //{
        //    Console.WriteLine();
        //    int size = matr.GetLength(0);
        //    Console.Write("Вершины: ");
        //    for(int i=1;i<=size;i++)
        //    {
        //        Console.Write($" {i}");
        //    }
        //    Console.WriteLine();
        //    Console.Write("Вектора: ");
        //    for (int i = 1; i <= size; i++)
        //    {
        //        for (int j = i+1; j <= size; j++)
        //        {
        //            if(matr[i-1,j-1]) Console.Write($"  {i} {j};");
        //        }
        //    }
        //    Console.WriteLine();
        //    if (cycle) Console.Write("Цикл есть ");
        //    else Console.Write("Цикла нет ");
        //    Console.WriteLine();
        //}
        static void Write()
        {
            Console.WriteLine();
            int size = matr.GetLength(0);
            Console.WriteLine("Вершины: ");
            for (int i = 1; i <= size; i++)
            {
                Console.Write($" {i}");
            }
            Console.WriteLine();
            Console.WriteLine("Вектора: ");
            for (int i = 1; i <= size; i++)
            {
                for (int j = i + 1; j <= size; j++)
                {
                    if (matr[i - 1, j - 1]) Console.Write($"  {i} {j};");
                }
            }
            Console.WriteLine();
        }
        static void GetTest(int size)
        {

            int menu = 10;
            while (menu != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Получить");
                Console.WriteLine("0. Выход");
                Console.ResetColor();
                menu = InputMenu(1);
                matr = new bool[size, size];
                if (menu == 0) break;
                else
                {
                    GetCycle();                
                    Write();
                }
            }

        }

        //static void GetTest(int size)
        //{

        //    int menu=10;
        //    while (menu != 0)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.WriteLine("1. Есть эйлеров цикл");
        //        Console.WriteLine("2. Нет эйлерова цикла");
        //        Console.WriteLine("0. Выход");
        //        Console.ResetColor();
        //        menu = InputMenu(2);
        //        matr = new bool[size, size];
        //        if (menu == 0) break;
        //        else
        //        {
        //            GetCycle();
        //            if (menu == 2)
        //            {
        //                bool ok = false;
        //                for (int j = 1; j <= size; j++)
        //                {
        //                    if (ok) break;
        //                    for (int i = 1; i <= size; i++)
        //                    {
        //                        if(i!=j && !matr[i-1,j-1])
        //                        {
        //                            matr[i - 1, j - 1] = true;
        //                            matr[j - 1, i - 1] = true;
        //                            ok = true;
        //                            break;
        //                        }
        //                    }
        //                }
        //                if (!ok) matr[0, 1] = false;
        //            }
        //            Write(menu==1);


        //        }
        //    }

        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин");
            count = InputNum(20);
            GetTest(count);
        }
    }
}
