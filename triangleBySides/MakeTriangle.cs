using System;

namespace triangleBySides
{
    class Triangle
    {
        private uint sideA;
        private uint sideB;
        private uint sideC;
        
        public void SetSides((uint, uint, uint) lengths)
        {
            sideA = lengths.Item1;
            sideB = lengths.Item2;
            sideC = lengths.Item3;
            
        }

        public bool IsTriangle()
        {
            return sideA < sideB + sideC && sideB < sideA + sideC && sideC < sideA + sideB;
        }

        public uint Perimeter()
        {
            return sideA + sideB + sideC;
        }

        public double Area()
        {
            double p = (double)Perimeter() / 2;
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }

        public void Print()
        {
            Console.Write("Lengths of triangle sides are: {0}, {1}, {2}", sideA, sideB, sideC);
            Console.WriteLine();
        }
    }
    class MakeTriangle
    {
        static void Main(string[] args)
        {
            try {

                Console.WriteLine("Enter triangle sides: ");
                uint[] sides = new uint[3];
                string[] tmp = Console.ReadLine().Split();

                for (int i = 0; i < tmp.Length; i++)
                {
                    sides[i] = uint.Parse(tmp[i]);
                }

                Triangle abc = new Triangle();
                abc.SetSides((sides[0], sides[1], sides[2]));
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
    }
}
