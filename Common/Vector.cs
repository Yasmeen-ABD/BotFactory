using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;

namespace BotFactory.Common.Tools
{
    public class Vector: IVector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vector()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            return new Vector(x: Math.Abs(end.X - begin.X), y: Math.Abs(end.Y - begin.Y));
        }
        public static double Length(Vector vector)
        {
            //racine caréé ( (xb-xa)² + (yb - ya)²)
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }
    }
}
