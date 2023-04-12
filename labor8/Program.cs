class lab8
{
    delegate double ArifmFunc(double x);
    delegate bool IsOK(double x);
    static Func<double, double> operation = delegate (double x) { return 2 * Math.Sqrt(Math.Abs(x - 1)) + 1; };
    static Action<double, double, double> Printfu = delegate (double a, double b, double step)
    {
        Console.WriteLine("\nзначения функции {3} на отрезке [{0},  {1}] c шагом {2}", a, b, step, operation.Method.Name);
        for (double x = a; x <= b; x += step)
            Console.WriteLine("x={0}\t f(x) = {1}", x, operation(x));
    };

    static double Choice(double x)
    {
        if (x < 0)
        {
            return Math.Pow(Math.Sin(x), 2) / 4 + 1;
        }
        else
        {
            return Math.Cos(x) / 2 - 1;
        }
    }


    static void PrintFunc(double a, double b, double step, ArifmFunc del)
    {
        Console.WriteLine("\nзначения функции {3} на отрезке [{0},  {1}] c шагом {2}", a, b, step, del.Method.Name);
        for (double x = a; x <= b; x += step)
            Console.WriteLine("x={0}\t f(x) = {1}", x, del(x));
    }

    static int Summ(double a, double b, double step, Predicate<double> check, ArifmFunc del)
    {
        int sum = 0;
        for (double x = a; x <= b; x += step)
        {
            if (check(del(x)))
            {
                sum++;
            }
        }
        return sum;
    }
    static int Summ1(double a, double b, double step, Predicate<double> check, Func<double, double> op)
    {
        int sum = 0;
        for (double x = a; x <= b; x += step)
        {
            if (check(op(x)))
            {
                sum++;
            }
        }
        return sum;
    }
    static void Output(ArifmFunc Fdel)
    {
        for (int i = 0; i <= 1; i++)
        {
            if (i == 0)
            {
                foreach (ArifmFunc del in Fdel.GetInvocationList())
                {
                    PrintFunc(Math.PI * (-2), Math.PI * 2, Math.PI / 6, Fdel);
                }
            }
            else { Printfu(Math.PI * (-2), Math.PI * 2, Math.PI / 6); }
        }
    }
    static int[] Checking(ArifmFunc Fdel)
    {
        int[] a = new int[2];
        int minusargs = 0;
        int diaposone = 0;
        for (int i = 0; i <= 1; i++)
        {
            if (i == 0)
            {
                foreach (ArifmFunc del in Fdel.GetInvocationList())
                {
                    minusargs += Summ(Math.PI * (-2), Math.PI * 2, Math.PI / 6, x => del(x) < 0, del);
                    diaposone += Summ(Math.PI * (-2), Math.PI * 2, Math.PI / 6, x => del(x) >= -1 && del(x) <= 1, del);
                    PrintFunc(Math.PI * (-2), Math.PI * 2, Math.PI / 6, Fdel);
                }
            }

            else
            {
                minusargs += Summ1(Math.PI * (-2), Math.PI * 2, Math.PI / 6, x => operation(x) < 0, operation);
                diaposone += Summ1(Math.PI * (-2), Math.PI * 2, Math.PI / 6, x => operation(x) >= -1 && operation(x) <= 1, operation);
                Printfu(Math.PI * (-2), Math.PI * 2, Math.PI / 6);
            }

        }
        a[0] = minusargs;
        a[1] = diaposone;
        return a;
    }

    static void Main(string[] args)
    {
        ArifmFunc Fdel;
        Fdel = x => Math.Cos(x);
        Fdel += delegate (double x) { return -1 * Math.Pow(x / Math.PI, 2) - 2 * x + 5 * Math.PI; };
        Fdel += Choice;
        Fdel += x => { double sum = 0; for (int k = 1; k <= 100; k++) { sum += Math.Pow(-1 + x / k * Math.PI, 2); } return sum; };
        //Output(Fdel);
        int[] a = new int[2];
        a = Checking(Fdel);
        Console.WriteLine("Количество отрицательных элементов: {0},  количество элементов в диапозоне от -1 до 1: {1}", a[0], a[1]);
    }
}
