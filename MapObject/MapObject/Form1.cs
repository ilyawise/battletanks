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
    public partial class FormMap : Form
    {
        public FormMap()
        {
            InitializeComponent();
        }

        private void buttonCreateMap_Click(object sender, EventArgs e)
        {
           

            Game game = new Game();
            game.Start(this);

            #region
            //Map map = new Map();
            
            //map.SetMapCoordinates(200, 200, 20);
            //map.Refresh();
            //map.Show(this);

            //map.AddObject(IObjectMap objectmap);
            //map.AddObjects(ObjectMaps objectmaps);
            //map.UpdateLocation(ObjectMaps objectmaps);
            //map.UpdateObjectLocation(IObjectMap objectmap);


            //Game game = new Game();
            //game.Start();
            //game.Stop();

            #endregion

            //PrintMapOnForm();
        }

        //############################################################
        private bool push = true;
        private void button1_Click(object sender, EventArgs e)
        {
            
            //Map map = new Map();
            //map.SetMapCoordinates(200, 200, 20);
            //map.Refresh(this);
            if (push)
            {
                timer1.Interval = 500;
                timer1.Start();
              
                push = false;
            }
            else
            {
                timer1.Stop();
               
                push = true;
            }
        }

        private bool Tic = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            // берется массив объектов 
            // уже с формированной картой
            // алгоритм опрашивает каждый объект
            // проверяет его состояние, куда едет,
            // летит, стоит. Если объект движется,то
            // проверяется рядом стоящего объект( по направлению
            // движения, и либо удаляется объект, либо не пускается
            // дальше, либо движение искажается..
            // Потом сформированный массив объектов передается 
            // на печать , и цикл повторятеся..

            #region Мигает красным цветом на форме
            //if (Tic)
            //{
            //    Bitmap MyImage = null;
            //    // Sets up an image object to be displayed.
            //    if (MyImage != null)
            //    {
            //        MyImage.Dispose();
            //    }

            //    // Stretches the image to fit the pictureBox.
            //    //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //    MyImage = new Bitmap(@"C:\Users\g4p\Pictures\Tank.png");
            //    //pictureBox1.ClientSize = new Size(xSize, ySize);
            //    pictureBox1.Image = (Image)MyImage;
            //    Tic = false;

            //}
            //else
            //{
            //    pictureBox1.Image = null;
            //    pictureBox1.Refresh();
            //    Tic = true;
            //}
            #endregion
        }



        private void PrintMapOnForm()
        {
            Bitmap[] bitMaps = CreateBitmaps();
            // из массива разных битмапов склеивает один битмэп
            // и рисует его на форме
            pictureBox1.Image = GetBitmap(bitMaps);
        }
        private Bitmap GetBitmap(Bitmap[] bitmaps)
        {
            // сколько битмапов в массиве
            int heightsBitmaps = bitmaps[0].Height;
            int rebromaps = heightsBitmaps * 10;

            Bitmap map = new Bitmap(rebromaps, rebromaps);

            //map.SetPixel(0, 0, Color.Blue);
            Image image = (Image)map;
            Graphics G = Graphics.FromImage(image);

            Image imageOneElement;

            int a = 0;
            int c = 0;
            int g = 0;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    imageOneElement = (Image)bitmaps[a];
                    G.DrawImage(imageOneElement, g * heightsBitmaps,
                                c * heightsBitmaps, 20, 20);
                    a++;
                    g++;
                }
                c++;
                g = 0;
            }

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
