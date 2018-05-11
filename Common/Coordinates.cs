using BotFactory.Common.Interface;

namespace BotFactory.Common.Tools
{
    public  class Coordinates:ICoordinates
    {
            public double X { get; set; }
            public double Y { get; set; }

            public Coordinates(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Coordinates p = (Coordinates)obj;
                return (X == p.X) && (Y == p.Y);
            }
    }
}