using System;

namespace triangleBySides
{
    class Triangle : IComparable<Triangle>
    {
        private uint[] sides = new uint[3];

        public Triangle(uint[] lengths)
        {
            for(int i = 0; i < 3; i++)
            {
                sides[i] = lengths[i];
            }
        }

        public Triangle(uint length)
        {
            for(int i = 0; i < 3; i++)
            {
                sides[i] = length;
            }
        }

        public Triangle()
        {
            sides[0] = 3;
            sides[1] = 4;
            sides[2] = 5;
        }
        
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
    
            Console.WriteLine("Area is {0:N3}", this.Area());
        }

        public int CompareTo(Triangle t2)
        {
            if (this.IsTriangle())
            {
                if (t2.IsTriangle())
                {
                    return this.Area().CompareTo(t2.Area());
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (t2.IsTriangle())
                {
                    return -1;
                }
                else
                {
                    Console.WriteLine("These are not triangles");
                    return 0;
                }
            }
            
        }
    }
    class MakeTriangle
    {
        static void Main(string[] args)
        {
            try
            {
            //    Triangle abc = CreateTriangle();

            //    if (abc.IsTriangle())
            //    {
            //        abc.Print();
            //        Console.WriteLine("Perimeter of the triangle is {0}", abc.Perimeter());
            //        Console.WriteLine("Area of the triangle is {0}", abc.Area());
            //    }
            //    else
            //    {
            //        Console.WriteLine("There is no triangle with these sides");
            //    }

                Triangle[] figures = new Triangle[4];
                uint[] lengths = new uint[3];
                Random rnd = new Random();
                int count = 0;

                while (count < figures.Length)
                {
                //    figures[count] = new Triangle();
                    for (int k = 0; k < lengths.Length; k++)
                    {
                        lengths[k] = (uint)rnd.Next(1, 10);
                    }
                    figures[count] = new Triangle(lengths);
                    //   figures[count].SetSides(lengths);

                    if (figures[count].IsTriangle())
                        count++;
                }


                Console.WriteLine("Before sorting");
                foreach (var item in figures)
                {
                    item.Print();
                }
                Console.WriteLine();

                Array.Sort(figures);

                Console.WriteLine("After sorting");
                foreach (var item in figures)
                {
                    item.Print();
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
