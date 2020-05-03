using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures_measure
{
    interface IFigures
    {
         double Measure();      
    }

    public class Circle:IFigures
    {
        private double m_radius;
        public double Radius
        {
            get
            {
                return m_radius;
            }
            set
            {
                if (value>0)
                { m_radius = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public Circle(double r)
        {
            Radius = r;
        }

        public double Measure()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Triangle:IFigures
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        public bool IsRect { get; set; }
        public Triangle(double s1,double s2,double s3)
        {
            if (!(s1<s2+s3 && s2<s1+s3 && s3<s1+s2) || (s1<0 || s2<0 || s3<0))
            {
                throw new ArgumentOutOfRangeException();
            }

            Side1 = s1;
            Side2 = s2;
            Side3 = s3;
            if (s1*s1==s2*s2+s3*s3 || s2*s2==s1*s1+s3*s3 || s3*s3==s1*s1+s2*s2)
            {
                IsRect = true;
            }
            else
            {
                IsRect = false;
            }
        }
        public double Measure()
        {
            double p = (Side1 + Side2 + Side3) / 2;
            double s = 0;
            if (IsRect)
            {
                if(Math.Min(Side1,Side2).Equals(Math.Min(Side2,Side3)))
                {
                    s = Math.Min(Side1, Side2) * Math.Min(Side1, Side3) / 2;
                }
                else
                {
                    s= Math.Min(Side1, Side2) * Math.Min(Side2, Side3) / 2;
                }
            }
            else
            { s = Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3)); }
            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFigures treug = new Triangle(3, 4, 5);
            IFigures krug = new Circle(Math.Sqrt(10 / Math.PI));
            Console.WriteLine("Площадь пифагорского треугольника {0}",treug.Measure());
            Console.WriteLine("Площадь круга равна {0}", krug.Measure());

            Console.ReadKey();
        }
    }
}
