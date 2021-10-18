using System;
using System.IO;
using System.Threading.Tasks;

namespace Class
{


    /// <summary>
    /// Реализация калькулятора матриц.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Нахождение НОД двух чисел.
        /// </summary>
        /// <param name="a"> Первое число.</param>
        /// <param name="b"> Второе число.</param>
        /// <returns> Возвращает НОД(a, b).</returns>
        public static long Gcd(long a, long b)
        {
            while (b > 0)
            {
                a %= b;
                long c = a;
                a = b;
                b = c;
            }
            return a;
        }
        /// <summary>
        /// Нахождение модуля дроби.
        /// </summary>
        /// <param name="inp"> Исходная дробь.</param>
        /// <returns> Возвращает |inp|.</returns>
        public static Fraction Abs(Fraction inp)
        {
            inp.Simple();
            if (inp.num < 0)
            {
                return -inp;
            }
            return inp;
        }

        /// <summary>
        /// Обработка операции умножения матрицы на число.
        /// Считывание матрицы и числа, получение ответа, вывод его на экран.
        /// </summary>
        public static void NumProd()
        {
            long userFirstSize, userSecondSize;
            do
                Console.WriteLine("Введите количество строк матрицы. Это должно быть целое цисло от 1 до 10.");
            while (!long.TryParse(Console.ReadLine(), out userFirstSize) || userFirstSize > 10 || userFirstSize < 1);

            do
                Console.WriteLine("Введите количество столбцов матрицы. Это должно быть целое цисло от 1 до 10.");
            while (!long.TryParse(Console.ReadLine(), out userSecondSize) || userSecondSize > 10 || userSecondSize < 1);
            Matrix inputMatrix = InputMatrix(userFirstSize, userSecondSize);
            long inputNumber;
            Matrix outputMatrix = new Matrix(inputMatrix.secondSize, inputMatrix.firstSize);

            do
                Console.WriteLine("Введите число на которое хотите умножить матрицу. Это должно быть целое цисло от -100 до 100.");
            while (!long.TryParse(Console.ReadLine(), out inputNumber) || inputNumber > 100 || inputNumber < -100);

            for (long i = 0; i < inputMatrix.firstSize; ++i)
            {
                for (long j = 0; j < inputMatrix.secondSize; ++j)
                {
                    outputMatrix.data[j, i].num = inputMatrix.data[i, j].num * inputNumber;
                }
            }
            Console.WriteLine("Исходная матрица: ");
            inputMatrix.Print();
            Console.WriteLine("Ответ: ");
            outputMatrix.Print();
        }


        /// <summary>
        /// Обработка операции транспозиции матрицы.
        /// Считывание матрицы, получение ответа, вывод его на экран.
        /// </summary>
        public static void Transpose()
        {
            long userFirstSize, userSecondSize;
            do
                Console.WriteLine("Введите количество строк матрицы. Это должно быть целое цисло от 1 до 10.");
            while (!long.TryParse(Console.ReadLine(), out userFirstSize) || userFirstSize > 10 || userFirstSize < 1);

            do
                Console.WriteLine("Введите количество столбцов матрицы. Это должно быть целое цисло от 1 до 10.");
            while (!long.TryParse(Console.ReadLine(), out userSecondSize) || userSecondSize > 10 || userSecondSize < 1);
            Matrix inputMatrix = InputMatrix(userFirstSize, userSecondSize);
            Matrix outputMatrix = new Matrix(inputMatrix.secondSize, inputMatrix.firstSize);
            for (long i = 0; i < inputMatrix.firstSize; ++i)
            {
                for (long j = 0; j < inputMatrix.secondSize; ++j)
                {
                    outputMatrix.data[j, i] = inputMatrix.data[i, j];
                }
            }
            Console.WriteLine("Исходная матрица: ");
            inputMatrix.Print();
            Console.WriteLine("Ответ: ");
            outputMatrix.Print();
        }


        /// <summary>
        /// Обработка операции сложения дыух матриц.
        /// Считывание матриц, получение ответа, вывод его на экран.
        /// </summary>
        public static void MatSum()
        {
            Matrix firstMatrix;
            Matrix secondMatrix;
            do
            {
                Console.WriteLine("Введите две мартицы одинакового размера.");
                long userFirstSize, userSecondSize;
                do
                    Console.WriteLine("Введите количество строк в каждой матрице. Это должно быть целое цисло от 1 до 10.");
                while (!long.TryParse(Console.ReadLine(), out userFirstSize) || userFirstSize > 10 || userFirstSize < 1);

                do
                    Console.WriteLine("Введите количество столбцов в каждой матрице. Это должно быть целое цисло от 1 до 10.");
                while (!long.TryParse(Console.ReadLine(), out userSecondSize) || userSecondSize > 10 || userSecondSize < 1);
                firstMatrix = InputMatrix(userFirstSize, userSecondSize);
                secondMatrix = InputMatrix(userFirstSize, userSecondSize);
            }
            while (firstMatrix.firstSize != secondMatrix.firstSize || firstMatrix.secondSize != secondMatrix.secondSize);
            Matrix ans = new Matrix(firstMatrix.firstSize, firstMatrix.secondSize);
            for (long i = 0; i < firstMatrix.firstSize; ++i)
            {
                for (long j = 0; j < firstMatrix.secondSize; ++j)
                {
                    ans.data[i, j] = firstMatrix.data[i, j] + secondMatrix.data[i, j];
                }
            }
            firstMatrix.Print();
            Console.WriteLine("+");
            secondMatrix.Print();
            Console.WriteLine("Ответ: ");
            ans.Print();
        }


        /// <summary>
        /// Обработка операции умножения матрицы на число.
        /// Считывание матрицы и числа, получение ответа, вывод его на экран.
        /// </summary>
        public static void MatProd()
        {
            Matrix firstMatrix;
            Matrix secondMatrix;
            do
            {
                Console.WriteLine("Введите две мартицы. Они должны быть размеров N x M и M x K");
                long userFirstSize, userSecondSize, userThirdSize;
                do
                    Console.WriteLine("Введите размерность N. Это должно быть целое цисло от 1 до 10.");
                while (!long.TryParse(Console.ReadLine(), out userFirstSize) || userFirstSize > 10 || userFirstSize < 1);

                do
                    Console.WriteLine("Введите размерность M. Это должно быть целое цисло от 1 до 10.");
                while (!long.TryParse(Console.ReadLine(), out userSecondSize) || userSecondSize > 10 || userSecondSize < 1);

                do
                    Console.WriteLine("Введите размерность K. Это должно быть целое цисло от 1 до 10.");
                while (!long.TryParse(Console.ReadLine(), out userThirdSize) || userThirdSize > 10 || userThirdSize < 1);

                Console.WriteLine("Введите две мартицы. Они должны быть размеров N x M и M x K");
                firstMatrix = InputMatrix(userFirstSize, userSecondSize);
                secondMatrix = InputMatrix(userSecondSize, userThirdSize);
            }
            while (firstMatrix.secondSize != secondMatrix.firstSize);
            Matrix ans = new Matrix(firstMatrix.firstSize, secondMatrix.secondSize);
            for (long i = 0; i < firstMatrix.firstSize; ++i)
            {
                for (long j = 0; j < firstMatrix.secondSize; ++j)
                {
                    ans.data[i, j] = firstMatrix.data[i, j] + secondMatrix.data[i, j];
                }
            }
            firstMatrix.Print();
            Console.WriteLine("+");
            secondMatrix.Print();
            Console.WriteLine("Ответ: ");
            ans.Print();
        }


        /// <summary>
        /// Обработка операции вычетания матриц.
        /// Считывание матрицы, получение ответа, вывод его на экран.
        /// </summary>
        public static void MatSub()
        {
            Matrix firstMatrix;
            Matrix secondMatrix;
            do
            {
                long userFirstSize, userSecondSize;
                do
                    Console.WriteLine("Введите количество строк матрицы. Это должно быть целое цисло от 1 до 10.");
                while (!long.TryParse(Console.ReadLine(), out userFirstSize) || userFirstSize > 10 || userFirstSize < 1);

                do
                    Console.WriteLine("Введите количество столбцов матрицы. Это должно быть целое цисло от 1 до 10.");
                while (!long.TryParse(Console.ReadLine(), out userSecondSize) || userSecondSize > 10 || userSecondSize < 1);
                Console.WriteLine("Введите две мартицы одинакового размера.");
                firstMatrix = InputMatrix(userFirstSize, userSecondSize);
                secondMatrix = InputMatrix(userFirstSize, userSecondSize);
            }
            while (firstMatrix.firstSize != secondMatrix.firstSize || firstMatrix.secondSize != secondMatrix.secondSize);
            Matrix ans = new Matrix(firstMatrix.firstSize, firstMatrix.secondSize);
            for (long i = 0; i < firstMatrix.firstSize; ++i)
            {
                for (long j = 0; j < firstMatrix.secondSize; ++j)
                {
                    ans.data[i, j] = firstMatrix.data[i, j] - secondMatrix.data[i, j];
                }
            }
            firstMatrix.Print();
            Console.WriteLine("-");
            secondMatrix.Print();
            Console.WriteLine("Ответ: ");
            ans.Print();
        }


        /// <summary>
        /// Обработка операции нахождение следа матрицы.
        /// Считывание матрицы, получение ответа, вывод его на экран.
        /// </summary>
        public static void Trace()
        {
            Matrix inputMatrix;
            do
            {
                Console.WriteLine("Введите квадратную матрицу.");
                long userFirstSize;
                do
                    Console.WriteLine("Введите количество строк матрицы. Это должно быть целое цисло от 1 до 10.");
                while (!long.TryParse(Console.ReadLine(), out userFirstSize) || userFirstSize > 10 || userFirstSize < 1);

               
                inputMatrix = InputMatrix(userFirstSize, userFirstSize);
            }
            while (inputMatrix.secondSize != inputMatrix.firstSize);

            long ans = 0;
            for (long i = 0; i < inputMatrix.firstSize; ++i)
            {
                ans += inputMatrix.data[i, i].num; 
            }
            Console.WriteLine($"Ответ: {ans}");
        }


        /// <summary>
        /// Считывание матрицы из консоли.
        /// </summary>
        /// /// <param name="userFirstSize"> Колличество строк в матрице.</param>
        /// <param name="userSecondSize"> Количество столбцов в матрице.</param>
        /// <returns> Возвращает полученную матрицу.</returns>
        public static long[,] ReadMatrix(long userFirstSize, long userSecondSize)
        {
            Console.WriteLine($"Введите {userFirstSize} строк.");
            Console.WriteLine($"В каждой строке {userSecondSize} чисел разделенные пробелами.");
            Console.WriteLine("Каждое число в матрице должно быть целым числом от -30 до 30.");

            long[,] data = new long[userFirstSize, userSecondSize];
            for (long i = 0; i < userFirstSize; ++i)
                while (true)
                {
                    string[] inp = Console.ReadLine().Split(' ');
                    bool correctInput = true;
                    if (inp.Length != userSecondSize)
                        correctInput = false;
                    else
                        for (long j = 0; j < inp.Length; ++j)
                            if (!long.TryParse(inp[j], out data[i, j]) || data[i, j] < -1000 || data[i, j] > 10000)
                            {
                                correctInput = false;
                                break;
                            }

                    if (correctInput)
                    {
                        Console.WriteLine(i < userFirstSize - 1 ? "Хорошо. Теперь следующая строка." : "Хорошо.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine($"Введите {userSecondSize} чисел через пробел.");
                        Console.WriteLine("Каждое число должно быть целым числом от -30 до 30.");
                    }
                }
            return data;
        }


        /// <summary>
        /// Обработка операции умножения матрицы на число.
        /// Считывание матрицы и числа, получение ответа, вывод его на экран.
        /// </summary>
        public static long[,] GenerateMatrix(long userFirstSize, long userSecondSize)
        {
            var rnd = new Random();

            long[,] data = new long[userFirstSize, userSecondSize];
            for (long i = 0; i < userFirstSize; ++i)
            {
                for (long j = 0; j < userSecondSize; ++j)
                {
                    data[i, j] = rnd.Next(-30, 30);
                }
            }
            return data;
        }


        /// <summary>
        /// Считывание матрицы.
        /// Возможно считывание из консоли, файла или случайная генерация.
        /// </summary>
        /// <param name="userFirstSize"> Колличество строк в матрице.</param>
        /// <param name="userSecondSize"> Количество столбцов в матрице.</param>
        /// <returns> Возвращает полученную матрицу.</returns>
        public static Matrix InputMatrix(long userFirstSize, long userSecondSize)
        {
            string inp;
            Console.WriteLine("Хотите ввести матрицу вручную? Иначе она будет сгенерирована случайно.");
            do
            {
                Console.WriteLine("Введите yes или no.");
                inp = Console.ReadLine();
            } while (inp != "no" && inp != "yes");
            long[,] data;
            if (inp == "yes")
            {
                Console.WriteLine("Хотите ввести матрицу из консоли? Иначе она будет считана из файла.");
                do
                {
                    Console.WriteLine("Введите yes или no.");
                    inp = Console.ReadLine();
                } while (inp != "no" && inp != "yes");
                if (inp == "yes")
                {
                    data = ReadMatrix(userFirstSize, userSecondSize);
                }
                else
                {
                    data = FileReadMatrix(userFirstSize, userSecondSize);
                }
            }
            else
            {
                data = GenerateMatrix(userFirstSize, userSecondSize);
            }    
            return new Matrix(userFirstSize, userSecondSize, data);
        }

        /// <summary>
        /// Считывание матрицы из файла.
        /// </summary>
        /// /// <param name="userFirstSize"> Колличество строк в матрице.</param>
        /// <param name="userSecondSize"> Количество столбцов в матрице.</param>
        /// <returns> Возвращает полученную матрицу.</returns>

        public static long[,] FileReadMatrix(long userFirstSize, long userSecondSize)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Для файлового ввода используйте файл типа txt.");
                    Console.WriteLine($"В файле должно быть {userFirstSize} строк.");
                    Console.WriteLine($"В каждой строке {userSecondSize} чисел разделенные пробелами.");
                    Console.WriteLine("Каждое число в матрице должно быть целым числом от -30 до 30.");
                    Console.WriteLine("ВВедите полный путь Вашего файла. Пример: 'c:/temp/mytext.txt' ");
                    string path = Console.ReadLine();
                    using (StreamReader sr = new StreamReader(path))
                    {
                        
                        string line;
                        int i = -1;
                        long[,] data = new long[userFirstSize, userSecondSize];
                        while ((line = sr.ReadLine()) != null)
                        {
                            i++;
                            string[] inp = line.Split(' ');
                            bool correctInput = true;
                            if (inp.Length != userSecondSize)
                                correctInput = false;
                            else
                                for (long j = 0; j < inp.Length; ++j)
                                    if (!long.TryParse(inp[j], out data[i, j]) || data[i, j] < -100 || data[i, j] > 100)
                                    {
                                        correctInput = false;
                                        break;
                                    }

                            if (!correctInput)
                            {
                                Console.WriteLine("SAS");
                                throw new Exception();
                            }

                        }
                        if (i != userFirstSize - 1)
                        {
                            throw new Exception();
                        }
                        return data;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Что-то не так.");
                    Console.WriteLine("Попробуйте снова.");
                }
            }
        }

          

        /// <summary>
        /// Нахождение определителя матрицы. Реализован оптимальный алгоритм за O(n^3).
        /// Считывание матрицы, нахождение определителя и вывод результата в консоль.
        /// </summary>
        public static void Determ()
        {
            Matrix inputMatrix;
            Console.WriteLine("Введите квадратную матрицу.");
            long userSize;
            do
                Console.WriteLine("Введите количество строк матрицы. Это должно быть целое цисло от 1 до 10.");
            while (!long.TryParse(Console.ReadLine(), out userSize) || userSize > 10 || userSize < 1);
            inputMatrix = InputMatrix(userSize, userSize);
            inputMatrix.Print();
            Fraction ans = new Fraction(1, 1);
            for (int i = 0; i < userSize; ++i)
            {
                int k = i;
                for (int j = i + 1; j < userSize; ++j)
                    if (Abs(inputMatrix.data[j, i]) > Abs(inputMatrix.data[k, i]))
                        k = j;
                if (inputMatrix.data[k, i].num == 0)
                {
                    ans.den = 0;
                    ans.num = 0;
                    break;
                }
                if (i != k)
                {
                    ans = -ans;
                    for (int q = 0; q < userSize; ++q)
                    {
                        var buf = inputMatrix.data[i, q];
                        inputMatrix.data[i, q] = inputMatrix.data[k, q];
                        inputMatrix.data[k, q] = buf;
                    }
                }
                ans *= inputMatrix.data[i, i];
                for (int j = i + 1; j < userSize; ++j)
                    inputMatrix.data[i, j] /= inputMatrix.data[i, i];
                for (int j = 0; j < userSize; ++j)
                    if (j != i && Abs(inputMatrix.data[j, i]).num != 0)
                        for (int q = i + 1; q < userSize; ++q)
                            inputMatrix.data[j, q] -= inputMatrix.data[i, q] * inputMatrix.data[j, i];
            } 
            Console.WriteLine($"Determinant = " + Convert.ToString(ans.num) + (ans.den > 1 ? " / " + Convert.ToString(ans.den) : ""));
        }

        /// <summary>
        /// Обработка входных и выходных данных при решении линейных уравнений методом Гаусса.
        /// Считывание матрицы, получение ответа из функции Gauss и вывод результата в консоль.
        /// </summary>
        static public void Solve()
        {
            Console.WriteLine("Для решения системы уравнений запишите их в матрицу.");
            Console.WriteLine("Пример:");
            Console.WriteLine("x + y = 3 and x + 2 y = 5. Будет записано в матрицу как:");
            Console.WriteLine("1 1 3");
            Console.WriteLine("1 2 5");
            Console.WriteLine("");

            long userFirstSize, userSecondSize;
            do
                Console.WriteLine("Введите количество строк матрицы. Это должно быть целое цисло от 1 до 10.");
            while (!long.TryParse(Console.ReadLine(), out userFirstSize) || userFirstSize > 10 || userFirstSize < 1);

            do
                Console.WriteLine("Введите количество столбцов матрицы. Это должно быть целое цисло от 1 до 10.");
            while (!long.TryParse(Console.ReadLine(), out userSecondSize) || userSecondSize > 10 || userSecondSize < 1);

            Matrix inputMatrix = InputMatrix(userFirstSize, userSecondSize);
            inputMatrix.Print();
            Fraction[] ans = new Fraction[inputMatrix.secondSize - 1];
            for (long i = 0; i < ans.Length; ++i)
            {
                ans[i] = new Fraction(0, 0);
            }
            long cou = Gauss(inputMatrix, ref ans, inputMatrix.firstSize, inputMatrix.secondSize - 1);

            if(cou == 0)
            {
                Console.WriteLine("Решений нет!");
            }
            else if (cou == 179)
            {
                Console.WriteLine("Решений бесконечно много!");
            }
            else
            {
                Console.WriteLine("Ответ:");
                for (long i = 0; i < ans.Length; ++i)
                    Console.WriteLine($"X{i} = " + Convert.ToString(ans[i].num) + (ans[i].den > 1 ? " / " + Convert.ToString(ans[i].den) : ""));
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Решение системы линейных уравнений методом Гаусса.
        /// Решение использует только рациональные числа и гарантирует абсолютную точность без погрешности в представлении действительных чисел.
        /// </summary>
        /// <param name="inputMatrix"> Собственно матрица.</param>
        /// <param name="ans"> Массив дробей куда будет записан ответ.</param>
        /// /// <param name="firstSize"> Количество строк в матрице.</param>
        /// /// <param name="secondSize"> Количество столбцов в матрице.</param>
        /// <returns> Возвращает полученную 0 если решений нет, 1 если существует единственное решение, и 179, если решений бесконечно много.</returns>
        static public long Gauss(Matrix inputMatrix, ref Fraction[] ans, long firstSize, long secondSize)
        {
            long[] numberNeedLine = new long[secondSize];
            for (long i = 0; i < secondSize; ++i)
                numberNeedLine[i] = -1;
            for (long column = 0, line = 0; column < secondSize && line < firstSize; ++column)
            {
                long sel = line;
                for (long i = line; i < firstSize; ++i)
                    if (Abs(inputMatrix.data[i, column]) > Abs(inputMatrix.data[sel, column]))
                        sel = i;
                if (inputMatrix.data[sel, column].den == 0)
                    continue;
                for (long i = column; i <= secondSize; ++i)
                {
                    var buf = inputMatrix.data[sel, i];
                    inputMatrix.data[sel, i] = inputMatrix.data[line, i];
                    inputMatrix.data[line, i] = buf;
                }
                numberNeedLine[column] = line;
                for (long i = 0; i < firstSize; ++i)
                    if (i != line)
                    {
                        Fraction c = inputMatrix.data[i, column] / inputMatrix.data[line, column];
                        for (long j = column; j <= secondSize; ++j)
                        {
                            inputMatrix.data[i, j] -= inputMatrix.data[line, j] * c;
                            inputMatrix.data[i, j].Simple();
                        }
                    }
                ++line;
            }
            for (long i = 0; i < secondSize; ++i)
                if (numberNeedLine[i] != -1)
                    ans[i] = inputMatrix.data[numberNeedLine[i], secondSize] / inputMatrix.data[numberNeedLine[i], i];
            for (long i = 0; i < firstSize; ++i)
            {
                Fraction sum = new Fraction();
                for (long j = 0; j < secondSize; ++j)
                    sum += ans[j] * inputMatrix.data[i, j];
                if ((sum - inputMatrix.data[i, secondSize]).num != 0)
                    return 0;
            }
            for (long i = 0; i < secondSize; ++i)
                if (numberNeedLine[i] == -1)
                    return 179;
            return 1;
        }

        /// <summary>
        /// Тело калькулятора реализующие повтор решения и обработку запросов пользователя.
        /// </summary>
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    string inp;
                    Console.WriteLine("Хотите сделать новую оперрацию?");
                    do
                    {
                        Console.WriteLine("Введите yes или no.");
                        inp = Console.ReadLine();
                    } while (inp != "no" && inp != "yes");
                    if (inp == "no")
                        break;

                    Console.WriteLine("Какую именно?");
                    do
                    {
                        Console.WriteLine("Введите 'MatSum' для нахождения суммы двух матриц.");
                        Console.WriteLine("Введите 'MatSub' для нахождения разности двух матриц.");
                        Console.WriteLine("Введите 'MatProd' для  нахождения произведения двух матриц.");
                        Console.WriteLine("Введите 'NumProd' для  нахождения произведения матрицы на число.");
                        Console.WriteLine("Введите 'Trace' для нахождения следа матрицы.");
                        Console.WriteLine("Введите 'Transpose' для транспонирования матрицы.");
                        Console.WriteLine("Введите 'Determinant' для нахождения определителя матрицы.");
                        Console.WriteLine("Введите 'Solve' для нахождения определителя матрицы.");
                        inp = Console.ReadLine();
                    } while (inp != "MatSum" && inp != "MatSub" && inp != "MatProd" && inp != "NumProd" && inp != "Trace" && inp != "Transpose" && inp != "Determinant" && inp != "Solve");
                    if (inp == "MatSum")
                        MatSum();
                    else if (inp == "MatSub")
                        MatSub();
                    else if (inp == "MatProd")
                        MatProd();
                    else if (inp == "NumProd")
                        NumProd();
                    else if (inp == "Trace")
                        Trace();
                    else if (inp == "Transpose")
                        Transpose();
                    else if (inp == "Determinant")
                        Determ();
                    else if (inp == "Solve")
                        Solve();
                }
                catch
                {
                    Console.WriteLine("Что-то пошло не так.");
                }
            }
                
        } 
    }
}
