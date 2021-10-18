using System;

namespace Class
{

    /// <summary>
    /// Реализация класса матрица. 
    /// Состоит из элементов типа Fraction.
    /// </summary>
    public class Matrix
    {
        public long firstSize;
        public long secondSize;
        public Fraction[,] data;

        /// <summary>
        /// Cтандартный конструктор класса матрица.
        /// </summary>
        public Matrix()
        {
            this.firstSize = default;
            this.secondSize = default;
            this.data = default;
        }

        /// <summary>
        /// Конструктор класса матрица от 3 параметров.
        /// </summary>
        /// <param name="userFirstSize"> Количество сторок матрицы.</param>
        /// <param name="userSecondSize"> Количество столбцов матрицы.</param>
        /// <param name="userData"> Значения которыми заполнится матрица.</param>
        public Matrix(long userFirstSize, long userSecondSize, long[,] userData)
        {
            this.firstSize = userFirstSize;
            this.secondSize = userSecondSize;
            this.data = new Fraction[userFirstSize, userSecondSize];
            for (long i = 0; i < userFirstSize; ++i)
            {
                for (long j = 0; j < userSecondSize; ++j)
                {
                    Fraction buff = new Fraction(userData[i, j], 1);
                    this.data[i, j] = buff;
                }
            }
        }

        /// <summary>
        /// Конструктор класса матрица от 2 параметров.
        /// </summary>
        /// <param name="userFirstSize"> Количество сторок матрицы.</param>
        /// <param name="userSecondSize"> Количество столбцов матрицы.</param>
        public Matrix(long userFirstSize, long userSecondSize)
        {
            this.firstSize = userFirstSize;
            this.secondSize = userSecondSize;
            this.data = new Fraction[userFirstSize, userSecondSize];
        }

        /// <summary>
        /// Вывод матрицы в консоль.
        /// Построчный вывод матрицы. Элементы строки печатаются через пробел.
        /// </summary>
        public void Print()
        {
            for (long i = 0; i < this.firstSize; ++i)
            {
                for (long j = 0; j < this.secondSize; ++j)
                {
                    Console.Write(this.data[i, j].den == 1 ? this.data[i, j].num : Convert.ToString(this.data[i, j].num) + " / " + Convert.ToString(this.data[i, j].den));
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
