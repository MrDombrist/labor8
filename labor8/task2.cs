//using System.Text.RegularExpressions;
//class task2
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Введите количетсво строк: ");
//        int n = int.Parse(Console.ReadLine());
//        string[] str = new string[n];
//        for(int i=0; i<str.Length; i++)
//        {
//            Console.Write("Введите " +(i+1)+ " строку: ");
//            str[i] = Console.ReadLine();
//        }
//        int Upper = str.Count(a => Regex.IsMatch(a,@"[a-z]"));
//        int ten = str.Count(a => Regex.IsMatch(a, @"^.{10}$"));
//        int five = str.Count(a => Regex.IsMatch(a, @"\b\w{5}\b"));
//        Console.WriteLine("Количество строк, вкоторыхнет заглавных букв: {0}\nколичество десятисимвольных строк в этом наборе: {1}\nколичество пятибуквенных слов в набореиз 5 строк:{2}"
//            ,Upper,ten,five);
//    }
//}