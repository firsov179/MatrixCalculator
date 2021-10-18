using System;

namespace MatrixCalcApp
{
    class MatrixCalc
    {
        /// <summary>
        /// Предлагает пользователю задать два числа являющимеся размерами матрицы.
        /// </summary>
        /// <param name="m">Количество строк</param>
        /// <param name="n">Колчество столбцов</param>
        static void SetMatrixSize(out int m, out int n)
        {

            Console.WriteLine("Введите размеры m и n матрицы A(m,n):");
            while (!int.TryParse(Console.ReadLine(), out m) || m < 1 || m > 20)
            {
                Console.WriteLine("Введите m еще раз, m >= 1 и m <= 20");
            }
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 20)
            {
                Console.WriteLine("Введите n еще раз, n >= 1 и n <= 20");
            }
        }

        /// <summary>
        /// Предлагает пользователю задать число являющимеся порядком квадратной матрицы.
        /// </summary>
        /// <param name="m">Порядок матрицы</param>
        static void SetMatrixSize(out int m)
        {
            Console.WriteLine("Введите размеры m квадратной матрицы A(m, m):");
            while (!int.TryParse(Console.ReadLine(), out m) || m < 1 || m > 20)
            {
                Console.WriteLine("Введите m еще раз, m >= 1 и m <= 20");
            }
        }

        /// <summary>
        /// Предлагает пользователю задать три числа являющимеся размерами матриц их для умножения.
        /// </summary>
        /// <param name="m">Количество строк</param>
        /// <param name="k">Количество строк равное колчеству строк второй</param>
        /// <param name="n">Колчество столбцов</param>
        static void SetMatrixSize(out int m, out int k, out int n)
        {

            Console.WriteLine("Введите размеры m и k и n матриц A(m,k) и B(k, n):");
            while (!int.TryParse(Console.ReadLine(), out m) || m < 1 || m > 20)
            {
                Console.WriteLine("Введите m еще раз, m >= 1 и m <= 20");
            }
            while (!int.TryParse(Console.ReadLine(), out k) || k < 1 || k > 20)
            {
                Console.WriteLine("Введите k еще раз, k >= 1 и k <= 20");
            }
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 20)
            {
                Console.WriteLine("Введите n еще раз, n >= 1 и n <= 20");
            }
        }

        /// <summary>
        /// Метод похожий на TryPrase, который переводит строчку разделнных пробелом 
        /// n вещественных чисел в одномерный массив данных чисел.
        /// </summary>
        /// <param name="str">Строка, которую нужно преобравзовать</param>
        /// <param name="n">Предпологаемое количество чисел в строке</param>
        /// <param name="outArray">Перемернная получающая результат перевода,
        /// или массив с n дефолтных значений типа double, в случае неввозможности перевода</param>
        /// <returns> true если перевод возможен, иначе false</returns>
        static bool StringToDoubleArray(string str, int n, out double[] outArray)
        {
            string[] arrayOfStrings;
            outArray = new double[n];
            if (str == null)
            {
                return false;
            }
            arrayOfStrings = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (arrayOfStrings.Length != n)
            {
                outArray = new double[n];
                return false;
            }
            for (int j = 0; j < n; j++)
            {
                if (!double.TryParse(arrayOfStrings[j], out outArray[j]))
                {
                    outArray = new double[n];
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Реализует построчный ввод  из консоли заданных размеров матрицы, содержащей вещественные числа.
        /// </summary>
        /// <param name="m">Количество строк матрицы</param>
        /// <param name="n">Количество столбцов матрицы</param>
        /// <returns>Введенную пользователем матрицу в виде массива m на n</returns>
        static double[,] MatrixInput(int m, int n)
        {
            Console.WriteLine("Если хотите сгенерировать матрицу (с целыми числами от -100 до 100) введите \"0\":");
            double[,] matrix = new double[m, n];
            if (Console.ReadLine() == "0")
            {
                return GenerateMatrix(m, n);
            }
            double[] arrayOfNums;
            Console.WriteLine("Вводите строки матрицы (элементы не пустые и идут через пробелы):");
            for (int i = 0; i < m; i++)
            {
                while (!StringToDoubleArray(Console.ReadLine(), n, out arrayOfNums))
                {
                    Console.WriteLine($"Введите строку матрицы c {n} вещественными числами:");
                }

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = arrayOfNums[j];
                }
            }
            return matrix;
        }

        /// <summary>
        /// Генерирует матрицу заполненую случайными целыми числами от -100 до 100
        /// </summary>
        /// <param name="m">Количество строк матрицы</param>
        /// <param name="n">Количество столбцов матрицы</param>
        /// <returns>Матрица m на n заполенная случайными целыми числами</returns>
        static double[,] GenerateMatrix(int m, int n)
        {
            string border = "-----------------------------------------";
            var rnd = new Random();
            double[,] matrix = new double[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(-100, 101);
                }
            }
            Console.WriteLine(border);
            Console.WriteLine("Сгенерирована следующая матрица:");
            MatrixPrint(matrix);
            Console.WriteLine(border);
            return matrix;
        }

        /// <summary>
        /// Выводит матрицу в виде таблицы удобной дял чтения
        /// </summary>
        /// <param name="matrix">Матрица, которую нужно вывести на консоль</param>
        static void MatrixPrint(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],10:F2} ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Реализует ввод кватратной матрицы и выводит ее след.
        /// </summary>
        static void DoMatrixTrace()
        {
            double result = 0;
            SetMatrixSize(out int m);
            double[,] matrix = MatrixInput(m, m);
            for (int i = 0; i < m; i++)
            {
                result += matrix[i, i];
            }
            Console.WriteLine(result);
        }

        /// <summary>
        /// Реализует ввод матрицы и выводит на консоль транспонированную.
        /// </summary>
        static void DoMatrixTranspose()
        {
            SetMatrixSize(out int m, out int n);
            double[,] matrix = MatrixInput(m, n);
            double[,] resultMatrix = new double[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[j, i] = matrix[i, j];
                }
            }
            MatrixPrint(resultMatrix);
        }

        /// <summary>
        /// Считает сумму матриц одинакового размера.
        /// </summary>
        /// <param name="firstMatrix">Первая матрица.</param>
        /// <param name="secondMatrix">Вторая матрица.</param>
        /// <returns>Сумма матриц в виде массива. 
        /// Если сложение невозможно возвращает первую матрицу.</returns>
        static double[,] MatrixSum(double[,] firstMatrix, double[,] secondMatrix)
        {

            if (firstMatrix.GetLength(0) == secondMatrix.GetLength(0)
                && firstMatrix.GetLength(1) == secondMatrix.GetLength(1))
            {
                int m = firstMatrix.GetLength(0);
                int n = firstMatrix.GetLength(1);
                double[,] resultMatrix = new double[m, n];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        resultMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                    }
                }
                return resultMatrix;
            }
            else return firstMatrix;
        }

        /// <summary>
        /// Предлагает ввести две матрицы заданного пользователем размера и 
        /// выводит на консоль сумму этих матриц.
        /// </summary>
        static void DoMatrixSum()
        {
            int m, n;
            SetMatrixSize(out m, out n);
            double[,] firstMatrix = MatrixInput(m, n);
            double[,] secondMatrix = MatrixInput(m, n);
            double[,] resultMatrix = new double[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                }
            }
            MatrixPrint(resultMatrix);
        }

        /// <summary>
        /// Считает разность матриц одинакового размера.
        /// </summary>
        /// <param name="firstMatrix">Уменьшаемая матрица.</param>
        /// <param name="secondMatrix">Вычитаемая матрица.</param>
        /// <returns>Разность матриц в виде массива. 
        /// Если вычитание невозможно возвращает первую матрицу.</returns>
        static double[,] MatrixDiff(double[,] firstMatrix, double[,] secondMatrix)
        {

            if (firstMatrix.GetLength(0) == secondMatrix.GetLength(0)
                && firstMatrix.GetLength(1) == secondMatrix.GetLength(1))
            {
                int m = firstMatrix.GetLength(0);
                int n = firstMatrix.GetLength(1);
                double[,] resultMatrix = new double[m, n];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        resultMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                    }
                }
                return resultMatrix;
            }
            else return firstMatrix;
        }

        /// <summary>
        /// Предлагает ввести две матрицы заданного пользователем размера и
        /// выводит на консоль разность этих матриц.
        /// </summary>
        static void DoMatrixDiff()
        {
            SetMatrixSize(out int m, out int n);
            double[,] firstMatrix = MatrixInput(m, n);
            double[,] secondMatrix = MatrixInput(m, n);
            double[,] resultMatrix = new double[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                }
            }
            MatrixPrint(resultMatrix);
        }

        /// <summary>
        /// Считает произведение двух матриц.
        /// </summary>
        /// <param name="firstMatrix">Превая матрица.</param>
        /// <param name="secondMatrix">Вторая матрица.</param>
        /// <returns>Массив являющийся резульатом произведения.
        /// Если произвдение невозможно выводит первую матрицу</returns>
        static double[,] MatrixMult(double[,] firstMatrix, double[,] secondMatrix)
        {
            int m = firstMatrix.GetLength(0);
            int k = firstMatrix.GetLength(1);
            int n = secondMatrix.GetLength(1);
            double[,] resultMatrix = new double[m, n];
            double ElemOfResultMatrix = 0;
            if (k == secondMatrix.GetLength(0))
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int indexInChosenRow = 0; indexInChosenRow < k; indexInChosenRow++)
                        {
                            ElemOfResultMatrix += firstMatrix[i, indexInChosenRow] * secondMatrix[indexInChosenRow, j];
                        }
                        resultMatrix[i, j] = ElemOfResultMatrix;
                        ElemOfResultMatrix = 0;
                    }
                }
                return resultMatrix;
            }
            else return firstMatrix;
        }

        /// <summary>
        /// Предлагает ввести размеры двух матриц (три числа m , k, n ) и матрицы  А(m, k) B(k,n). 
        /// Затем выводит их произведение в виде матрицы C (m, n).
        /// </summary>
        static void DoMatrixMult()
        {
            SetMatrixSize(out int m, out int k, out int n);
            MatrixPrint(MatrixMult(MatrixInput(m, k), MatrixInput(k, n)));
        }

        /// <summary>
        /// Умножает матрицу на число.
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="num">Вещетсвенное число</param>
        /// <returns>Полученная после умножения матрица</returns>
        static double[,] MatrixMultByNum(double[,] matrix, double num)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= num;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Реализует ввод вещетсвенного числа и матрицы, и выводит на консоль результат умножения матрицы на число.
        /// </summary>
        static void DoMatrixMultByNum()
        {
            double num;
            do
            {
                Console.WriteLine("Введите чилсо, на которое хотите умножить матрицу:");
            }
            while (!double.TryParse(Console.ReadLine(), out num));
            SetMatrixSize(out int m, out int n);
            MatrixPrint(MatrixMultByNum(MatrixInput(m, n), num));
        }

        /// <summary>
        /// Рекурсивно считает определитель квадратной матрицы.
        /// </summary>
        /// <param name="matrix">Квадратная матрица</param>
        /// <returns>Значение опредилителя</returns>
        static double MatrixDet(double[,] matrix)
        {
            // данный алгоритм основан на разложении определителя по первому столбцу, с рекурсивным
            // применением миноров (алгебраических определителей элеменов)
            int m = matrix.GetLength(0);
            if (m < 1)
            {
                return 0;
            }
            double res = 0;
            if (m == 1)
            {
                return matrix[0, 0];
            }

            for (int i = 0; i < m; i++)
            {
                if (i % 2 == 0)
                {
                    res += matrix[0, i] * MatrixDet(MatrixReplaceRowAndColumn(matrix, 0, i));
                }
                else if (i % 2 != 0)
                {
                    res -= matrix[0, i] * MatrixDet(MatrixReplaceRowAndColumn(matrix, 0, i));
                }
            }
            return res;
        }

        /// <summary>
        /// Выбрасывает из массива (матрицы) указануную строку и столбец.
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="row">Индекс строки</param>
        /// <param name="column">Индекс столбца</param>
        /// <returns>Матрицу без указанной строки и столбца</returns>
        static double[,] MatrixReplaceRowAndColumn(double[,] matrix, int row, int column)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            double[,] resultMatrix = new double[m - 1, n - 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != row && j != column)
                    {
                        if (i > row && j > column)
                        {
                            resultMatrix[i - 1, j - 1] = matrix[i, j];
                        }
                        else if (i > row)
                        {
                            resultMatrix[i - 1, j] = matrix[i, j];
                        }
                        else if (j > column)
                        {
                            resultMatrix[i, j - 1] = matrix[i, j];
                        }
                        else
                        {
                            resultMatrix[i, j] = matrix[i, j];
                        }
                    }
                }
            }
            return resultMatrix;
        }

        /// <summary>
        /// Реализует ввод матрицы и вывод на консоль ее определителя.
        /// </summary>
        static void DoMatrixDet()
        {
            int m;
            Console.WriteLine("Введите размеры m квадратной матрицы A(m, m):");
            while (!int.TryParse(Console.ReadLine(), out m) || m < 1 || m > 10)
            {
                Console.WriteLine("Введите m еще раз, m >= 1 и m <= 20");
            }
            Console.WriteLine(MatrixDet(MatrixInput(m, m)));
        }

        /// <summary>
        /// Выводит пользователю меню функционала
        /// </summary>
        static void Menu()
        {
            Console.WriteLine("Выберите опцию и введите ее цифру:\n" +
                    "1. нахождение следа матрицы;\n" +
                    "2. транспонирование матрицы\n" +
                    "3. сумма двух матриц;\n" +
                    "4. разность двух матриц;\n" +
                    "5. произведение двух матриц;\n" +
                    "6. умножение матрицы на число;\n" +
                    "7. нахождение определителя матрицы.\n" +
                    "8. решение СЛАУ");
        }

        /// <summary>
        /// Решает СЛАУ с n неизвестными
        /// </summary>
        /// <param name="system">Матрица n на n+1</param>
        /// <param name="n">количество неизветсных членов</param>
        static void LinearSystem(double[,] system, int n)
        {
            GetMatrixAndColumnVectorB(system, out double[,] matrix, out double[] vector);
            double detA = MatrixDet(matrix);
            if (detA == 0)
            {
                Console.WriteLine("СЛАУ не совместна");
                return;
            }
            Console.WriteLine("Решение:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"x{i + 1} = {MatrixDet(ReplaceColumnWithVector(matrix, vector, i)) / detA}");
            }
        }

        /// <summary>
        /// Разделяет матрицу m на m + 1 на квадратную и столбец свободных членов
        /// </summary>
        /// <param name="system">матрица m на m + 1</param>
        /// <param name="matrix">квадратная матрица слау</param>
        /// <param name="vector">столбец свободных членов</param>
        static void GetMatrixAndColumnVectorB(double[,] system, out double[,] matrix, out double[] vector)
        {
            int m = system.GetLength(0);
            matrix = new double[m, m];
            vector = new double[m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m + 1; j++)
                {
                    if (j == m)
                    {
                        vector[i] = system[i, j];
                    }
                    else
                    {
                        matrix[i, j] = system[i, j];
                    }
                }
            }
        }

        /// <summary>
        /// Меняет заданный стоблец на столбец свободных членов
        /// </summary>
        /// <param name="matrix">квадратная матрица слау</param>
        /// <param name="vector">столбец свободных членов</param>
        /// <param name="columnIndex">индекс столбца</param>
        /// <returns>новую квадратную матрицу</returns>
        static double[,] ReplaceColumnWithVector(double[,] matrix, double[] vector, int columnIndex)
        {
            int m = matrix.GetLength(0);
            double[,] result = new double[m, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < m; i++)
            {
                result[i, columnIndex] = vector[i];
            }
            return result;
        }

        /// <summary>
        /// Реализует решение СЛАУ
        /// </summary>
        static void DoLinearSystem()
        {
            int n;
            Console.WriteLine("Введите количество неизвестных n в совметсной СЛАУ :");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 10)
            {
                Console.WriteLine("Введите n еще раз, n >= 1 и n <= 10");
            }
            Console.WriteLine($"Сейчас вам будет предложено ввести матрицу {n} на {n + 1} для СЛАУ");
            LinearSystem(MatrixInput(n, n + 1), n);
        }

        /// <summary>
        /// Точка входа.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор матриц. Ограничения программы описаны в README.txt");
            do
            {
                Menu();
                switch (Console.ReadLine())
                {
                    case "1":
                        DoMatrixTrace();
                        break;
                    case "2":
                        DoMatrixTranspose();
                        break;
                    case "3":
                        DoMatrixSum();
                        break;
                    case "4":
                        DoMatrixDiff();
                        break;
                    case "5":
                        DoMatrixMult();
                        break;
                    case "6":
                        DoMatrixMultByNum();
                        break;
                    case "7":
                        DoMatrixDet();
                        break;
                    case "8":
                        DoLinearSystem();
                        break;
                    default:
                        Console.WriteLine("Вы ввели неподходящее число (опцию)");
                        break;
                }
                Console.WriteLine("Нажмите любую кнопку, чтобы продожлить. Чтобы выйти нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
