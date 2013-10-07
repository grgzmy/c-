using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    struct Point
    {
        private int _x;
        private int _y;
        
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
       
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Point (int xStart, int yStart) {
            _x = xStart;
            _y = yStart;
        }

        public void MoveUp(int x) {
            _x += x;
        }

        public void MoveDown(int x) {
            _x -= x;
        }

        public void MoveLeft(int y) {
            _y -= y;
        }

        public void MoveRight(int y) {
            _y += y;
        }

        public void Translate(int x, int y) {
            _x += x;
            _y += y;
        }

        public void MoveTo(int x, int y) {
            _x = x;
            _y = y;
        }

        public void MoveTo(Point p) {
            _x = p.X;
            _y = p.Y;
        }

        public override string ToString()
        {
            return ("(X: " + _x + ",  Y: " + _y+")");
        }

        public override bool Equals(object obj)
        {
            Point p = (Point)obj;
            return (p.X == _x && p.Y == _y);
        }

        public override int GetHashCode()
        {
            return _x + _y;
        }

        public static Point operator + (Point lhs, Point rhs) {
            return new Point((lhs.X + rhs.X), (lhs.Y + rhs.Y));   
        }

        public static Point operator -(Point lhs, Point rhs) {
            return new Point((lhs.X - rhs.X), (lhs.Y - rhs.Y));
        }

    }

    struct PointDistance {
        
        private  double distance;
        private  double xDistance, yDistance;

        public double XDistance
        {
            get { return xDistance; } 
        }

        public double YDistance
        {
            get { return YDistance; }
        }

        public double Distance
        {
            get { return distance; }
           
        }

        public PointDistance (Point p1, Point p2) {
            

            distance = Math.Sqrt((p1.X * p2.X) + (p1.Y * p2.Y));
            xDistance = p1.X - p2.X;
            yDistance = p1.Y - p2.Y;
        }

        public PointDistance(double distance) {
            this.distance = distance;
            yDistance = Math.Sqrt(distance);
            xDistance = yDistance;
        }

        public static PointDistance operator +(PointDistance lhs, PointDistance rhs) {
            return new PointDistance(lhs.Distance + rhs.Distance);
        }


        public static PointDistance operator -(PointDistance lhs, PointDistance rhs) { 
            return new PointDistance(lhs.Distance - rhs.Distance);
        }

        public static bool operator ==(PointDistance lhs, PointDistance rhs) {
            return lhs.Distance == rhs.Distance;
        }

        public static bool operator !=(PointDistance lhs, PointDistance rhs) { 
            return !(rhs==lhs);
        }

        public override bool Equals(object obj)
        {
            return this == ((PointDistance)obj);
        }

        public override int GetHashCode()
        {
            return (int)(distance*distance);
        }

        
    }

    static class UtilityMethods
    {
        public static bool IsPrime(this int num)
        {
            if (num <= 1)
            {
                return false;
            }
            else
            {
                int i = 2;
                while (i < num)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                    else
                    {
                        i++;
                    }
                }
                
                return true;
            }
        }

        public static string Reverse(this string s) { 
            string outString = "";
            for (int i = s.Length-1; i>= 0; i-- ){
                outString+=s[i];
            }
            return outString;
        }

        public static string Describe(this Object o) { 
            
        }

        public static void Main(String[] args) {
            Console.WriteLine(6.IsPrime());
            while (true) ;
        }
    }

    interface IHasPosition {
         Point GetPosition();

    }
}
