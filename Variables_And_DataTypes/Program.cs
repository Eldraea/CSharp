using System;

namespace Variables_And_DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 21;
            char letter = 'A';
            bool motivation = true;
            double height = 1.61;
            string name = "Kim";

            Console.WriteLine("Hello I am " + name);
            Console.WriteLine("I am currently " + age);
            Console.WriteLine("I am " + height + " meters tall");
            Console.WriteLine("Saying that I love C# is absolutely " + motivation);
            Console.WriteLine("If you work really hard you are sure to get an " + letter);
        }
    }
}
