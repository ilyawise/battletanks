using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace MapObject
{
    // направления движения 
    enum Direction
        {
            UP, DOWN, LEFT, RIGHT
        };
    class Tank : IObjectMap
    {
        private Direction CarrentDirection;
        public Direction GetDirection()
        {
            return CarrentDirection;
        }
        public void SetDirection(Direction newDirection)
        {
            CarrentDirection = newDirection;
        }
        private int Heigth = 0;
        private int Legth = 0;
        private Size sizeTank;

        private Point TankPosition;
        // устанавливает размеры танка
        public void SetSize(int newheigth, int newlegth)
        {
            this.Heigth = newheigth;
            this.Legth = newlegth;
            sizeTank = new Size(Heigth, Legth);
        }
        public void SetPoint(Point NewPosition)
        {
            TankPosition = NewPosition;
        }
        // отдает текущие координаты танка
        public Point GetPoint()
        {
            return TankPosition;
        }
        // получает рисунок танка
        public Bitmap GetImage()
        {
            //Bitmap bm = new Bitmap(Heigth,Legth);
            Bitmap TankImage = new Bitmap(@"C:\Users\g4p\Pictures\Tank2.png");

            return TankImage;
        }

        public void Move()
        {
            // прибавляет к своему значению на карте
            // Point по несколько пикселей согласно
            // текущему направлению
            switch (CarrentDirection)
            {
                case Direction.UP:
                    TankPosition.Y += 4;
                    //SetSize(Heigth, Legth + 5);
                    break;
                case Direction.RIGHT:
                    TankPosition.X += 2;
                    //SetSize(Heigth-5, Legth);
                    break;
                case Direction.LEFT:
                    TankPosition.X -= 1;    
                    //SetSize(Heigth-5, Legth);
                    break;
                case Direction.DOWN:
                    TankPosition.Y -= 1;
                    //SetSize(Heigth, Legth - 5);
                    break;
                   
            }
        }
    }
}
