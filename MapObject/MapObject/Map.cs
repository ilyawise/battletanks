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
    class Map
    {
        private PictureBox pictureMap;
        
        private IObjectMap[] objectsOnMap;
          
        public void SetPictureBox(PictureBox newpictureMap)
        {
            pictureMap = newpictureMap;
        }
        public void CreateObjectMapCollection()
        {
            objectsOnMap = new IObjectMap[100];
        }
        public void AddObjectMap(IObjectMap objectmap)
        {
            objectsOnMap[0] = objectmap;
        }
        public void Show()
        {
            // из массива вытаскиваем объекты 
            // и рисуем их на форме
            PrintMapOnForm();
        }
        private void PrintMapOnForm()
        {
            //Bitmap[] bitMaps = CreateBitmaps();
            // из массива разных битмапов склеивает один битмэп
            // и рисует его на форме
            pictureMap.Image = GetBitmap();
        }
        private Bitmap GetBitmap()
        {
            Bitmap map = new Bitmap(200, 200);

            //map.SetPixel(0, 0, Color.Blue);
            Image image = (Image)map;
            Graphics G = Graphics.FromImage(image);

            Image imageOneElement;

            imageOneElement = (Image)objectsOnMap[0].GetImage();
            G.DrawImage(imageOneElement, objectsOnMap[0].GetPoint().X,
                        objectsOnMap[0].GetPoint().Y, 20, 20);
            //int a = 0;
            //int c = 0;
            //int g = 0;
            //for (int x = 0; x < 10; x++)
            //{
            //    for (int y = 0; y < 10; y++)
            //    {
            //        imageOneElement = (Image)objectsOnMap[a].GetImage();
            //        G.DrawImage(imageOneElement, objectsOnMap[a].GetPoint().X,
            //                    objectsOnMap[a].GetPoint().Y, 20, 20);
            //        a++;
            //        g++;
            //    }
            //    c++;
            //    g = 0;
            //}

            return map;
        }
        private Bitmap[] CreateBitmaps()
        {
            #region создаем разноцветные объекты на карте
            Bitmap[] bitMaps = new Bitmap[100];

            Bitmap objectMap = new Bitmap(20, 20);
            Graphics GR = Graphics.FromImage((Image)objectMap);
            Random randomColor = new Random();

            int i = 0;
            for (int x = 0; x < 100; x++)
            {
                Color rectangleColor = Color.FromArgb(randomColor.Next(0, 254),
                                                  randomColor.Next(0, 254),
                                                  randomColor.Next(0, 254));

                GR.FillRectangle(new SolidBrush(rectangleColor), 0, 0, 20, 20);
                bitMaps[i] = new Bitmap((Image)objectMap);
                //bitMaps[i] = new Bitmap(@"C:\Users\g4p\Pictures\Tank2.png", true);

                i++;
            }

            return bitMaps;
            #endregion
        }
    }
}
