using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MapObject
{
    class Maps
    {
        private int X = 0;
        private int Y = 0;
        private int SIZEGRIG = 1;
        public void SetMapCoordinates(int x, int y, int sizegrid)
        {
            this.X = x;
            this.Y = y;
            this.SIZEGRIG = sizegrid;
        }

        public void Refresh(Form mainform)
        {
            Form fm = mainform;
           

            //int CountObjectMap = (X / SIZEGRIG) * (Y / SIZEGRIG);

            //PictureBox[] pictureMaps = new PictureBox[CountObjectMap];

            //Bitmap[] bitMaps = new Bitmap[CountObjectMap];

            //int i = 0;
            //for (int x = 0; x < X; x = x + SIZEGRIG)
            //{
            //    for (int y = 0; y < Y; y = y + SIZEGRIG)
            //    {
            //        bitMaps[i] = new Bitmap(@"C:\Users\g4p\Pictures\Tank3.png", true);
            //    }
            //}


            //int c = 0;
            //int a = 0;
            //int g = 0;
            //for (int x = 0; x < X; x = x + SIZEGRIG)
            //{
            //    for (int y = 0; y < Y; y = y + SIZEGRIG)
            //    {
            //        pictureMaps[a] = new PictureBox();
            //        pictureMaps[a].Location = new System.Drawing.Point(SIZEGRIG * g, SIZEGRIG * c);
            //        pictureMaps[a].Size = new System.Drawing.Size(SIZEGRIG, SIZEGRIG);
            //        //pictureMaps[a].Refresh();
            //        //if (pictureMaps[a].Image == null)
            //        //{
            //        //    //pictureMaps[a].Dispose();
            //        //    pictureMaps[a].Image = null;
            //        //}
            //        pictureMaps[a].Image = null;
            //        //pictureMaps[a].Image = null;
            //        pictureMaps[a].Invalidate();

            //        pictureMaps[a].Name = "pic" + Convert.ToString(a);
            //        a++;
            //        g++;
            //    }
            //    g = 0;
            //    c++;
            //}

            //int h = 0;
            //for (int x = 0; x < X; x = x + SIZEGRIG)
            //{
            //    for (int y = 0; y < Y; y = y + SIZEGRIG)
            //    {

            //        mainform.Controls.Add(pictureMaps[h]);
            //        h++;
            //    }
            //}

            ////int b = 0;
            //for (int x = 0; x < X; x = x + SIZEGRIG)
            //{
            //    for (int y = 0; y < Y; y = y + SIZEGRIG)
            //    {

            //        mainform.Controls.Remove(pictureMaps[b]);
            //        b++;
            //    }
            //}
        }   

        public void Show(Form mainform)
        {
            // get coordinate main form 
            // for bilding map on mainform
            Form MainForm = mainform;
            int formWidth = mainform.Width;
            int formHeight = mainform.Height;
            int locationX = mainform.Location.X;
            int locationY = mainform.Location.Y;

            //MessageBox.Show(formHeight.ToString()+ " "+
            //                formWidth.ToString()+ " "+
            //                locationX.ToString() + " "+
            //                locationY.ToString());

            int CountObjectMap = (X / SIZEGRIG)*(Y/SIZEGRIG);
            PictureBox[] pictureMaps = new PictureBox[CountObjectMap];

            Bitmap[] bitMaps = new Bitmap[CountObjectMap];

            #region Создает сетку из picterBox 10х10 по 20 пикселей 
            int c = 0;
            int a = 0;
            int g = 0;
            for (int x = 0; x < X; x = x + SIZEGRIG)
            {
                for (int y = 0; y < Y; y = y + SIZEGRIG)
                {
                    pictureMaps[a] = new PictureBox();
                    pictureMaps[a].Location = new System.Drawing.Point(SIZEGRIG * g, SIZEGRIG * c);
                    pictureMaps[a].Size = new System.Drawing.Size(SIZEGRIG, SIZEGRIG);
                    pictureMaps[a].Invalidate();
                    //pictureMaps[a].Image = bitMaps[a];
                    pictureMaps[a].Refresh();
                    pictureMaps[a].Name = "pic" + Convert.ToString(a);
                    a++;
                    g++;
                }
                g = 0;
                c++;
            }
            #endregion

            #region Добавляет picterBox на родительскую форму
            int b = 0;
            for (int x = 0; x < X; x = x + SIZEGRIG)
            {
                for (int y = 0; y < Y; y = y + SIZEGRIG)
                {

                    mainform.Controls.Add(pictureMaps[b]);
                    b++;
                }
            }
            #endregion

            #region Заполнение рисунками массив битмапов

            int i = 0;
            for (int x = 0; x < X; x = x + SIZEGRIG)
            {
                for (int y = 0; y < Y; y = y + SIZEGRIG)
                {
                    Random rd = new Random();
                    if (rd.Next(1, 10) > 5)
                    {
                        bitMaps[i] = new Bitmap(@"C:\Users\g4p\Pictures\Tank2.png", true);
                    }
                    else
                    {
                        bitMaps[i] = new Bitmap(@"C:\Users\g4p\Pictures\Tank.png", true);
                    }
                    i++;
                    #region  случайным образом добавляет на кару
                    //Random rd = new Random();

                    //bitMaps[i] = new Bitmap(@"C:\Users\g4p\Pictures\Tank2.png", true);
                    //int rdnext = rd.Next(1, 10);
                    //if ((rdnext > 5) && i % 2 == 0)
                    //{
                    //    bitMaps[i] = new Bitmap(@"C:\Users\g4p\Pictures\Tank.png", true);
                    //    //MessageBox.Show(Convert.ToString(rdnext));
                    //}
                    //else
                    //{
                    //    bitMaps[i] = new Bitmap(@"C:\Users\g4p\Pictures\Tank2.png", true);
                    //}
                    #endregion
                }
            }
               
            #endregion

            #region Добавляет в picterBox рисунки из массива битмапов
            
            int ed = 0;
            int gt = 0;
            for (int x = 0; x < X; x = x + SIZEGRIG)
            {
                for (int y = 0; y < Y; y = y + SIZEGRIG)
                {
                    pictureMaps[ed].Image = bitMaps[ed];
                    ed++;
                    gt++;
                }
                gt = 0;
            }

            #endregion

            #region Удаляет из picterBox рисунки

            int edс = 0;
            int gtу = 0;
            for (int x = 0; x < X; x = x + SIZEGRIG)
            {
                for (int y = 0; y < Y; y = y + SIZEGRIG)
                {

                    pictureMaps[edс].Image = null;
                    //pictureMaps[a].Invalidate();
                    pictureMaps[edс].Refresh();
                    edс++;
                    gtу++;
                }
                gtу = 0;
            }

            #endregion


        }

       
    }
}
