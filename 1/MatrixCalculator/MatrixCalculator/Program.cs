using System;

namespace MatrixCalculator
{
    /// <summary>
    ///  Класс реализации приложения "Калькулятор матриц".
    /// </summary>
    class MatrixCalculator
    {
        /// <summary>
        /// Вывод текста, предлагающего пользователю выбрать операцию над матрицей.
        /// </summary>
        static void InterfaceText1()
        {
            Console.WriteLine("Всего есть 7 опций:\n" +
                "1) Нахождение следа матрицы;\n" +
                "2) Транспонирование матрицы;\n" +
                "3) Сумма двух матриц;\n" +
                "4) Разница двух матриц;\n" +
                "5) Произведение двух матриц;\n" +
                "6) Умножение матрицы на число;\n" +
                "7) Нахождение определителя матрицы;\n");
        }

        /// <summary>
        /// Выбор операции, производимой над матрицей.
        /// </summary>
        /// <returns></returns>
        static int ChooseAnOperation()
        {
            int operationType;
            do
            {
                Console.Write("Введите номер операции: ");
                string operationNumber0 = Console.ReadLine().ToString();
                if ((!int.TryParse(operationNumber0, out operationType)) || operationType < 1 || operationType > 7)
                {
                    do
                    {
                        Console.WriteLine("Кажется, Вы ввели что-то другое, нежели цифру от 1 до 7.\n");
                        Console.Write("Введите номер снова: ");
                        operationNumber0 = Console.ReadLine();
                    } while ((!int.TryParse(operationNumber0, out operationType)) || operationType < 1
                    || operationType > 7);
                }
                Console.WriteLine("Если хотите выбрать другую опцию, нажмите клавишу стрелочки влево,\n" +
                    "или любую другую клавишу, чтобы продолжить.");
            } while (Console.ReadKey(true).Key == ConsoleKey.LeftArrow);
            return operationType;
        }

        /// <summary>
        /// Выбор способа генерации матрицы.
        /// </summary>
        /// <returns></returns>
        static int ChooseTypeOfGeneration()
        {
            int generationNumber;
            do
            {
                Console.WriteLine("\nCпособы генерации матрицы:\n" +
                    "1) И размер, и элементы задаются Вами;\n" +
                    "2) Размер задается Вами, элементы задаются компьютером;\n" +
                    "3) Размер задается компьютером, элементы задаются Вами;\n" +
                    "4) И размер, и элементы задаются компьютером;\n" +
                    "Чтобы выбрать способ, нужно ввести соответствующий ему номер.\n");
                Console.Write("Введите номер способа: ");
                string generationNumber0 = Console.ReadLine();
                if (!int.TryParse(generationNumber0, out generationNumber) ||
                    generationNumber < 1 || generationNumber > 4)
                {
                    while (!int.TryParse(generationNumber0, out generationNumber) ||
                    generationNumber < 1 || generationNumber > 4)
                    {
                        Console.WriteLine("Вы ввели что-то другое, а не цифру от 1 до 4");
                        Console.Write("\nВведите номер способа снова: ");
                        generationNumber0 = Console.ReadLine();
                    }
                }
                Console.Write("Если хотите выбрать другой способ, нажмите клавишу стрелки влево,\n" +
                    "или любую другую клавишу, если хотите продолжить.\n");
            } while (Console.ReadKey(true).Key == ConsoleKey.LeftArrow);
            return generationNumber;
        }

        /// <summary>
        /// Вычленение количества строк из rowsColumns.
        /// </summary>
        /// <param name="rowsColumns">Строка, содержащая количество строк и столбцов в типе string.</param>
        /// <returns></returns>
        static int Rows(string rowsColumns)
        {
            int rows = 0;
            if (rowsColumns.Length == 4)
            {
                rows = 10;
            }
            if (rowsColumns.Length == 3)
            {
                if (rowsColumns[0] == '1')
                {
                    rows = 10;
                }
                if (rowsColumns[2] == '0')
                {
                    rows = int.Parse(rowsColumns[0].ToString());
                }
            }
            if (rowsColumns.Length == 2)
            {
                rows = int.Parse(rowsColumns[0].ToString());
            }
            return rows;
        }

        /// <summary>
        /// Вычленение количества столбцов из rowColumns.
        /// </summary>
        /// <param name="rowsColumns">Строка, содержащая количество строк и столбцов в типе strig.</param>
        /// <returns></returns>
        static int Columns(string rowsColumns)
        {
            int columns = 0;
            if (rowsColumns.Length == 4)
            {
                columns = 10;
            }
            if (rowsColumns.Length == 3)
            {
                if (rowsColumns[0] == '1')
                {
                    columns = int.Parse(rowsColumns[2].ToString());
                }
                if (rowsColumns[2] == '0')
                {
                    columns = 10;
                }
            }
            if (rowsColumns.Length == 2)
            {
                columns = int.Parse(rowsColumns[1].ToString());
            }
            return columns;

        }
        /// <summary>
        /// Метод, генерирующий матрицу первым из предложенных способом.
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        /// <returns></returns>
        static double[,] GenerationTypeOne(int operationType)
        {
            double[,] matrix = new double[0, 0];
            string rowsColumns = InputSizeByUser(operationType);
            int rows = Rows(rowsColumns);
            int columns = Columns(rowsColumns);
            matrix = MatrixElementsByUser(rows, columns);
            Console.WriteLine($"\nВаша матрица размера [{rows},{columns}]:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,7}", Math.Round(matrix[i, j], 2));
                }
                Console.WriteLine();
            }
            return matrix;
        }

        /// <summary>
        /// Метод, генерирующий матрицу вторым из предложенных способом.
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        /// <returns></returns>
        static double[,] GenerationTypeTwo(int operationType)
        {
            string rowsColumns = InputSizeByUser(operationType);
            int rows = Rows(rowsColumns);
            int columns = Columns(rowsColumns);
            double[,] matrix = MatrixElementsByComputer(rows, columns);
            Console.WriteLine($"\nВаша матрица размера [{rows},{columns}]:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,7}", Math.Round(matrix[i, j], 2));
                }
                Console.WriteLine();
            }
            return matrix;

        }

        /// <summary>
        /// Метод, генерирующий матрицу третьим из предложенных способом.
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        /// <returns></returns>
        static double[,] GenerationTypeThree(int operationType)
        {
            string rowsColumns = InputSizeByComputer(operationType);
            int rows = Rows(rowsColumns);
            int columns = Columns(rowsColumns);
            double[,] matrix = MatrixElementsByUser(rows, columns);
            Console.WriteLine($"\nВаша матрица размера [{rows},{columns}]:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,7}", Math.Round(matrix[i, j], 2));
                }
                Console.WriteLine();

            }
            return matrix;
        }

        /// <summary>
        /// Метод, генерирующий матрицу четвертым из предложенных способом.
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        /// <returns></returns>
        static double[,] GenerationTypeFour(int operationType)
        {
            string rowsColumns = InputSizeByComputer(operationType);
            int rows = Rows(rowsColumns);
            int columns = Columns(rowsColumns);
            double[,] matrix = MatrixElementsByComputer(rows, columns);
            Console.WriteLine($"\nВаша матрица размера [{rows},{columns}]:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,7}", Math.Round(matrix[i, j], 2));
                }
                Console.WriteLine();

            }
            return matrix;
        }

        /// <summary>
        /// Ограничения на вводимое пользователем количество строк и столбцов.
        /// </summary>
        /// <param name="rows0">Введенное количество строк.</param>
        /// <param name="columns0">Введенное количество столбцов.</param>
        /// <returns></returns>
        static string Restriction(string rows0, string columns0)
        {
            int rows, columns;
            while (!int.TryParse(rows0, out rows) || !int.TryParse(columns0, out columns) ||
                    rows < 2 || columns < 2 || rows > 10 || columns > 10)
            {
                Console.WriteLine("Вы ввели не цифры от 2 до 10, попробуйте еще раз");
                Console.Write("\nВведите количество строк: ");
                rows0 = Console.ReadLine();
                Console.Write("Введите количество столбцов: ");
                columns0 = Console.ReadLine();
            }
            return rows0 + columns0;
        }

        /// <summary>
        /// Ввод размеров матрицы пользователем.
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param> 
        static string InputSizeByUser(int operationType)
        {
            Console.WriteLine("\nЗадайте размеры матрицы (количество строк и столбцов) в виде цифр от 2 до 10.");
            Console.Write("\nКоличество строк: ");
            string rows0 = Console.ReadLine();
            Console.Write("Количество столбцов: ");
            string columns0 = Console.ReadLine();
            if (operationType == 1 || operationType == 7)
            {
                columns0 = rows0;
            }
            string rowsColumns = Restriction(rows0, columns0);
            return rowsColumns;
        }

        /// <summary>
        /// Ввод размеров матрицы компьютером.
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        /// <returns></returns>
        static string InputSizeByComputer(int operationType)
        {
            var randomSize = new Random();
            int rows = randomSize.Next(2, 10);
            int columns = randomSize.Next(2, 10);
            if (operationType == 1 || operationType == 7)
            {
                columns = rows;
            }
            return rows.ToString() + columns.ToString();
        }

        /// <summary>
        /// Ввод элементов матрицы предоставляется пользователю.
        /// </summary>
        /// <param name="rows">Количесвто строк.</param>
        /// <param name="columns">Количество столбцов.</param>
        /// <returns></returns>
        static double[,] MatrixElementsByUser(int rows, int columns)
        {
            double[,] matrix = new double[rows, columns];
            Console.WriteLine($"\nРазмер матрицы: [{rows},{columns}].");
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"\nВводите по очереди элементы для строки {i}. Вводить можно\n" +
                    $"любые числа от -50 до 50 включительно.\n");
                for (int j = 0; j < columns; j++)
                {
                    double element;
                    Console.Write($"Элемент [{i},{j}]: ");
                    string element0 = Console.ReadLine();
                    while (!double.TryParse(element0, out element) || (double)element < -50
                        || (double)element > 50)
                    {
                        Console.WriteLine("Вы ввели не число от -50 до 50.");
                        Console.Write($"Элемент [{i},{j}]: ");
                        element0 = Console.ReadLine();
                    }
                    matrix[i, j] = element;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Ввод элементов матрицы предоставляется компьютеру.
        /// </summary>
        /// <param name="rows">Количество строк матрицы.</param>
        /// <param name="columns">Количество столбцов матрицы.</param>
        /// <returns></returns>
        static double[,] MatrixElementsByComputer(int rows, int columns)
        {
            double[,] matrix = new double[rows, columns];
            Console.WriteLine("\nКомпьютер сгенерирует элементы, принадлежащие промежутку от -50 до 50\n" +
                "в типе double.\n");
            var randomElement = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    double matrix0 = randomElement.NextDouble();
                    double matrix1 = randomElement.Next(-50, 50);
                    matrix[i, j] = matrix0 * matrix1;
                }
            }
            return matrix;
        }

        /// <summary>
        /// В зависимости от введенного номера способа генерации вызывает методы для его выполнения.
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        /// <returns></returns>
        static double[,] GenerationSwitch(int operationType)
        {
            double[,] matrix = new double[0, 0];
            int generationType = ChooseTypeOfGeneration();
            switch (generationType)
            {
                case 1:
                    matrix = GenerationTypeOne(operationType);
                    break;
                case 2:
                    matrix = GenerationTypeTwo(operationType);
                    break;
                case 3:
                    matrix = GenerationTypeThree(operationType);
                    break;
                case 4:
                    matrix = GenerationTypeFour(operationType);
                    break;
            }
            return matrix;
        }

        /// <summary>
        /// Метод, реализующий операцию "Нахождение следа матрицы".
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        static void FirstOperation(int operationType)
        {
            Console.WriteLine("Для этой операции нужна квадратная матрица, поэтому, если Вы введете\n" +
                "различное количество строк и столбцов, компьютер приравняет количество столбцов к\n" +
                "количеству строк.");
            double[,] matrix = GenerationSwitch(operationType);
            double trace = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                trace += matrix[i, i];
            }
            Console.WriteLine($"\nСлед матрицы: {Math.Round(trace, 2)}");
        }

        /// <summary>
        /// Метод, реализующий операцию "Транспонирование матрицы.
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        static void SecondOperation(int operationType)
        {
            double[,] matrix = GenerationSwitch(operationType);
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            Console.WriteLine($"\nТранспонированная матрица размера [{columns},{rows}]: ");
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write("{0,7}", Math.Round(matrix[j, i], 2));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод, реализующий операцию "Сумма двух матриц".
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        static void ThirdOperation(int operationType)
        {
            Console.WriteLine("\nДля этой операции нужны две матрицы одинакового размера.");
            Console.WriteLine("\nГенерация первой матрицы...");
            double[,] firstMatrix = GenerationSwitch(operationType);
            int rows = firstMatrix.GetLength(0);
            int columns = firstMatrix.GetLength(1);
            Console.WriteLine("\nГенерация второй матрицы...");
            double[,] secondMatrix = GenerationSwitch(operationType);
            while (secondMatrix.GetLength(0) != rows && secondMatrix.GetLength(1) != columns)
            {
                Console.WriteLine($"\nКрасивая матрица. Но она должна быть того же размера,\n" +
                    $"что и первая([{rows},{columns}]).");
                secondMatrix = GenerationSwitch(operationType);
            }
            Console.WriteLine("\nСумма ваших матриц:");
            double[,] sumMatrix = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sumMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                    Console.Write("{0,7}", Math.Round(sumMatrix[i, j], 2));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод, реализующий операцию "Разность двух матриц".
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        static void FourthOperation(int operationType)
        {
            Console.WriteLine("\nДля этой операции нужны две матрицы одинакового размера.");
            Console.WriteLine("\nГенерация первой матрицы...");
            double[,] firstMatrix = GenerationSwitch(operationType);
            int rows = firstMatrix.GetLength(0);
            int columns = firstMatrix.GetLength(1);
            Console.WriteLine("\nГенерация второй матрицы...");
            double[,] secondMatrix = GenerationSwitch(operationType);
            while (secondMatrix.GetLength(0) != rows && secondMatrix.GetLength(1) != columns)
            {
                Console.WriteLine($"\nКрасивая матрица. Но она должна быть того же размера,\n" +
                    $"что и первая([{rows},{columns}]).");
                secondMatrix = GenerationSwitch(operationType);
            }
            Console.WriteLine("\nМатрица-разность первой и второй матриц:");
            double[,] sumMatrix = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sumMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                    Console.Write("{0,7}", Math.Round(sumMatrix[i, j], 2));
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Метод, реализующий операцию "Произведение двух матриц".
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        static void FifthOperation(int operationType)
        {
            Console.WriteLine("\nДля этой операции нужно чтобы количество столбцов первой матрицы \n" +
                "совпадало с количеством строк второй матрицы.");
            Console.WriteLine("\nГенерация первой матрицы...");
            double[,] firstMatrix = GenerationSwitch(operationType);
            int rows = firstMatrix.GetLength(0);
            int columns = firstMatrix.GetLength(1);
            Console.WriteLine("\nГенерация второй матрицы...");
            double[,] secondMatrix = GenerationSwitch(operationType);
            while (secondMatrix.GetLength(0) != columns)
            {
                Console.WriteLine($"\nКрасивая матрица. Но количество строк отличается от количества\n" +
                    $"столбцов первой матрицы({columns}).");
                secondMatrix = GenerationSwitch(operationType);
            }
            Console.WriteLine($"\nМатрица размера [{rows},{secondMatrix.GetLength(1)}]-произведение матриц:");
            double[,] resultMatrix = new double[rows, secondMatrix.GetLength(1)];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    for (int h = 0; h < columns; h++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, h] * secondMatrix[h, j];
                        // Сумма произведений элементов строки первой матрицы на элементы столбца
                        // второй матрицы.
                    }
                    Console.Write("{0,7}", resultMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод, реализующий операцию "Произведение матрицы на число".
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        static void SixthOperation(int operationType)
        {
            double[,] matrix = GenerationSwitch(operationType);
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            Console.Write("Введите число от -100 до 100, на которое хотите умножить: ");
            string number0 = Console.ReadLine();
            double number;
            while (!double.TryParse(number0, out number) || number < -100 || number > 100)
            {
                Console.WriteLine("\nВы ввели не число от -100 до 100.");
                Console.Write("Введите число снова: ");
                number0 = Console.ReadLine();
            }
            Console.WriteLine($"\nМатрица размера [{rows},{columns}], умноженная на число {number}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,7}", Math.Round(matrix[i, j] * number, 2));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Снижение ранга матрицы для нахождения определителя путем отбрасывания
        /// строки и столбца, номер которых совпадает с номером строки и столбца текущего
        /// элемента матрицы.
        /// </summary>
        /// <param name="matrix">Исходная матрица.</param>
        /// <param name="matrixRang">Ранг исходной матрицы.</param>
        /// <param name="row">Номер строки в момент вызова метода.</param>
        /// <param name="column">Номер столбца в момент вызова метода.</param>
        /// <param name="lowerRangMatrix">Матрица со сниженным рангом.</param>
        /// <returns></returns>
        static double[,] LowerRangMatrix(double[,] matrix, int matrixRang, int row, int column,
            out double[,] lowerRangMatrix)
        {
            lowerRangMatrix = new double[matrixRang, matrixRang];
            int iCheck = 0;
            // Проверка, совпал ли номер строки с номером строки текущего элемента.
            for (int i = 0; i < matrixRang; i++)
            {
                if (i == row)
                {
                    iCheck = 1;
                }
                int jCheck = 0;
                // Проверка, совпал ли номер столбца с номером столбца текущего элемента.
                for (int j = 0; j < matrixRang; j++)
                {
                    if (j == column)
                    {
                        jCheck = 1;
                    }
                    lowerRangMatrix[i, j] = matrix[i + iCheck, j + jCheck];
                    // Если совпала строка - элементу новой матрицы присваивается значение исходной,
                    // стоящей на строке ниже, если совпал стобец - присваивается значение исходной,
                    // стоящей в столбце правее.
                }
            }
            return lowerRangMatrix;
        }

        /// <summary>
        /// Нахождение определителя матрицы.
        /// </summary>
        /// <param name="matrix">Заданная матрица.</param>
        /// <param name="matrixRang">Ранг заданной матрицы.</param>
        /// <returns></returns>
        static double MatrixDeterminant(double[,] matrix, int matrixRang)
        {
            int matrixRangNew = matrixRang - 1;
            double determinant = 0;
            int sign = 1;
            // Знак +/-, понадобится в дальнейшей рекурсии.
            if (matrixRang > 2)
            {
                for (int i = 0; i < matrixRang; i++)
                {
                    LowerRangMatrix(matrix, matrixRangNew, i, 0, out double[,] lowerRangMatrix);
                    determinant += matrix[i, 0] * MatrixDeterminant(lowerRangMatrix, matrixRangNew) * sign;
                    sign *= -1;
                }
            }
            if (matrixRang == 2)
            {
                determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
                return determinant;
            }
            if (matrixRang == 1)
            {
                determinant = matrix[0, 0];
                return determinant;
            }
            return determinant;
        }

        /// <summary>
        /// Метод, реализующий операцию "Нахождение определителя матрицы".
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        static void SeventhOperation(int operationType)
        {
            double[,] matrix = GenerationSwitch(operationType);
            int matrixRang = matrix.GetLength(0);
            Console.Write("Определитель вашей матрицы: ");
            Console.WriteLine(Math.Round(MatrixDeterminant(matrix, matrixRang),2));
        }

        /// <summary>
        /// В зависимости от введенного номера операции вызывает методы для ее выполнения.
        /// </summary>
        /// <param name="operationType">Тип операции над матрицей.</param>
        static void OperationSwitch(int operationType)
        {
            switch (operationType)
            {
                case 1:
                    FirstOperation(operationType);
                    break;
                case 2:
                    SecondOperation(operationType);
                    break;
                case 3:
                    ThirdOperation(operationType);
                    break;
                case 4:
                    FourthOperation(operationType);
                    break;
                case 5:
                    FifthOperation(operationType);
                    break;
                case 6:
                    SixthOperation(operationType);
                    break;
                case 7:
                    SeventhOperation(operationType);
                    break;
            }
        }

        /// <summary>
        /// Основной метод.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в калькулятор матриц! С помощью этого приложения Вы\n" +
                "сможете производить различные действия над матрицами.\n");
            InterfaceText1();
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить, или Esc, чтобы выйти из приложения.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Console.WriteLine("До свидания!");
            }
            else
            {
                do
                {
                    Console.Clear();
                    InterfaceText1();
                    int operationType = ChooseAnOperation();
                    OperationSwitch(operationType);
                    Console.WriteLine("\nНажмите Esc, если хотите закончить работу с приложением,\n" +
                        "или любую другую клавишу, если хотите продолжить.");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                Console.Clear();
                Console.WriteLine("До свидания!");
            }
        }
    }
}
