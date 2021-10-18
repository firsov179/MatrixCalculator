using System;


namespace Class
{

    /// <summary>
    /// Класс дробь. Представление рационального числа в качестве дроби.
    /// </summary>
    public class Fraction
    {
        public long num;
        // num - числитель.
        public long den;
        // den - знаменатель.


        /// <summary>
        /// Стандартный конструктор Причваетвает значение 0.
        /// </summary>
        public Fraction()
        {
            num = 0;
            den = 0;
        }

        /// <summary>
        /// Конструктор класса дробь от 2 параметров.
        /// </summary>
        /// <param name="n"> Числитель.</param>
        /// <param name="d"> Знаменатель.</param>
        public Fraction(long n, long d)
        {
            this.num = n;
            this.den = d;
            this.Simple();
        }

        /// <summary>
        /// Нахождение НОД(a, b).
        /// </summary>
        /// <param name="a"> Первое число.</param>
        /// <param name="b"> Второе число.</param>
        /// <returns> Возвращает НОД(a, b).</returns> 
        static long gcd(long a, long b)
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
        /// Упрощение дроби.
        /// </summary>
        public void Simple()
        {
            if (this.num == 0)
            {
                this.den = 0;
                return;
            }
            long gcd_this = gcd(Math.Abs(this.den), Math.Abs(this.num));
            this.den /= gcd_this;
            this.num /= gcd_this;
            if (this.den < 0)
            {
                this.den *= -1;
                this.num *= -1;
            }
        }

        /// <summary>
        /// Сложение дробей.
        /// </summary>
        /// <param name="fir"> Первая дробь.</param>
        /// <param name="sec"> Вторая дробь.</param>
        /// <returns> fir + sec.</returns> 
        public static Fraction operator +(Fraction fir, Fraction sec)
        {
            fir.Simple();
            sec.Simple();
            if (fir.den == 0 || sec.den == 0)
            {
                Fraction buffer = new Fraction(fir.num + sec.num, fir.den + sec.den);
                buffer.Simple();
                return buffer;
            }
            long buf = gcd(fir.den, sec.den);
            Fraction ans = new Fraction(fir.num * (sec.den / buf) + sec.num * (fir.den / buf), (fir.den / buf) * sec.den);
            ans.Simple();
            return ans;
        }

        /// <summary>
        /// Унарный минус.
        /// </summary>
        /// <param name="a"> Дробь.</param>
        /// <returns> -fir.</returns> 
        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

        /// <summary>
        /// Вычетание дробей.
        /// </summary>
        /// <param name="fir"> Первая дробь.</param>
        /// <param name="sec"> Вторая дробь.</param>
        /// <returns> fir - sec.</returns> 
        public static Fraction operator -(Fraction fir, Fraction sec)
        {
            return fir + (-sec);
        }

        /// <summary>
        /// Сравнение дробей.
        /// </summary>
        /// <param name="fir"> Первая дробь.</param>
        /// <param name="sec"> Вторая дробь.</param>
        /// <returns> fir > sec.</returns> 
        public static bool operator >(Fraction fir, Fraction sec)
        {
            fir.Simple();
            sec.Simple();
            if (fir.num == 0)
            {
                return sec.num < 0;
            }
            if (sec.num == 0)
            {
                return fir.num > 0;
            }
            return fir.num * sec.den > sec.num * fir.den;
        }
        /// <summary>
        /// Сравнение дробей.
        /// </summary>
        /// <param name="fir"> Первая дробь.</param>
        /// <param name="sec"> Вторая дробь.</param>
        /// <returns> fir < sec.</returns> 
        public static bool operator <(Fraction fir, Fraction sec)
        {
            fir.Simple();
            sec.Simple();
            sec.Simple();
            if (fir.num == 0)
            {
                return sec.num > 0;
            }
            if (sec.num == 0)
            {
                return fir.num < 0;
            }
            return fir.num * sec.den < sec.num * fir.den;
        }

        /// <summary>
        /// Перемножение дробей.
        /// </summary>
        /// <param name="fir"> Первая дробь.</param>
        /// <param name="sec"> Вторая дробь.</param>
        /// <returns> fir * sec.</returns> 
        public static Fraction operator *(Fraction fir, Fraction sec)
        {
            fir.Simple();
            sec.Simple();
            Fraction ans = new Fraction(fir.num * sec.num, fir.den * sec.den);
            ans.Simple();
            return ans;
        }

        /// <summary>
        /// Деление дробей.
        /// </summary>
        /// <param name="fir"> Первая дробь.</param>
        /// <param name="sec"> Вторая дробь.</param>
        /// <returns> fir / sec.</returns> 
        public static Fraction operator /(Fraction fir, Fraction sec)
        {
            fir.Simple();
            sec.Simple();
            Fraction ans = new Fraction(fir.num * sec.den, fir.den * sec.num);
            ans.Simple();
            return ans;
        }
    }
}
