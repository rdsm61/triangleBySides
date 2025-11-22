using System;

namespace triangleBySides
{
    class Triangle
    {
        private uint[] sides = new uint[3];
        
        public void SetSides(uint[] lengths)
        {
            for (int i = 0; i < 3; i++)
                sides[i] = lengths[i];
        }

        public bool IsTriangle()
        {
            return sides[0] < sides[1] + sides[2] && sides[1] < sides[0] + sides[2] && sides[2] < sides[0] + sides[1];
        }

        public uint Perimeter()
        {
            return sides[0] + sides[1] + sides[2];
        }

        public double Area()
        {
            double p = (double)Perimeter() / 2;
            return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
        }

        public void Print()
        {
            Console.Write("Lengths of triangle sides are: ");
            for (int i = 0; i < 3; i++)
                Console.Write("{0} ", sides[i]);
            Console.WriteLine();
        }
    }
    class MakeTriangle
    {
        static void Main(string[] args)
        {
            try
            {
                Triangle abc = CreateTriangle();

                if (abc.IsTriangle())
                {
                    abc.Print();
                    Console.WriteLine("Perimeter of the triangle is {0}", abc.Perimeter());
                    Console.WriteLine("Area of the triangle is {0}", abc.Area());
                }
                else
                {
                    Console.WriteLine("There is no triangle with these sides");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter three positive numbers");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Enter only positive numbers");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Enter only three numbers");
            }
            
        }

        private static Triangle CreateTriangle()
        {
            Console.WriteLine("Enter triangle sides: ");
            uint[] sides = new uint[3];
            string[] tmp = Console.ReadLine().Split();

            for (int i = 0; i < tmp.Length; i++)
            {
                sides[i] = uint.Parse(tmp[i]);
            }

            Triangle abc = new Triangle();
            abc.SetSides(sides);
            return abc;
        }

    }
}
