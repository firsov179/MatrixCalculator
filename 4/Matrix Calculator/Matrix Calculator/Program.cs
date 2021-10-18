using System;

namespace MatrixCalculator
{
    /// <summary>
    /// Контейнер статических методов.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Метод, выполняющий основную функцию программы.
        /// </summary>
        static void Main()
        {
            Console.Title = "Калькулятор матрицы";
            ConsoleKeyInfo consoleKey;
            do
            {
                int operation = ChooseOperation();
                ActivateFistSet(operation);
                ActivateSecondSet(operation);
                ActivateThirdSet(operation);
                ActivateMultiplication(operation);
                Console.WriteLine("Спасибо за использование программы! Чтобы завершить работу с программой, нажмите ESCAPE.");
                consoleKey = Console.ReadKey(true);
            } while (consoleKey.Key != ConsoleKey.Escape);
        }



        /// <summary>
        /// Метод, вызываемый при выборе операций 1 или 7. Производит ввод необходимых данных конкретно для этих операций и 
        /// вызывает соответствующие методы для рассчетов и вывода.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        private static void ActivateFistSet(int operation)
        {
            if ((operation == 1) || (operation == 7))
            {
                int order = 0;
                Console.WriteLine($"Для {operation} операции возможно использовать только квадратную матрицу. Какой порядок i матрицы?");
                int choice = ChooseHowToDecideSize();
                if (choice == 1)
                {
                    Random rnd = new Random();
                    order = rnd.Next(1, 11);
                    Console.WriteLine($"Порядок матрицы i = {order}");
                }
                else if (choice == 2)
                {
                    do
                    {
                        Console.Write("Порядок матрицы i = ");
                    } while ((!int.TryParse(Console.ReadLine(), out order)) | (order < 1));
                }
                double[,] matrix = new double[order, order];

                CompleteFirstSet(operation, order, matrix);

            }
        }
        /// <summary>
        /// Метод, вызываемый при выборе операций 2, 6 или 8. Производит ввод необходимых данных конкретно для этих операций и 
        /// вызывает соответствующие методы для рассчетов и вывода.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        private static void ActivateSecondSet(int operation)
        {
            if ((operation == 2) || (operation == 6) || (operation == 8))
            {
                Console.WriteLine("Как Вы хотите определить размер матрицы?");
                int choice = ChooseHowToDecideSize(), rows = 0, cols = 0;
                if (choice == 1)
                {
                    Random rnd = new Random();
                    rows = rnd.Next(1, 11);
                    cols = rnd.Next(1, 11);
                    Console.WriteLine($"Размер матрицы {rows}x{cols}");
                }
                else if (choice == 2)
                {
                    do
                    {
                        Console.Write("Число строк матрицы: ");
                    } while ((!int.TryParse(Console.ReadLine(), out rows)) | (rows < 1));
                    do
                    {
                        Console.Write("Число столбцов матрицы: ");
                    } while ((!int.TryParse(Console.ReadLine(), out cols)) | (cols < 1));
                }
                double[,] matrix = new double[rows, cols];
                CompleteSecondSet(operation, rows, cols, matrix);

            }
        }
        /// <summary>
        /// Метод, вызываемый при выборе операций 3 или 4. Производит ввод необходимых данных конкретно для этих операций и 
        /// вызывает соответствующие методы для рассчетов и вывода.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        private static void ActivateThirdSet(int operation)
        {
            if ((operation == 3) || (operation == 4))
            {
                Console.WriteLine("Как Вы хотите определить размер матрицы?");
                int choice = ChooseHowToDecideSize(), rows = 0, cols = 0;
                if (choice == 1)
                {
                    Random rnd = new Random();
                    rows = rnd.Next(1, 11);
                    cols = rnd.Next(1, 11);
                    Console.WriteLine($"Размер матрицы {rows}x{cols}");
                }
                else if (choice == 2)
                {
                    do
                    {
                        Console.Write("Число строк матрицы: ");
                    } while ((!int.TryParse(Console.ReadLine(), out rows)) | (rows < 1));
                    do
                    {
                        Console.Write("Число столбцов матрицы: ");
                    } while ((!int.TryParse(Console.ReadLine(), out cols)) | (cols < 1));
                }
                double[,] firstMatrix = new double[rows, cols];
                double[,] secondMatrix = new double[rows, cols];
                CompleteThirdSet(operation, rows, cols, firstMatrix, secondMatrix);
            }
        }
        /// <summary>
        /// Метод, вызываемый при выборе операции перемножения двух матриц (5). Производит ввод необходимых данных конкретно для этих операций и 
        /// вызывает соответствующие методы для рассчетов и вывода.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        private static void ActivateMultiplication(int operation)
        {
            if (operation == 5)
            {
                Console.WriteLine("Как Вы хотите определить размер матрицы?");
                int choice = ChooseHowToDecideSize(), rows = 0, midColsRows = 0, cols = 0;
                if (choice == 1)
                {
                    Random rnd = new Random();
                    rows = rnd.Next(1, 11);
                    midColsRows = rnd.Next(1, 11);
                    cols = rnd.Next(1, 11);
                    Console.WriteLine($"Размер первой матрицы {rows}x{midColsRows}");
                    Console.WriteLine($"Размер второй матрицы {midColsRows}x{cols}");
                }
                else if (choice == 2)
                {
                    do
                    {
                        Console.Write("Число строк первой матрицы: ");
                    } while ((!int.TryParse(Console.ReadLine(), out rows)) | (rows < 1));
                    do
                    {
                        Console.Write("Число столбцов первой матрицы (и строк второй): ");
                    } while ((!int.TryParse(Console.ReadLine(), out cols)) | (cols < 1));
                    do
                    {
                        Console.Write("Число столбцов второй матрицы: ");
                    } while ((!int.TryParse(Console.ReadLine(), out cols)) | (cols < 1));
                }
                double[,] firstMatrix = new double[rows, midColsRows];
                double[,] secondMatrix = new double[midColsRows, cols];
                CompleteMultiplication(operation, rows, midColsRows, cols, firstMatrix, secondMatrix);
            }
        }
        /// <summary>
        /// Метод, позволяющий пользователю выбрать, подобрать ли "радномный" размер для матриц или ввести их самому.
        /// </summary>
        /// <returns>Возвращает значение "1", чтобы данные сгенерировал компьютер, и "2", чтобы их ввёл пользователь.</returns>
        private static int ChooseHowToDecideSize()
        {
            int choice;
            Console.WriteLine(@"
Компьютер может задать размерность случайным образом, или же Вы можете ввести её сами.
1. Генерация случайным образом (Введите ""1"")
2. Ввод с клавиатуры (Введите ""2"")
");
            do
            {
                Console.Write("Способ выбора размерности: ");
            } while ((!int.TryParse(Console.ReadLine(), out choice)) | ((choice != 1) & (choice != 2)));
            return choice;
        }
        /// <summary>
        /// Метод, создающий матрицу с необходимыми для операции условиями (в данном случае матрица должна быть квадратной)
        /// и выводящий матрицу(-ы) на консоль.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        /// <param name="order">Порядок матрицы</param>
        private static void CompleteFirstSet(int operation, int order, double[,] matrix)
        {
            int choice = ChooseHowToCreateMatrix();
            if (choice == 1)
            {
                matrix = GenerateRandomMatrix(order, order);
                MatrixOutput(matrix);
                OutputFirstSet(operation, matrix);
            }
            else if (choice == 2)
            {
                matrix = UserInputMatrix(order, order);
                MatrixOutput(matrix);
                OutputFirstSet(operation, matrix);
            }
        }
        /// <summary>
        /// Метод, производящий для каждой операции 1го набора конкретный вывод.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        /// <param name="matrix">Матрица, над которой произвелись действия.</param>
        private static void OutputFirstSet(int operation, double[,] matrix)
        {
            if (operation == 1)
            {
                FindMatrixTrace(matrix);
            }
            else if (operation == 7)
            {
                Console.WriteLine($"Определитель матрицы равен {FindDeterminant(matrix)}");
            }
        }
        /// <summary>
        /// Метод, создающий матрицу и выводящий матрицу на консоль.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        /// <param name="row">Число строк матрицы.</param>
        /// <param name="col">Число столбцов матрицы.</param>
        /// <param name="matrix">Матрица, над которой произвелись действия.</param>
        private static void CompleteSecondSet(int operation, int row, int col, double[,] matrix)
        {
            int choice = ChooseHowToCreateMatrix();
            if (choice == 1)
            {
                matrix = GenerateRandomMatrix(row, col);
                MatrixOutput(matrix);
                OutputSecondSet(operation, matrix);
            }
            else if (choice == 2)
            {
                matrix = UserInputMatrix(row, col);
                MatrixOutput(matrix);
                OutputSecondSet(operation, matrix);
            }

        }
        /// <summary>
        /// Метод, производящий для каждой операции 2го набора конкретный вывод.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        /// <param name="matrix">Матрица, над которой произвелись действия.</param>
        private static void OutputSecondSet(int operation, double[,] matrix)
        {
            if (operation == 2)
            {
                double[,] transposeMatrix = GetTransposeOfMatrix(matrix);
                Console.WriteLine("Транспонированная матрица:");
                MatrixOutput(transposeMatrix);
            }
            else if (operation == 6)
            {
                matrix = ScalarMultiplyMatrix(matrix);
                Console.WriteLine("Результат умножения матрицы на число: ");
                MatrixOutput(matrix);
            }
            else if (operation == 8)
            {
                Console.WriteLine("Решение СЛАУ:");
                SystemOfLinearEquations(ReachReducedRowEchelon(matrix));
            }
        }
        /// <summary>
        /// Метод, создающий две матрицы одинаковых размеров и выводящий их на экран.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        /// <param name="row">Число строк матриц.</param>
        /// <param name="col">Число столбцов матриц.</param>
        /// <param name="firstMatrix">Матрица, нужная для действия.</param>
        /// <param name="secondMatrix">Матрица, нужная для действия.</param>
        private static void CompleteThirdSet(int operation, int row, int col, double[,] firstMatrix, double[,] secondMatrix)
        {
            int choice = ChooseHowToCreateMatrix();
            if (choice == 1)
            {
                firstMatrix = GenerateRandomMatrix(row, col);
                secondMatrix = GenerateRandomMatrix(row, col);
                MatrixOutput(firstMatrix);
                MatrixOutput(secondMatrix);
                OutputThirdSet(operation, firstMatrix, secondMatrix);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Первая матрица");
                firstMatrix = UserInputMatrix(row, col);
                Console.WriteLine("Вторая матрица");
                secondMatrix = UserInputMatrix(row, col);
                MatrixOutput(firstMatrix);
                MatrixOutput(secondMatrix);
                OutputThirdSet(operation, firstMatrix, secondMatrix);
            }
        }
        /// <summary>
        /// Метод, производящий для каждой операции 3го набора конкретный вывод.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        /// <param name="firstMatrix">Матрица, нужная для действия.</param>
        /// <param name="secondMatrix">Матрица, нужная для действия.</param>
        private static void OutputThirdSet(int operation, double[,] firstMatrix, double[,] secondMatrix)
        {
            if (operation == 3)
            {
                Console.WriteLine("Сумма матриц:");
                CombineMatrices(firstMatrix, secondMatrix);
            }
            else if (operation == 4)
            {
                Console.WriteLine("Разность матриц:");
                SubtractMatrices(firstMatrix, secondMatrix);
            }
        }
        /// <summary>
        /// Метод, создающий две матрицы подходящих для перемножения размеров и выводящий на экран изначальные матрицы
        /// и результат их перемножения.
        /// </summary>
        /// <param name="operation">Номер операции, выбранной пользователем.</param>
        /// <param name="row">Число строк первой матрицы.</param>
        /// <param name="mid">Число столбцов первой матрицы и, соответсвенно, число строк второй матрицы.</param>
        /// <param name="col">Число столбцов второй матрицы.</param>
        /// <param name="firstMatrix">Матрица, нужная для действия</param>
        /// <param name="secondMatrix">Матрица, нужная для действия</param>
        private static void CompleteMultiplication(int operation, int row, int mid, int col, double[,] firstMatrix, double[,] secondMatrix)
        {
            int choice = ChooseHowToCreateMatrix();
            if (choice == 1)
            {
                firstMatrix = GenerateRandomMatrix(row, mid);
                secondMatrix = GenerateRandomMatrix(mid, col);
                MatrixOutput(firstMatrix);
                MatrixOutput(secondMatrix);
                Console.WriteLine("Произведение матриц:");
                MultiplyMatrices(firstMatrix, secondMatrix);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Первая матрица");
                firstMatrix = UserInputMatrix(row, mid);
                Console.WriteLine("Вторая матрица");
                secondMatrix = UserInputMatrix(mid, col);
                MatrixOutput(firstMatrix);
                MatrixOutput(secondMatrix);
                Console.WriteLine("Произведение матриц:");
                MultiplyMatrices(firstMatrix, secondMatrix);
            }
        }
        /// <summary>
        /// Метод, позволяющий пользователю выбрать способ создания матриц.
        /// </summary>
        /// <returns>Возвращает значение "1", чтобы матрицу(-ы) сгенерировал компьютер, и "2", чтобы это ввёл пользователь.</returns>
        private static int ChooseHowToCreateMatrix()
        {
            Console.WriteLine(@"
Как бы вы хотели создать матрицу?
1. Генерация случайным образом (Введите ""1"")
2. Ввод с клавиатуры (Введите ""2"")
");
            int choice = 0;
            do
            {
                Console.Write("Способ создания матрицы: ");
            } while ((!int.TryParse(Console.ReadLine(), out choice)) | ((choice != 1) & (choice != 2)));
            return choice;
        }
        /// <summary>
        /// Выбор одной из операций над матрицами.
        /// </summary>
        /// <returns>Возвращает целое число - номер операции, выбранной пользователем (от 1 до 8).</returns>
        private static int ChooseOperation()
        {
            int operation = 0;
            do
            {
                Console.Clear();
                IntroduceUser();
                Console.Write("Какую операцию Вы хотите выполнить? ");
            } while ((!int.TryParse(Console.ReadLine(), out operation)) | (operation < 1) | (operation > 8));
            return operation;
        }
        /// <summary>
        /// Метод, предназначенный на вывод основной информации на экран.
        /// </summary>
        private static void IntroduceUser()
        {
            Console.WriteLine(@"
Вы работаете с программой ""Калькулятор матрицы""! Данная программа производит основные операции над матрицами. Какую операцию Вы хотите выполнить?
1. Нахождение следа матрицы (Введите ""1"")
2. Транспопонирование матрицы (Введите ""2"")
3. Сумма двух матриц (Введите ""3"")
4. Разность двух матриц (Введите ""4"")
5. Произведение двух матриц (Введите ""5"")
6. Умножение матрицы на число (Введите ""6"")
7. Нахождение определителя матрицы (Введите ""7"")
8. Решение СЛАУ (Введите ""8"")
Перед работой программой просмотрите, пожалуйста, текстовый файл ReadMe, если Вы еще этого не сделали.
");
        }
        /// <summary>
        /// Метод, позволяющий пользователю самостоятельно ввести каждый элемент матрицы.
        /// </summary>
        /// <param name="rows">Число строк матрицы.</param>
        /// <param name="cols">Число столбцов матрицы.</param>
        /// <returns>Возвращает вновь введённую матрицу.</returns>
        private static double[,] UserInputMatrix(int rows, int cols)
        {
            double[,] inputMatrix = new double[rows, cols];
            for (int n = 0; n < inputMatrix.GetLength(0); n++)
            {
                Console.WriteLine($"Строка {n + 1}");
                for (int m = 0; m < inputMatrix.GetLength(1); m++)
                {
                    double element = 0;
                    do
                    {
                        Console.Write("");
                    } while (!double.TryParse(Console.ReadLine(), out element));
                    inputMatrix[n, m] = element;
                }
            }
            return inputMatrix;
        }
        /// <summary>
        /// Метод, генерирующий "рандомную" матрицу.
        /// </summary>
        /// <param name="rows">Число строк матрицы.</param>
        /// <param name="cols">Число столбцов матрицы.</param>
        /// <returns>Возвращает сгенерированную матрицу.</returns>
        private static double[,] GenerateRandomMatrix(int rows, int cols)
        {
            double[,] randomMatrix = new double[rows, cols];
            Random rnd = new Random();
            for (int n = 0; n < randomMatrix.GetLength(0); n++)
            {
                for (int m = 0; m < randomMatrix.GetLength(1); m++)
                {
                    randomMatrix[n, m] = rnd.Next(-100, 101);
                }
            }
            return randomMatrix;
        }
        /// <summary>
        /// Метод, считающий след матрицы и выводящий его.
        /// </summary>
        /// <param name="matrix">Матрица, для которой нужно рассчитать след.</param>
        private static void FindMatrixTrace(double[,] matrix)
        {
            double trace = 0;
            for (int n = 0; n < matrix.GetLength(0); n++)
            {
                trace += matrix[n, n];
            }
            Console.WriteLine($"След матрицы равен {trace}");

        }
        /// <summary>
        /// Метод для транспозиции матрицы.
        /// </summary>
        /// <param name="matrix">Матрица, которую нужно транспонировать.</param>
        /// <returns>Возвращает транспонированную матрицу.</returns>
        private static double[,] GetTransposeOfMatrix(double[,] matrix)
        {
            double[,] transposeMatrix = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int n = 0; n < transposeMatrix.GetLength(0); n++)
            {
                for (int m = 0; m < transposeMatrix.GetLength(1); m++)
                {
                    transposeMatrix[n, m] = matrix[m, n];
                }
            }

            return transposeMatrix;
        }
        /// <summary>
        /// Метод, считающий сумму двух матриц и выводящий её.
        /// </summary>
        /// <param name="firstMatrix">Матрица - первое слагаемое.</param>
        /// <param name="secondMatrix">Матрица - второй слагаемое.</param>
        private static void CombineMatrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            double[,] sumMatrix = new double[firstMatrix.GetLength(0), firstMatrix.GetLength(1)];
            for (int n = 0; n < firstMatrix.GetLength(0); n++)
            {
                for (int m = 0; m < firstMatrix.GetLength(1); m++)
                {
                    sumMatrix[n, m] = firstMatrix[n, m] + secondMatrix[n, m];
                }
            }
            MatrixOutput(sumMatrix);
        }
        /// <summary>
        /// Метод, считающий разность двух матриц и выводящий её.
        /// </summary>
        /// <param name="firstMatrix">Первая матрица - уменьшаемое.</param>
        /// <param name="secondMatrix">Вторая матрица - вычитаемое.</param>
        private static void SubtractMatrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            double[,] differenceMatrix = new double[firstMatrix.GetLength(0), firstMatrix.GetLength(1)];
            for (int n = 0; n < firstMatrix.GetLength(0); n++)
            {
                for (int m = 0; m < firstMatrix.GetLength(1); m++)
                {
                    differenceMatrix[n, m] = firstMatrix[n, m] - secondMatrix[n, m];
                }
            }
            MatrixOutput(differenceMatrix);
        }
        /// <summary>
        /// Метод, считающий произведение двух матриц и выводящий его.
        /// </summary>
        /// <param name="multiplier">Матрица - первый множитель.</param>
        /// <param name="multiplicand">Матрица - второй множитель.</param>
        private static void MultiplyMatrices(double[,] multiplier, double[,] multiplicand)
        {
            double[,] productMatrix = new double[multiplier.GetLength(0), multiplicand.GetLength(1)];
            for (int n = 0; n < multiplier.GetLength(0); n++)
            {
                for (int m = 0; m < multiplicand.GetLength(1); m++)
                {
                    for (int p = 0; p < multiplier.GetLength(1); p++)
                    {
                        productMatrix[n, m] += multiplier[n, p] * multiplicand[p, m];
                    }
                }
            }
            MatrixOutput(productMatrix);
        }
        /// <summary>
        /// Метод, проиводящий ввод числа (множителя) и считающий результат умножения матрицы на число.
        /// </summary>
        /// <param name="matrix">Матрица, которую необходим умножить на число.</param>
        /// <returns>Возвращает результат умножения.</returns>
        private static double[,] ScalarMultiplyMatrix(double[,] matrix)
        {
            double multiplier;
            do
            {
                Console.Write("На какое число Вы хотите умножить матрицу? ");
            } while (!double.TryParse(Console.ReadLine(), out multiplier));
            double[,] product = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int n = 0; n < matrix.GetLength(0); n++)
            {
                for (int m = 0; m < matrix.GetLength(1); m++)
                {
                    product[n, m] = matrix[n, m] * multiplier;
                }
            }
            return product;
        }
        /// <summary>
        /// Метод, рассчитывающий определитель (детерминант) матрицы.
        /// </summary>
        /// <param name="matrix">Матрица, для которой нужно рассчитать определитель.</param>
        /// <returns>Вовзращает число - значение определителя матрицы.</returns>
        private static double FindDeterminant(double[,] matrix)
        {
            int i = matrix.GetLength(0);
            if (i == 1)
            {
                return matrix[0, 0];
            }
            else if (i == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double[,] subMatrix = new double[i - 1, i - 1];
                double det = 0;
                int row, col;
                for (int n = 0; n < i; n++)
                {
                    row = 0;
                    for (int m = 1; m < i; m++)
                    {
                        col = 0;
                        for (int p = 0; p < i; p++)
                        {
                            if (p != n)
                            {
                                subMatrix[row, col] = matrix[m, p];
                                col++;
                            }
                        }
                        row++;
                    }
                    det += Math.Pow(-1, (double)n + 2) * matrix[0, n] * FindDeterminant(subMatrix);
                }
                return det;
            }
        }
        /// <summary>
        /// Метод, приводящий матрицу к улучшенному ступенчатому виду (форма метода Гаусса). 
        /// Использован подработанный для C# и данной программы алгоритм с Википедии https://en.wikipedia.org/wiki/Row_echelon_form.
        /// Предназначен для использования в решении СЛАУ.
        /// </summary>
        /// <param name="matrix">Матрица, которую нужно привести к каноническому виду.</param>
        /// <returns>Возвращает преобразованную матрицу.</returns>
        private static double[,] ReachReducedRowEchelon(double[,] matrix)
        {
            int lead = 0, rowCount = matrix.GetLength(0), columnCount = matrix.GetLength(1);
            for (int r = 0; r < rowCount; r++)
            {
                if (columnCount <= lead) break;
                int i = r;
                while (matrix[i, lead] == 0)
                {
                    i++;
                    if (i == rowCount)
                    {
                        i = r;
                        lead++;
                        if (columnCount == lead)
                        {
                            lead--;
                            break;
                        }
                    }
                }
                SwapRows(matrix, columnCount, r, i);
                DivideStep(matrix, lead, columnCount, r);
                for (int j = 0; j < rowCount; j++)
                {
                    if (j != r)
                    {
                        double sub = matrix[j, lead];
                        for (int k = 0; k < columnCount; k++) matrix[j, k] -= (sub * matrix[r, k]);
                    }
                }
                lead++;
            }
            return matrix;
        }
        /// <summary>
        /// Метод, представляющий решение СЛАУ.
        /// </summary>
        /// <param name="matrix">Матричная форма СЛАУ.</param>
        private static void SystemOfLinearEquations(double[,] matrix)
        {
            string[,] equationMatrix = new string[matrix.GetLength(0), matrix.GetLength(1)];
            for (int n = 0; n < matrix.GetLength(0); n++)
            {
                for (int m = 0; m < matrix.GetLength(1); m++)
                {
                    if (m != matrix.GetLength(1) - 1)
                    {
                        if (matrix[n, m] == 1)
                        {
                            equationMatrix[n, m] = $"x{m + 1}";
                        }
                        else if (matrix[n, m] == -1)
                        {
                            equationMatrix[n, m] = $"-x{m + 1}";
                        }
                        else if (matrix[n, m] == 0)
                        {
                            equationMatrix[n, m] = "0";
                        }
                        else
                        {
                            string element = matrix[n, m].ToString("F2");
                            equationMatrix[n, m] = $"{element}*x{m + 1}";
                        }
                    }
                    else
                    {
                        string element = matrix[n, m].ToString("F2");
                        equationMatrix[n, m] = element;
                    }
                }
            }
            StringMatrixOutput(equationMatrix);

        }
        /// <summary>
        /// Метод, производящие нужные преобрзования строк для корректного вида уравнения.
        /// </summary>
        /// <param name="equationMatrix">СЛАУ в виде обычной матрицы.</param>
        private static void StringMatrixOutput(string[,] equationMatrix)
        {
            for (int n = 0; n < equationMatrix.GetLength(0); n++)
            {
                string outputLine = "";
                for (int m = 0; m < equationMatrix.GetLength(1); m++)
                {
                    if ((m == 0) & (equationMatrix[n, m] != "0"))
                    {
                        outputLine += equationMatrix[n, m];
                    }
                    else if ((m == equationMatrix.GetLength(1) - 1) & (outputLine.Contains('x')))
                    {
                        outputLine += $"={equationMatrix[n, m]}";
                    }
                    else
                    {
                        outputLine = AddCorrectSymbol(equationMatrix, n, outputLine, m);
                    }
                }
                if ((!outputLine.Contains('=')) & (outputLine != "0"))
                {
                    Console.WriteLine(outputLine);
                    Console.WriteLine("У СЛАУ нет решений");
                    break;
                }
                else
                {
                    Console.WriteLine(outputLine);
                }
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// Метод, добавлящий знаки "+", "-" или "=" в нужный позициях для уравнения.
        /// </summary>
        /// <param name="equationMatrix">СЛАУ в виде обычной матрицы.</param>
        /// <param name="n">Индекс строки</param>
        /// <param name="outputLine">Строка вывода, которая позволит узнать решение уравнения.</param>
        /// <param name="m">Индекс столбца</param>
        /// <returns></returns>
        private static string AddCorrectSymbol(string[,] equationMatrix, int n, string outputLine, int m)
        {
            if (equationMatrix[n, m] != "0")
            {
                if (equationMatrix[n, m].Contains('-'))
                {
                    outputLine += $"{equationMatrix[n, m]}";
                }
                else
                {
                    if (outputLine.Length < 1)
                    {
                        outputLine += $"{equationMatrix[n, m]}";
                    }
                    else
                    {
                        outputLine += $"+{equationMatrix[n, m]}";
                    }
                }
            }

            return outputLine;
        }
        /// <summary>
        /// Шаг, используемый в преобразовании матрицы методом Гаусса - деление строки на число.
        /// </summary>
        /// <param name="matrix">Матрица, в которой происходит деление.</param>
        /// <param name="col">Индекс столбца.</param>
        /// <param name="columnCount">Число столбцов.</param>
        /// <param name="row">Индекс строки.</param>
        private static void DivideStep(double[,] matrix, int col, int columnCount, int row)
        {
            double div = matrix[row, col];
            if (div != 0)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    matrix[row, j] /= div;
                }
            }
        }
        /// <summary>
        /// Шаг, используемый в преобразовании матрицы методом Гаусса - перестановка строк.
        /// </summary>
        /// <param name="matrix">Матрица, в которой происходит изменение..</param>
        /// <param name="columnCount">Число столбцов.</param>
        /// <param name="firstRow">Индекс одной строки.</param>
        /// <param name="secondRow">Индекс второй строки.</param>
        private static void SwapRows(double[,] matrix, int columnCount, int firstRow, int secondRow)
        {
            for (int j = 0; j < columnCount; j++)
            {
                double temp = matrix[firstRow, j];
                matrix[firstRow, j] = matrix[secondRow, j];
                matrix[secondRow, j] = temp;
            }
        }
        /// <summary>
        /// Метод, производящий корректный вывод матрица на консоль.
        /// </summary>
        /// <param name="matrix">Выводимая матрица.</param>
        private static void MatrixOutput(double[,] matrix)
        {
            Console.WriteLine("");
            for (int n = 0; n < matrix.GetLength(0); n++)
            {
                string outputLine = "";
                for (int m = 0; m < matrix.GetLength(1); m++)
                {
                    if (Math.Abs(matrix[n, m]) == 0)
                    {
                        matrix[n, m] = 0;
                    }
                    if (Math.Abs(matrix[n, m] - Math.Round(matrix[n, m])) == 0)
                    {
                        outputLine += $"{matrix[n, m]}\t";
                    }
                    else
                    {
                        string output = matrix[n, m].ToString("F2");
                        outputLine += $"{output}\t";
                    }

                }
                Console.WriteLine(outputLine);
            }
            Console.WriteLine("");
        }
    }
}
