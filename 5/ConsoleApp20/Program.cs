using System;

namespace ConsoleApp20
{
    class Program
    {
        static void Main()
        {
            do
            {
                Console.WriteLine("Введите 1, чтобы найти след матрицы");
                Console.WriteLine("Введите 2, чтобы транспонировать матрицу");
                Console.WriteLine("Введите 3, чтобы найти сумму двух матриц");
                Console.WriteLine("Введите 4,чтобы найти разность двух матриц");
                Console.WriteLine("Введите 5, чтобы найти произведение двух матриц");
                Console.WriteLine("Введите 6, чтобы умножить матрицу на число");
                Console.WriteLine("Введите 7, чтбы найти определитель матрицы");
                string answear = Console.ReadLine();
                while (answear != "1" && answear != "2" && answear != "3" && answear != "4" && answear != "5" &&
                       answear != "6" && answear != "7")
                {
                    Console.WriteLine("Вводите что вам предалагают!:)");
                    answear = Console.ReadLine();
                }
                if (answear == "1")
                {
                    int len;
                    int wid;
                    Console.WriteLine("Введите размер матрицы,размер должен состоять из целых чисел,она должна быть квадратной от 1х1 до 10х10");
                    Console.WriteLine("Кол-во строк:");
                    string lenString = Console.ReadLine();
                    int.TryParse(lenString, out len);
                    Console.WriteLine("Кол-во столбцов:");
                    string widString = Console.ReadLine();
                    int.TryParse(widString, out wid);
                    while (!CheckMatrixForSquare(len, wid))
                    {
                        Console.WriteLine("Что-то вы не так вводите, ещё раз!");
                        Console.WriteLine("Кол-во строк:");
                        lenString = Console.ReadLine();
                        int.TryParse(lenString, out len);
                        Console.WriteLine("Кол-во столбцов:");
                        widString = Console.ReadLine();
                        int.TryParse(widString, out wid);
                    }
                    int[,] matrix = new int[len, wid];
                    Console.WriteLine("Вы хотите ввести содержимое матрицы как? рандом или консоль?");
                    string answearRandomOrConsole = Console.ReadLine();
                    while (answearRandomOrConsole != "рандом" && answearRandomOrConsole != "Рандом" && answearRandomOrConsole != "Консоль" && answearRandomOrConsole != "консоль")
                    {
                        Console.WriteLine("Вводите что вам предалагают!:)");
                        answearRandomOrConsole = Console.ReadLine();
                    }
                    if (answearRandomOrConsole == "рандом" || answearRandomOrConsole == "Рандом")
                    {
                        RandomMatrix(matrix, len, wid);
                        FindingTrace(matrix, len, wid);
                    }
                    else if (answearRandomOrConsole == "Консоль" || answearRandomOrConsole == "консоль")
                    {
                        InputNumbersByConsole(matrix, len, wid);
                        FindingTrace(matrix, len, wid);
                    }
                }
                if (answear == "2")
                {
                    int len;
                    int wid;
                    Console.WriteLine("Введите размер матрицы,размер должен состоять из целых чисел, больше 0 и меньше или равно 10");
                    Console.WriteLine("Кол-во строк:");
                    string lenString = Console.ReadLine();
                    int.TryParse(lenString, out len);
                    Console.WriteLine("Кол-во столбцов:");
                    string widString = Console.ReadLine();
                    int.TryParse(widString, out wid);
                    while (!CheckMatrixForOne(len, wid))
                    {
                        Console.WriteLine("Что-то вы не так вводите, ещё раз!");
                        Console.WriteLine("Кол-во строк:");
                        lenString = Console.ReadLine();
                        int.TryParse(lenString, out len);
                        Console.WriteLine("Кол-во столбцов:");
                        widString = Console.ReadLine();
                        int.TryParse(widString, out wid);
                    }
                    int[,] matrix = new int[len, wid];
                    Console.WriteLine("Вы хотите ввести содержимое матрицы как? рандом или консоль?");
                    string answearRandomOrConsole = Console.ReadLine(); ;
                    while (answearRandomOrConsole != "рандом" && answearRandomOrConsole != "Рандом" && answearRandomOrConsole != "Консоль" && answearRandomOrConsole != "консоль")
                    {
                        Console.WriteLine("Вводите что вам предалагают!:)");
                        answearRandomOrConsole = Console.ReadLine();
                    }
                    if (answearRandomOrConsole == "рандом" || answearRandomOrConsole == "Рандом")
                    {
                        RandomMatrix(matrix, len, wid);
                        Console.WriteLine(" ");
                        Transposition(matrix, len, wid);
                    }
                    else if (answearRandomOrConsole == "Консоль" || answearRandomOrConsole == "консоль")
                    {
                        InputNumbersByConsole(matrix, len, wid);
                        Console.WriteLine(" ");
                        Transposition(matrix, len, wid);
                    }
                }
                if (answear == "3")
                {
                    int len;
                    int wid;
                    Console.WriteLine("Введите размер матриц,размер должен состоять из целых чисел, больше 0 и меньше или равно 10");
                    Console.WriteLine("Кол-во строк:");
                    string lenString = Console.ReadLine();
                    int.TryParse(lenString, out len);
                    Console.WriteLine("Кол-во столбцов:");
                    string widString = Console.ReadLine();
                    int.TryParse(widString, out wid);
                    while (!CheckMatrixForOne(len, wid))
                    {
                        Console.WriteLine("Что-то вы не так вводите, ещё раз!");
                        Console.WriteLine("Кол-во строк:");
                        lenString = Console.ReadLine();
                        int.TryParse(lenString, out len);
                        Console.WriteLine("Кол-во столбцов:");
                        widString = Console.ReadLine();
                        int.TryParse(widString, out wid);
                    }
                    int[,] matrix = new int[len, wid];
                    int[,] matrixTwo = new int[len, wid];
                    Console.WriteLine("Вы хотите ввести содержимое матрицы как? рандом или консоль?");
                    string answearRandomOrConsole = Console.ReadLine();
                    while (answearRandomOrConsole != "рандом" && answearRandomOrConsole != "Рандом" && answearRandomOrConsole != "Консоль" && answearRandomOrConsole != "консоль")
                    {
                        Console.WriteLine("Вводите что вам предалагают!:)");
                        answearRandomOrConsole = Console.ReadLine();
                    }
                    if (answearRandomOrConsole == "рандом" || answearRandomOrConsole == "Рандом")
                    {
                        RandomMatrix(matrix, len, wid);
                        Console.WriteLine(" ");
                        RandomMatrix(matrixTwo, len, wid);
                        SumOfTwo(matrix, matrixTwo, len, wid);
                    }
                    else if (answearRandomOrConsole == "Консоль" || answearRandomOrConsole == "консоль")
                    {
                        InputNumbersByConsole(matrix, len, wid);
                        Console.WriteLine(" ");
                        InputNumbersByConsole(matrixTwo, len, wid);
                        SumOfTwo(matrix, matrixTwo, len, wid);
                    }
                }
                if (answear == "4")
                {
                    int len;
                    int wid;
                    Console.WriteLine("Введите размер матриц,размер должен состоять из целых чисел, больше 0 и меньше или равно 10");
                    Console.WriteLine("Кол-во строк:");
                    string lenString = Console.ReadLine();
                    int.TryParse(lenString, out len);
                    Console.WriteLine("Кол-во солбцов:");
                    string widString = Console.ReadLine();
                    int.TryParse(widString, out wid);
                    while (!CheckMatrixForOne(len, wid))
                    {
                        Console.WriteLine("Что-то вы не так вводите, ещё раз!");
                        Console.WriteLine("Кол-во строк:");
                        lenString = Console.ReadLine();
                        int.TryParse(lenString, out len);
                        Console.WriteLine("Кол-во столбцов:");
                        widString = Console.ReadLine();
                        int.TryParse(widString, out wid);
                    }
                    int[,] matrix = new int[len, wid];
                    int[,] matrixTwo = new int[len, wid];
                    Console.WriteLine("Вы хотите ввести содержимое матрицы как? рандом или консоль?");
                    string answearRandomOrConsole = Console.ReadLine();
                    while (answearRandomOrConsole != "рандом" && answearRandomOrConsole != "Рандом" && answearRandomOrConsole != "Консоль" && answearRandomOrConsole != "консоль")
                    {
                        Console.WriteLine("Вводите что вам предалагают!:)");
                        answearRandomOrConsole = Console.ReadLine();
                    }
                    if (answearRandomOrConsole == "рандом" || answearRandomOrConsole == "Рандом")
                    {
                        RandomMatrix(matrix, len, wid);
                        Console.WriteLine(" ");
                        RandomMatrix(matrixTwo, len, wid);
                        DifferenceOfTwo(matrix, matrixTwo, len, wid);
                    }
                    else if (answearRandomOrConsole == "Консоль" || answearRandomOrConsole == "консоль")
                    {
                        InputNumbersByConsole(matrix, len, wid);
                        Console.WriteLine(" ");
                        InputNumbersByConsole(matrixTwo, len, wid);
                        DifferenceOfTwo(matrix, matrixTwo, len, wid);
                    }
                }
                if (answear == "5")
                {
                    int len;
                    int wid;
                    int widTwo;
                    Console.WriteLine(
                        "Введите размер перовой матрицы,размер должен состоять из целых чисел, больше 0 и меньше или равно 10");
                    Console.WriteLine("Кол-во строк:");
                    string lenString = Console.ReadLine();
                    int.TryParse(lenString, out len);
                    Console.WriteLine("Кол-во столбцов:");
                    string widTwoString = Console.ReadLine();
                    int.TryParse(widTwoString, out widTwo);
                    while (!CheckMatrixForOne(len, widTwo))
                    {
                        Console.WriteLine("Что-то вы не так вводите, ещё раз!");
                        Console.WriteLine("Кол-во строк:");
                        lenString = Console.ReadLine();
                        int.TryParse(lenString, out len);
                        Console.WriteLine("Кол-во столбцов:");
                        widTwoString = Console.ReadLine();
                        int.TryParse(widTwoString, out widTwo);
                    }
                    int[,] matrix = new int[len, widTwo];
                    Console.WriteLine("Введите кол-во столбцов второй матрицы,больше 0 и меньше или равно 10");
                    Console.WriteLine("Кол-во столбцов:");
                    string widStringOfTwo = Console.ReadLine();
                    int.TryParse(widStringOfTwo, out wid);
                    while (!CheckOneColumn(wid))
                    {
                        Console.WriteLine("Что-то вы не так вводите, ещё раз!");
                        Console.WriteLine("Кол-во столбцов:");
                        widStringOfTwo = Console.ReadLine();
                        int.TryParse(widStringOfTwo, out wid);
                    }
                    int[,] matrixTwo = new int[widTwo, wid];
                    Console.WriteLine("Вы хотите ввести содержимое матрицы как? рандом или консоль?");
                    string answearRandomOrConsole = Console.ReadLine();
                    while (answearRandomOrConsole != "рандом" && answearRandomOrConsole != "Рандом" && answearRandomOrConsole != "Консоль" && answearRandomOrConsole != "консоль")
                    {
                        Console.WriteLine("Вводите что вам предалагают!:)");
                        answearRandomOrConsole = Console.ReadLine();
                    }
                    if (answearRandomOrConsole == "рандом" || answearRandomOrConsole == "Рандом")
                    {
                        int[,] newMatrix = RandomMatrix(matrix, len, widTwo);
                        Console.WriteLine(" ");
                        int[,] newMatrixTwo = RandomMatrix(matrixTwo, widTwo, wid);
                        MultiplicationOfTwo(newMatrix, newMatrixTwo, len, wid, widTwo);
                    }
                    else if (answearRandomOrConsole == "Консоль" || answearRandomOrConsole == "консоль")
                    {
                        InputNumbersByConsole(matrix, len, widTwo);
                        Console.WriteLine(" ");
                        InputNumbersByConsole(matrixTwo, widTwo, wid);
                        MultiplicationOfTwo(matrix, matrixTwo, len, wid, widTwo);
                    }
                }
                if (answear == "6")
                {
                    int len;
                    int wid;
                    int number;
                    Console.WriteLine("Введите число, на которые вы хотите умножить матрицу от -100 до 100");
                    string strNumber = Console.ReadLine();
                    int.TryParse(strNumber, out number);
                    while (!(int.TryParse(strNumber, out number) && number >= -100 && number <= 100))
                    {
                        Console.WriteLine("Введите число и верное!");
                        strNumber = Console.ReadLine();
                    }
                    Console.WriteLine("Введите размер матрицы,размер должен состоять из целых чисел, больше 0 и меньше или равно 10");
                    Console.WriteLine("Кол-во строк:");
                    string lenString = Console.ReadLine();
                    int.TryParse(lenString, out len);
                    Console.WriteLine("Кол-во столбцов:");
                    string widString = Console.ReadLine();
                    int.TryParse(widString, out wid);
                    while (!CheckMatrixForOne(len, wid))
                    {
                        Console.WriteLine("Что-то вы не так вводите, ещё раз!");
                        Console.WriteLine("Кол-во строк:");
                        lenString = Console.ReadLine();
                        int.TryParse(lenString, out len);
                        Console.WriteLine("Кол-во столбцов:");
                        widString = Console.ReadLine();
                        int.TryParse(widString, out wid);
                    }
                    int[,] matrix = new int[len, wid];
                    Console.WriteLine("Вы хотите ввести содержимое матрицы как? рандом или консоль?");
                    string answearRandomOrConsole = Console.ReadLine();
                    while (answearRandomOrConsole != "рандом" && answearRandomOrConsole != "Рандом" && answearRandomOrConsole != "Консоль" && answearRandomOrConsole != "консоль")
                    {
                        Console.WriteLine("Вводите что вам предалагают!:)");
                        answearRandomOrConsole = Console.ReadLine();
                    }
                    if (answearRandomOrConsole == "рандом" || answearRandomOrConsole == "Рандом")
                    {
                        RandomMatrix(matrix, len, wid);
                        Console.WriteLine(" ");
                        MultiplicationWithNumber(matrix, number, len, wid);
                    }
                    else if (answearRandomOrConsole == "Консоль" || answearRandomOrConsole == "консоль")
                    {
                        InputNumbersByConsole(matrix, len, wid);
                        Console.WriteLine(" ");
                        MultiplicationWithNumber(matrix, number, len, wid);
                    }
                }
                if (answear == "7")
                {
                    int len;
                    int wid;
                    Console.WriteLine(
                        "Введите размер матрицы,размер должен состоять из целых чисел,она должна быть квадратной(от 1х1 до 10х10");
                    Console.WriteLine("Кол-во строк:");
                    string lenString = Console.ReadLine();
                    int.TryParse(lenString, out len);
                    Console.WriteLine("Кол-во столбцов:");
                    string widString = Console.ReadLine();
                    int.TryParse(widString, out wid);
                    while (!CheckMatrixForSquare(len, wid))
                    {
                        Console.WriteLine("Что-то вы не так вводите, ещё раз!");
                        Console.WriteLine("Кол-во строк:");
                        lenString = Console.ReadLine();
                        int.TryParse(lenString, out len);
                        Console.WriteLine("Кол-во столбцов:");
                        widString = Console.ReadLine();
                        int.TryParse(widString, out wid);
                    }
                    int[,] matrix = new int[len, wid];
                    Console.WriteLine("Вы хотите ввести содержимое матрицы как? рандом или консоль?");
                    string answearRandomOrConsole = Console.ReadLine();
                    while (answearRandomOrConsole != "рандом" && answearRandomOrConsole != "Рандом" && answearRandomOrConsole != "Консоль" && answearRandomOrConsole != "консоль")
                    {
                        Console.WriteLine("Вводите что вам предалагают!:)");
                        answearRandomOrConsole = Console.ReadLine();
                    }
                    if (answearRandomOrConsole == "рандом" || answearRandomOrConsole == "Рандом")
                    {
                        RandomMatrix(matrix, len, wid);
                        MethodGauss(matrix, len, wid);
                        DeterminantOfMatrix(matrix, len, wid);
                    }
                    else if (answearRandomOrConsole == "Консоль" || answearRandomOrConsole == "консоль")
                    {
                        InputNumbersByConsole(matrix, len, wid);
                        MethodGauss(matrix, len, wid);
                        DeterminantOfMatrix(matrix, len, wid);
                    }
                }
                Console.WriteLine("Хотите посчитать что-то ещё?");
                Console.WriteLine(" ");
                Console.WriteLine("Введите любой символ для продолжения калькулятора или напишите Нет для закрытия приложения");
                answear = Console.ReadLine();
                if (answear == "Нет" || answear == "нет")
                {
                    Environment.Exit(0);
                }
            } while (true);
        }
        /// <summary>
        ///  метод находит след матрицы.
        /// </summary>
        /// <param name="matrix">матрица вводимая.</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">стобцы.</param>
        private static void FindingTrace(int[,] matrix,int len,int wid)
        {
            int sumOfTrace = 0;
            for (int i = 0; i < len; i++)
            {
                    for (int j = 0; j < wid; j++)
                    {
                        if (i == j) 
                        {sumOfTrace += matrix[i, j];}
                    }
            }
            Console.WriteLine("");
            Console.WriteLine($"Результат: {sumOfTrace}");
        }
        /// <summary>
        /// транспонировка матрицы.
        /// </summary>
        /// <param name="matrix">вводимая матрица.</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        private static void Transposition(int[,] matrix,int len,int wid)
        {
            int[,] transMatrix = new int[wid,len];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    transMatrix[j, i] = matrix[i, j];
                }
                Console.WriteLine();
            }
            OutputOfMatrix(transMatrix,wid,len);
        }
        /// <summary>
        /// метод для суммирования двух матриц.
        /// </summary>
        /// <param name="matrix">первая вводимая матрица.</param>
        /// <param name="matrixTwo">вторая вводимая матрица</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        private static void SumOfTwo(int[,] matrix,int[,] matrixTwo,int len,int wid)
        {
            int[,] matrixSum = new int[len, wid];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    matrixSum[i, j] = matrix[i, j] + matrixTwo[i, j];
                }
                Console.WriteLine();
            }
            OutputOfMatrix(matrixSum,len,wid);
        }
        /// <summary>
        /// метод разности двух матриц.
        /// </summary>
        /// <param name="matrix">первая вводимая матрица.</param>
        /// <param name="matrixTwo">вторая вводимая матрица.</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        private static void DifferenceOfTwo(int[,] matrix,int[,] matrixTwo,int len,int wid)
        {
            int[,] matrixDifference = new int[len, wid];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    matrixDifference[i, j] = matrix[i, j] - matrixTwo[i, j];
                }
                Console.WriteLine();
            }
            OutputOfMatrix(matrixDifference,len,wid);
        }
        /// <summary>
        /// метд для умножения двух матриц.
        /// </summary>
        /// <param name="matrix">первая вводимая матрица.</param>
        /// <param name="matrixTwo">вторая матрица.</param>
        /// <param name="len">строки первой матрицы.</param>
        /// <param name="wid">столбцы второй матрицы.</param>
        /// <param name="widTwo">столбцы второй матрицы.</param>
        private static void MultiplicationOfTwo(int[,] matrix,int[,] matrixTwo,int len,int wid,int widTwo )
        {
            int[,] multiMatrix = new int[len, wid];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    multiMatrix[i, j] = 0;
                    for (int k = 0; k < widTwo; k++)
                    {
                        multiMatrix[i, j] += matrix[i, k] * matrixTwo[k, j];
                    }
                }
                Console.WriteLine();
            }
            OutputOfMatrix(multiMatrix,len,wid);
        }
        /// <summary>
        /// метод для умножения матрицы на число.
        /// </summary>
        /// <param name="matrix">вводимая матрица.</param>
        /// <param name="number">число, на которое умножают.</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        private static void MultiplicationWithNumber(int[,] matrix,int number,int len,int wid)
        {
            int[,] matrixMulti = new int[len, wid];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    matrixMulti[i, j] = matrix[i, j] * number;
                }
            }
            OutputOfMatrix(matrixMulti,len,wid);
        }
        /// <summary>
        /// метод для нахождения детерминанта матрицы.
        /// </summary>
        /// <param name="matrix">вводимая матрица.</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        private static void DeterminantOfMatrix(int[,] matrix,int len,int wid)
        {
            int determinant = 1;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    if (i == j) 
                    {determinant *= matrix[i, j];}
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine($"Результат: {determinant}"); 
        }
        /// <summary>
        /// метод для создания матрицы с рандомными числами внутри.
        /// </summary>
        /// <param name="matrix">вводимая матрица.</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">стобцы.</param>
        /// <returns></returns>
        private static int[,] RandomMatrix(int[,] matrix,int len,int wid)
        {
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    matrix[i, j] = random.Next(0, 50);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            return matrix;
        }
        /// <summary>
        /// метод для ввода чисел в матрицу через консоль.
        /// </summary>
        /// <param name="matrix">вводимая матрица.</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        /// <returns></returns>
        private static int[,] InputNumbersByConsole(int[,] matrix,int len,int wid)
        {
            int number;
            
            Console.WriteLine("Введите число");
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    while (!int.TryParse(Console.ReadLine(), out number) || number < -10000 || number > 10000)
                    {
                        Console.WriteLine("Вы вводите неправильно!!!");
                        Console.WriteLine("Введите число");
                    }
                    matrix[i, j] = number;
                }
            }
            OutputOfMatrix(matrix,len,wid);
            return matrix;
        }
        /// <summary>
        /// метод для вывода двумерного массива ввиде матрицы.
        /// </summary>
        /// <param name="matrix">вводимая матрица.</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        private static void OutputOfMatrix(int[,] matrix,int len,int wid)
        {
            for (int i = 0; i <len; i++)
            {
                for (int j = 0; j <wid; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine(" ");
            }
        }
        /// <summary>
        /// метод для проверки матрицы на правильные размеры.
        /// </summary>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        /// <returns></returns>
        private static bool CheckMatrixForOne(int len,int wid)
        {
            if (len>0 && len<=10 && wid>0 && wid<=10)
            {
                return true;
            } 
            return false;
        }
        /// <summary>
        /// метод для проверки матрицы на квадратность.
        /// </summary>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        /// <returns></returns>
        private static bool CheckMatrixForSquare(int len, int wid)
        {
            if (len>0 && len<=10 && wid>0 && wid<=10 && len == wid)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// метод для проверки кол-во введённых стобцов для корректного перемножения матриц.
        /// </summary>
        /// <param name="widTwo">столбцы второй матрицы.</param>
        /// <returns></returns>
        private static bool CheckOneColumn(int widTwo)
        {
            if (widTwo>0 && widTwo<=10)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// метод для преобразрвания матрицы к ступенчатому виду.
        /// </summary>
        /// <param name="matrix">вводимая матрица.</param>
        /// <param name="len">строки.</param>
        /// <param name="wid">столбцы.</param>
        /// <returns></returns>
        private static int[,] MethodGauss(int[,] matrix,int len,int wid)
        {
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 1; j < len - i; j++)
                {
                    if (matrix[i, i] == 0)
                    {
                        matrix[i, i] = 1;
                        int delen = matrix[i + j, i] / matrix[i, i];
                        for (int k = 0; k < wid; k++)
                        {
                            matrix[i + j, k] -= matrix[i, k] * delen;
                        }
                        
                    }
                    else if (matrix[i,i] != 0)
                    {
                        int delen = matrix[i + j, i] / matrix[i, i];
                        for (int k = 0; k < wid; k++)
                        {
                            matrix[i + j, k] -= matrix[i, k] * delen;
                        }
                    }
                }
            }
            return matrix;
        }
    }
}