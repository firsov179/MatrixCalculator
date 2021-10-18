using System;
using System.IO;

namespace MatrixCalculator
{
    /// <summary>
    /// Класс который осуществляет работу калькулятора.
    /// </summary>
    internal static class Calculator
    {
        private const int MinOperationNumber = 1;
        private const int MaxOperationNumber = 8;
        private const double MinFactor = -100.1;
        private const double MaxFactor = 100.1;
        private const int MaxValue = 15;
        private const int MinValue = -15;

        /// <summary>
        /// Сообщение об ошибке ввода.
        /// </summary>
        public static void PrintBadInputMessage()
        {
            Console.WriteLine("\nВведите корректные данные!\n");
        }
        
        /// <summary>
        /// Метод осуществляющий ввод матрицы из файла.
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <param name="matrix">Матрица в которую будет производиться запись данных из файла. </param>
        /// <param name="n">Количество строк ожидаемой матрицы.</param>
        /// <param name="m">Количество столбцов ожидаемой матрицы.</param>
        /// <returns>Возвращает истину если метод отработал корректно, в противном случае ложь.</returns>
        private static bool ReadMatrixFromFile(string path, ref double[,] matrix, int n, int m)
        {
            var sr = new StreamReader(path);
            var i = 0;
            var input = sr.ReadLine();
            for (; input != null; i++)
            {
                if (i >= n)
                    return false;
                var splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (splitInput.Length != m)
                {
                    return false;
                }

                for (var j = 0; j < m; ++j)
                    if (!double.TryParse(splitInput[j], out var number) ||
                        number is < MinValue or > MaxValue)
                    {
                        return false;
                    }
                    else
                    {
                        matrix[i, j] = number;
                    }
                input = sr.ReadLine();
            }

            sr.Close();
            return true;
        }

        /// <summary>
        /// Метод отвечающий за обработку вариантов ввода матрицы.
        /// </summary>
        /// <param name="n">Количество строк ожидаемой матрицы.</param>
        /// <param name="m">Количество столбцов ожидаемой матрицы.</param>
        /// <returns>Возвращает полученную матрицу.</returns>

        private static Matrix GetChoiceInput(int n, int m)
        {
            Console.WriteLine("\nВыберите способ ввода\n" +
                              "1. Ввод матрицы из файла\n" +
                              "2. Сгенерировать матрицу\n" +
                              "3. Ввести матрицу с клавиатуры\n");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            try
                            {
                                Console.Write("\nУкажите полный путь к файлу: ");
                                var path = Console.ReadLine();
                                var matrix = new double[n, m];
                                if (ReadMatrixFromFile(path, ref matrix, n, m))
                                {
                                    Console.WriteLine("\nПрочитана матрица:");
                                    var outMatrix = new Matrix(matrix);
                                    outMatrix.PrintMatrix();
                                    return outMatrix;
                                }
                                Console.WriteLine("\nВ файле указана некорректная матрица!");
                                return GetChoiceInput(n, m);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\nException: " + e.Message);
                                return GetChoiceInput(n, m);
                            }
                        }
                    case "2":
                        {
                            var matrix = new Matrix(n, m);
                            Console.WriteLine("\nСгенерирована матрица:");
                            matrix.PrintMatrix();
                            return matrix;
                        }
                    case "3":
                        {
                            Console.WriteLine($"\nВведите матрицу размера {n} на {m} из вещественных чисел от -15 до 15:\n");
                            var matrix = new Matrix(Matrix.ReadMatrix(n, m));
                            Console.WriteLine("\nВаша матрица:");
                            matrix.PrintMatrix();
                            return matrix;
                        }
                    default:
                        {
                            PrintBadInputMessage();
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Метод отвечает за обработку ввода номера операции.
        /// </summary>
        /// <returns>Возвращает номер операции.</returns>

        private static int ReadOperationNumber()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var number) &&
                    number is >= MinOperationNumber and <= MaxOperationNumber) return number;
                PrintBadInputMessage();
            }
        }

        /// <summary>
        /// Метод отвечает за обработку ввода множителя матрицы.
        /// </summary>
        /// <returns>Возвращает множитель матрицы.</returns>

        private static double ReadFactor()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out var factor) &&
                    factor > MinFactor && factor < MaxFactor) return factor;
                PrintBadInputMessage();
            }
        }

        /// <summary>
        /// Обработка умножения матрицы на число.
        /// </summary>

        private static void LetMatrixMultiplicationByNumber()
        {
            Console.Write("\nВведите количество строк матрицы, не меньшее 2 и не превосходящее 10: ");
            int n = Matrix.ReadDimensionSize();
            Console.Write("\nВведите количество столбцов матрицы, не меньшее 2 и не превосходящее 10: ");
            int m = Matrix.ReadDimensionSize();
            Console.Write("\nВведите вещественный множитель [-100; 100]: ");
            double factor = ReadFactor();
            Matrix matrix = GetChoiceInput(n, m);
            var result = matrix * factor;
            Console.WriteLine("\nРезультат операции : ");
            result.PrintMatrix();
        }

        /// <summary>
        /// Обработка сложения/вычитания матриц.
        /// </summary>
        /// <param name="isPositive">Если передан параметр тру то метод выполнит сложение матриц, иначе вычитание.</param>

        private static void LetMatrixAddition(bool isPositive = true)
        {
            Console.Write("\nВведите количество строк складываемых матриц, не меньшее 2 и не превосходящее 10: ");
            int n = Matrix.ReadDimensionSize();
            Console.Write("\nВведите количество столбцов складываемых матриц, не меньшее 2 и не превосходящее 10: ");
            int m = Matrix.ReadDimensionSize();
            Matrix lhs = GetChoiceInput(n, m);
            Matrix rhs = GetChoiceInput(n, m);
            var sum = isPositive ? lhs + rhs : lhs - rhs;
            Console.WriteLine("\nРезультат операции : ");
            sum.PrintMatrix();
        }

        /// <summary>
        /// Обработка перемножения матриц.
        /// </summary>

        private static void LetMatrixMultiplication()
        {
            Console.Write("\nВведите количество строк первой матрицы, не меньшее 2 и не превосходящее 10: ");
            int n = Matrix.ReadDimensionSize();
            Console.Write(
                "\nВведите количество столбцов первой матрицы и количество строк второй, не меньшее 2 и не превосходящее 10: ");
            int k = Matrix.ReadDimensionSize();
            Console.Write("\nВведите количество столбцов второй матрицы, не меньшее 2 и не превосходящее 10: ");
            int m = Matrix.ReadDimensionSize();
            Matrix lhs = GetChoiceInput(n, k);
            Matrix rhs = GetChoiceInput(k, m);
            var mult = lhs * rhs;
            Console.WriteLine("\nРезультат операции : ");
            mult.PrintMatrix();
        }

        /// <summary>
        /// Обработка транспонирования матрицы.
        /// </summary>

        private static void LetMatrixTranspose()
        {
            Console.Write("\nВведите количество строк матрицы, не меньшее 2 и не превосходящее 10: ");
            int n = Matrix.ReadDimensionSize();
            Console.Write("\nВведите количество столбцов матрицы, не меньшее 2 и не превосходящее 10: ");
            int m = Matrix.ReadDimensionSize();
            var matrix = GetChoiceInput(n, m);
            Console.WriteLine("\nРезультат операции : ");
            matrix.Transpose().PrintMatrix();
        }

        /// <summary>
        /// Обработка поиска следа матрицы.
        /// </summary>

        private static void LetGetMatrixTrace()
        {
            Console.Write("\nВведите количество строк и столбцов матрицы, не меньшее 2 и не превосходящее 10: ");
            int n = Matrix.ReadDimensionSize();
            var matrix = GetChoiceInput(n, n);
            double res = matrix.GetTrace();
            Console.WriteLine($"\nРезультат операции: {Matrix.GetResult(res):f3}");
        }

        /// <summary>
        /// Обработка поиска определителя матрицы.
        /// </summary>

        private static void LetGetMatrixDeterminant()
        {
            Console.Write("\nВведите количество строк и столбцов матрицы, не меньшее 2 и не превосходящее 10: ");
            int n = Matrix.ReadDimensionSize();
            var matrix = GetChoiceInput(n, n);
            double res = matrix.GetDeterminant();
            Console.WriteLine($"\nРезультат операции: {Matrix.GetResult(res):f3}");
        }

        /// <summary>
        /// Обработка нахождения решений линейного уравнения.
        /// </summary>

        private static void LetGaussSolver()
        {
            Console.Write("\nВведите количество уравнений, не меньшее 2 и не превосходящее 10: ");
            int n = Matrix.ReadDimensionSize();
            Console.Write("\nВведите количество неизвестных,не меньшее 2 и не превосходящее 10: ");
            int m = Matrix.ReadDimensionSize() + 1;
            Console.WriteLine("\nСистему уравнений преобразуйте в матричный вид");
            var matrix = GetChoiceInput(n, m);
            int isGood = matrix.LetGaussMethod(out var answer);
            switch (isGood)
            {
                case 0:
                    Console.WriteLine("\nСистема уравнений не имеет решений");
                    break;
                case int.MaxValue:
                    Console.WriteLine("\nСистема уравнений имеет бесконечное множество решений");
                    break;
                default:
                    {
                        Console.WriteLine();
                        for (var i = 0; i < answer.Length; i++)
                        {
                            var currentResult = answer[i];
                            Console.WriteLine($"x{i + 1} = {Matrix.GetResult(answer[i]):f3}");
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Обработка запуска операций калькулятора.
        /// </summary>

        private static void StartSolution()
        {
            switch (ReadOperationNumber())
            {
                case 1:
                    {
                        LetGetMatrixTrace();
                        break;
                    }
                case 2:
                    {
                        LetMatrixTranspose();
                        break;
                    }
                case 3:
                    {
                        LetMatrixAddition();
                        break;
                    }
                case 4:
                    {
                        LetMatrixAddition(false);
                        break;
                    }
                case 5:
                    {
                        LetMatrixMultiplication();
                        break;
                    }
                case 6:
                    {
                        LetMatrixMultiplicationByNumber();
                        break;
                    }
                case 7:
                    {
                        LetGetMatrixDeterminant();
                        break;
                    }
                case 8:
                    {
                        LetGaussSolver();
                        break;
                    }
                default:
                    return;
            }
        }
        
        /// <summary>
        /// Вывод списка операций.
        /// </summary>

        private static void PrintRules()
        {
            Console.WriteLine("Выбери операцию:\n" +
                              "1. нахождение следа матрицы;\n" +
                              "2. транспонирование матрицы;\n" +
                              "3. сумма двух матриц;\n" +
                              "4. разность двух матриц;\n" +
                              "5. произведение двух матриц;\n" +
                              "6. умножение матрицы на число;\n" +
                              "7. нахождение определителя матрицы;\n" +
                              "8. найти решения системы уравнений\n");
        }

        /// <summary>
        /// Точка входа в программу с реализованым перезапуском решения.
        /// </summary>

        private static void Main()
        {
            ConsoleKeyInfo button;
            Console.Title = "MatrixCalculator";
            Console.WriteLine("Привет!");
            do
            {
                PrintRules();
                StartSolution();
                Console.WriteLine("\nДля завершения нажмите Enter, для продолжения любую другую клавишу");
                button = Console.ReadKey(true);
                Console.Clear();
            } while (button.Key != ConsoleKey.Enter);
        }
    }
}