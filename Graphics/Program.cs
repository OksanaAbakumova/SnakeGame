using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;
using System.IO;
using System.Threading;

namespace Graphics
{
    class Program
    {
        

        class Square
        {
            public ConsoleGraphics graphics;
            public int x;
            public int y;
            public int side;

            // точка начала -x,y,    z -  сторона
            public Square(ConsoleGraphics graphics, int x, int y, int side)  // передаем в конструктор обьект graphics чтобы пользоваться методами ConsoleGraphics
            {
                this.graphics = graphics;
                this.x = x;
                this.y = y;
                this.side = side;
            }


            public void DrawSuare()
            {
                graphics.DrawLine(0xFFFF0000, x, y, x + side, y, 5);
                graphics.DrawLine(0xFFFF0000, x + side, y, side + x, side + y, 5);
                graphics.DrawLine(0xFFFF0000, x + side, y + side, x, side + y, 5);
                graphics.DrawLine(0xFFFF0000, x, y, x, y + side, 5);

            }

        }

        public class Triangle
        {
            public ConsoleGraphics graphics;
            public int x;
            public int y;
            public int side;
           
            // точка начала -x,y,    z -  сторона
            public Triangle(ConsoleGraphics graphics, int x, int y, int side)  
            {
                this.graphics = graphics;
                this.x = x;
                this.y = y;
                this.side = side;
            }

            public void DrawTriangle()
            {
                graphics.DrawLine(0xFFFF0000, x, y, x +side/2, (side / 2)+y, 5);
                graphics.DrawLine(0xFFFF0000, x, y, x - side / 2, (side / 2) + y, 5);
                graphics.DrawLine(0xFFFF0000, x - side / 2, (side / 2) + y, x +side/2, (side / 2)+y, 5);
            }

            public  void UpdateTriangle()
            {
                if (Input.IsKeyDown(Keys.LEFT)) x = x-30;
                if (Input.IsMouseRightButtonDown) x = x+30;
            }

        }


        public class Star
        {
            public ConsoleGraphics graphics;
            public int x;
            public int y;
            public int side;

            public Star()
            {
            }
            // точка начала -x,y,    z -  сторона
            public Star(ConsoleGraphics graphics, int x, int y, int side)
            {
                this.graphics = graphics;
                this.x = x;
                this.y = y;
                this.side = side;
            }

            public void DrawTStar()
            {
                graphics.DrawLine(0xFFFF0000, x, y, x + side / 2, (side / 2) + y, 5);
                graphics.DrawLine(0xFFFF0000, x, y, x - side / 2, (side / 2) + y, 5);
                graphics.DrawLine(0xFFFF0000, x - side / 2, (side / 2) +y-side/4, x + side / 2, (side / 2) + y-side/4 , 5);
                graphics.DrawLine(0xFFFF0000, x + side / 2, (side / 2) + y - side / 4, x - side / 2, (side / 2) + y, 5);
                graphics.DrawLine(0xFFFF0000, x - side / 2, (side / 2) + y - side / 4, x + side / 2, (side / 2) + y, 5);
            }

        }

        static void Main(string[] args)
        {
            //Сделать что бы треугольник двигался управляются с клавиатуры стрелочками
            //Квадрат двигался по кругу
            //Кошка и звезда двигались по прямоугольной траэктории.

            ConsoleGraphics graphics = new ConsoleGraphics(); // создается новый обьект
            Console.CursorVisible = false; // прячется курсор

            // graphics.DrawLine(0xFFFF0000, 0, 0, graphics.ClientWidth, graphics.ClientHeight, 5); // (цвет- RGB запись, координаты начала линии (x,y), координаты конца, ширина)

            // Console.ReadLine();

            //Paint Rectagle

          // graphics.FillRectangle(0xFFFF0000, 50, 50, 100, 100);

            // Triangle

            Triangle s1 = new Triangle(graphics, 100, 100, 100);

             s1.DrawTriangle();

            // Star

            Star s2 = new Star(graphics, 300, 100, 100);

            //  s2.DrawTStar();

            //Cat(from image)
            //ConsoleImage image = graphics.LoadImage("C:\\Users\\oksan\\Desktop\\Cards\\Cat.jpg");
            // graphics.DrawImage(image, 500,200);

            /*
            1. Clear Screen!
            2. Update object
            3. Render again
            */

            //while (true)
            //{
            //    // Clear Screen
            //    graphics.FillRectangle(0xFF00FF00, 0, 0, graphics.ClientWidth, graphics.ClientHeight);
            //    // Update object
            //    s1.UpdateTriangle();
            //    // Draw again
            //    s1.DrawTriangle();
            //}

            ConsoleGraphics graphics1 = new ConsoleGraphics();

            while (true)
            {
                // Clear Screen

                // Update object


                //draw 
                graphics1.FlipPages();   // решает проблему моргания, последний метод отрисовки
                Thread.Sleep(10);



            }
            // Thread.Sleep(10); //притормозить использование 

            //Square[] s = new Square[200];


            //int y = 40;
            //int index = 0;

            //for (int z = 0; z < 8; z++)
            //{
            //    int x = 5;

            //    for (int i = 0; i < 20; i++)
            //    {

            //        s[index] = new Square(graphics, x, y, 15);
            //        s[index].DrawSuare();
            //        x += 30;
            //        index++;
            //    }

            //    y += 50;

            //}


            // Square s1 = new Square(graphics, 10, 50, 50);
            //Square s2 = new Square(graphics, 110, 50, 50);
            //Square s3 = new Square(graphics, 210, 50, 50);
            //Square s4 = new Square(graphics, 310, 50, 50);
            //Square s5 = new Square(graphics, 410, 50, 50);



            //s1.DrawSuare();
            //s2.DrawSuare();
            //s3.DrawSuare();
            //s4.DrawSuare();
            //s5.DrawSuare();


        }
    }
}
