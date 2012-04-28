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
    class Game
    {
        private Tank tank;
        private Map map;
        private System.Windows.Forms.PictureBox pictureBoxForMap; 
        public void Start(Form mainform)
        {
            // 1) формирует карту
            // 2) запускает таймер
            // 3) 
            /* 
             * по тику проверяет состояние всех 
             * компонентов на карте
             *  берем снаряд , опрашиваем всех кто рядом
             *  если никого нет то продвигаем по его траетктории
             *  если есть пересечение то спрашиваем у объекта
             *  что с ним происходит при попадании в него снаряда.
             *  реализуем взаимодействие.
             */
            pictureBoxForMap = new System.Windows.Forms.PictureBox();
            pictureBoxForMap.Location = new System.Drawing.Point(12, 12);
            pictureBoxForMap.Name = "pictureBoxMap";
            pictureBoxForMap.Size = new System.Drawing.Size(200, 200);
            pictureBoxForMap.TabStop = false;
            mainform.Controls.Add(pictureBoxForMap);

            map = new Map();
            //map.SetMapCoordinates(200, 200, 20);
            map.SetPictureBox(pictureBoxForMap);

            tank = new Tank();
            tank.SetSize(20,20);
            Point newpoint = new Point(40,40);
            tank.SetPoint(newpoint);
            tank.SetDirection(Direction.RIGHT);

            map.CreateObjectMapCollection();
            map.AddObjectMap(tank);



            System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
            time.Interval = 50;
            time.Tick += new System.EventHandler(time_Tick);

            time.Start();
         
        }
        // основная логика игры, следит за объектами 
        // производит вычисления и управляет объектами
        private void WorkGame()
        {
            // просто вытащим танк на форму
            map.Show();
            tank.Move();
        }
        private void time_Tick(object sender, EventArgs e)
        {
            WorkGame();
        }
        public void Stop()
        {

        }
    }
}
