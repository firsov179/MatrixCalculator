using System;

namespace MatrixCalculator
{
    /// <summary>
    /// Класс для произведения матричных операций.
    /// </summary>
    public class Matrix
    {
        private static readonly Random s_rand = new Random();
        private const int MaxDimensionSize = 10;
        private const int MinDimensionSize = 2;
        private const int MaxValue = 15;
        private const int MinValue = -15;
        private const double Epsilon = 1e-9;

        private readonly double[,] _matrix;

        /// <summary>
        /// Конструктор от двумерного массива
        /// </summary>
        /// <param name="matrix">Массив на котором будет построена матрица.</param>

        public Matrix(double[,] matrix)
        {
            int n = matrix.GetLength(0),
                m = matrix.GetLength(1);
            var memb = new double[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    memb[i, j] = matrix[i, j];
                }
            }
            _matrix = memb;
        }

        /// <summary>
        /// Конструктор матрицы n на m с радномыми значениями.
        /// </summary>
        /// <param name="n">Количество строк.</param>
        /// <param name="m">Количество столбцов.</param>

        public Matrix(int n, int m)
        {
            var matrix = new double[n, m];
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < m; ++j)
                {
                    matrix[i, j] = s_rand.Next(MinValue, MaxValue + 1);
                }
            }
            _matrix = matrix;
        }

        /// <summary>
        /// Получение количества строк в матрице объекта.
        /// </summary>
        /// <returns>Количество строк в матрице объекта.</returns>

        private int GetRowCount()
        {
            return _matrix.GetLength(0);
        }

        /// <summary>
        /// Получение количества столбцов в матрице объекта.
        /// </summary>
        /// <returns>Количество столбцов в матрице объекта.</returns>

        private int GetColumnCount()
        {
            return _matrix.GetLength(1);
        }

        /// <summary>
        /// Ввод количества элементов в измерении матрицы.
        /// </summary>
        /// <returns>Количество элементов в измерении матрицы.</returns>

        public static int ReadDimensionSize()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var n) &&
                    n is <= MaxDimensionSize and >= MinDimensionSize) return n;
                Calculator.PrintBadInputMessage();
            }
        }

        /// <summary>
        /// Функция для обхода случая вывода -0.
        /// </summary>
        /// <param name="res">Число для обработки.</param>
        /// <returns>Обработанное число.</returns>

        public static double GetResult(double res)
        {
            if (Math.Abs(res) < Epsilon)
            {
                return 0.000;
            }
            else
            {
                return res;
            }
        }

        /// <summary>
        /// Вывод матрицы.
        /// </summary>

        public void PrintMatrix()
        {
            int n = GetRowCount(), m = GetColumnCount();
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < m; ++j)
                {
                    Console.Write($"{GetResult(_matrix[i, j]),7:f3}  ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Обмен позициями строк в матрице.
        /// </summary>
        /// <param name="matrix">Матрица в которой происходит обмен.</param>
        /// <param name="l">Первая строка.</param>
        /// <param name="r">Вторая строка.</param>

        private static void SwapString(ref double[,] matrix, int l, int r)
        {
            var m = matrix.GetLength(1);
            for (var i = 0; i < m; ++i)
            {
                (matrix[l, i], matrix[r, i]) = (matrix[r, i], matrix[l, i]);
            }
        }

        /// <summary>
        /// Нахождение определителя матрицы.
        /// </summary>
        /// <returns>Определитель матрицы.</returns>

        public double GetDeterminant()
        {
            var det = 1.0;
            int n = GetRowCount(), m = GetColumnCount();
            var matrix = new double[n, m];
            for (var i = 0; i < n; ++i)
                for (var j = 0; j < m; ++j)
                    matrix[i, j] = _matrix[i, j];
            for (var i = 0; i < n; ++i)
            {
                var currentString = i;
                for (var j = i + 1; j < n; ++j)
                {
                    if (Math.Abs(_matrix[j, i]) > Math.Abs(_matrix[currentString, i]))
                    {
                        currentString = j;
                    }
                }
                if (i != currentString) det = -det;
                if (Math.Abs(_matrix[currentString, i]) < Epsilon)
                {
                    return 0.0;
                }
                SwapString(ref matrix, i, currentString);
                det *= matrix[i, i];
                for (var j = i + 1; j < n; ++j)
                    matrix[i, j] /= matrix[i, i];
                for (var j = 0; j < n; ++j)
                {
                    if (j == i || !(Math.Abs(matrix[j, i]) > Epsilon)) continue;
                    for (var k = i + 1; k < n; ++k)
                    {
                        matrix[j, k] -= matrix[i, k] * matrix[j, i];
                    }
                }
            }

            return det;
        }

        /// <summary>
        /// Нахождение решений линейного уравнения.
        /// </summary>
        /// <param name="answer">Массив решений.</param>
        /// <returns>Возвращает 1 если решения найдены, 0 если решений нет, -1 если решений inf.</returns>

        public int LetGaussMethod(out double[] answer)
        {
            int n = GetRowCount();
            int m = GetColumnCount() - 1;
            var where = new int[m];
            var matrix = new double[n, m + 1];
            for (var i = 0; i < n; ++i)
                for (var j = 0; j < m + 1; ++j)
                    matrix[i, j] = _matrix[i, j];

            for (var i = 0; i < m; ++i)
            {
                where[i] = -1;
            }
            for (int col = 0, row = 0; col < m && row < n; ++col)
            {
                var currentString = row;

                for (var i = row; i < n; ++i)
                {
                    if (Math.Abs(matrix[i, col]) > Math.Abs(matrix[currentString, col]))
                    {
                        currentString = i;
                    }
                }

                if (Math.Abs(matrix[currentString, col]) < Epsilon) continue;

                for (var i = col; i <= m; ++i)
                {
                    (matrix[currentString, i], matrix[row, i]) = (matrix[row, i], matrix[currentString, i]);
                }

                where[col] = row;

                for (var i = 0; i < n; ++i)
                {
                    if (i == row) continue;

                    var c = matrix[i, col] / matrix[row, col];
                    for (var j = col; j <= m; ++j)
                    {
                        matrix[i, j] -= matrix[row, j] * c;
                    }
                }

                ++row;
            }

            answer = new double[m];
            for (var i = 0; i < m; ++i)
            {
                if (where[i] != -1)
                {
                    answer[i] = matrix[where[i], m] / matrix[where[i], i];
                }
            }
            for (var i = 0; i < n; ++i)
            {
                double sum = 0;
                for (var j = 0; j < m; ++j)
                {
                    sum += answer[j] * matrix[i, j];
                }
                if (Math.Abs(sum - matrix[i, m]) > Epsilon)
                {
                    return 0;
                }
            }

            for (var i = 0; i < m; ++i)
            {
                if (where[i] == -1)
                {
                    return int.MaxValue;
                }
            }
            return 1;
        }

        /// <summary>
        /// Транспонирование матрицы.
        /// </summary>
        /// <returns>Преобразованую матрицу.</returns>

        public Matrix Transpose()
        {
            int n = GetRowCount(), m = GetColumnCount();
            var newMatrix = new double[m, n];
            for (var i = 0; i < n; ++i)
                for (var j = 0; j < m; ++j)
                    newMatrix[j, i] = _matrix[i, j];
            return new Matrix(newMatrix);
        }

        /// <summary>
        /// Нахождение следа матрицы.
        /// </summary>
        /// <returns>След матрицы.</returns>

        public double GetTrace()
        {
            int n = GetRowCount();
            var answer = 0.0;
            for (var i = 0; i < n; ++i)
            {
                answer += _matrix[i, i];
            }
            return answer;
        }

        /// <summary>
        /// Обработка ввода матрицы.
        /// </summary>
        /// <param name="n">Количество строк ожидаемой матрицы.</param>
        /// <param name="m">Количество столбцов ожидаемой матрицы.</param>
        /// <returns>Полученную матрицу.</returns>

        public static double[,] ReadMatrix(int n, int m)
        {
            var matrix = new double[n, m];
            for (var i = 0; i < n; ++i)
            {
                bool isGoodInput;
                do
                {
                    var input = Console.ReadLine();
                    if (input == null)
                    {
                        Calculator.PrintBadInputMessage();
                        isGoodInput = false;
                        continue;
                    }

                    var splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (splitInput.Length != m)
                    {
                        Console.WriteLine($"\nВведите нужное количество элементов!\n");
                        isGoodInput = false;
                        continue;
                    }

                    isGoodInput = true;
                    for (var j = 0; j < m; ++j)
                    {
                        if (!double.TryParse(splitInput[j], out var number) ||
                            number is < MinValue or > MaxValue)
                        {
                            isGoodInput = false;
                            Calculator.PrintBadInputMessage();
                            break;
                        }
                        else
                        {
                            matrix[i, j] = number;
                        }
                    }
                } while (!isGoodInput);
            }

            return matrix;
        }

        /// <summary>
        /// Оператор для сложения матриц.
        /// </summary>
        /// <param name="lhs">Первая матрица.</param>
        /// <param name="rhs">Вторая матрица.</param>
        /// <returns>Результат сложения матриц.</returns>

        public static Matrix operator +(Matrix lhs, Matrix rhs)
        {
            int ln = lhs.GetRowCount(),
                lm = lhs.GetColumnCount();
            var result = new double[ln, lm];
            for (var i = 0; i < ln; ++i)
                for (var j = 0; j < lm; ++j)
                    result[i, j] = lhs._matrix[i, j] + rhs._matrix[i, j];
            return new Matrix(result);
        }

        /// <summary>
        /// Оператор вычитания матриц.
        /// </summary>
        /// <param name="lhs">Первая матрица.</param>
        /// <param name="rhs">Вторая матрица.</param>
        /// <returns>Результат вычетания матриц.</returns>

        public static Matrix operator -(Matrix lhs, Matrix rhs)
        {
            int ln = lhs.GetRowCount(),
                lm = lhs.GetColumnCount();
            var result = new double[ln, lm];
            for (var i = 0; i < ln; ++i)
                for (var j = 0; j < lm; ++j)
                    result[i, j] = lhs._matrix[i, j] - rhs._matrix[i, j];
            return new Matrix(result);
        }

        /// <summary>
        /// Оператор умножения матриц.
        /// </summary>
        /// <param name="lhs">Левый множитель.</param>
        /// <param name="rhs">Правый множитель.</param>
        /// <returns>Результат умножения.</returns>

        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            int ln = lhs.GetRowCount(),
                lm = lhs.GetColumnCount(),
                rm = rhs.GetColumnCount();
            var result = new double[ln, rm];

            for (var i = 0; i < ln; ++i)
                for (var j = 0; j < rm; ++j)
                    for (var k = 0; k < lm; ++k)
                        result[i, j] += lhs._matrix[i, k] * rhs._matrix[k, j];

            return new Matrix(result);
        }

        /// <summary>
        /// Перегрузка оператора умножения матриц, для умножения матрицы на число.
        /// </summary>
        /// <param name="lhs">Матрица которую нужно умножить.</param>
        /// <param name="factor">Множитель.</param>
        /// <returns>Результат умножения.</returns>

        public static Matrix operator *(Matrix lhs, double factor)
        {
            int n = lhs.GetRowCount(),
                m = lhs.GetColumnCount();
            var result = new double[n, m];
            for (var i = 0; i < n; ++i)
                for (var j = 0; j < m; ++j)
                    result[i, j] = lhs._matrix[i, j] * factor;
            return new Matrix(result);
        }
    }
}