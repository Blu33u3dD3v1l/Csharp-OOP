using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {           
          
                this.Length = length;
                this.Width = width;
                this.Height = height;

        }

        public double Length
        {
            get { return length; }
            set {
               if(value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    Environment.Exit(0);
                    
                }
                   this.length = value; 
                }
        }
        public double Width
        {
            get { return width; }
            set {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    Environment.Exit(0);

                }
                this.width = value; 
                }
        }
        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    Environment.Exit(0);

                }
                this.height = value;
            }
        }
        public double SurfaceArea()
        {
            var area = (2 *(width * height)) +(2*(width * length)) + (2*(length * height));

            return area;
        }
        public double LateralSurfaceArea()
        {
            var area = (2*(length * height)) + (2*(height * width));
            return area;
        }
        public double Volume()
        {
            var area = length * width * height;
            return area;
        }
    }
}
