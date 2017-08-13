using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class Apple : IGameObject
    {
        private int x;
        private int y;

        Random rnd = new Random();

        /*
         * Generate random coordinates for the apple.
         */
        public void Update(GameEngine engine)
        {
            x = rnd.Next(1, 32) * engine.GetPixel();
            y = rnd.Next(1, 32) * engine.GetPixel(); // размер игрового поля без рамки
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFF0000, x, y, 20, 20);

        }

        public int[] GetCoords()
        {
            var coords = new int[2];
            coords[0] = x;
            coords[1] = y;

            return coords;
        }

        public void SetCoords(int x, int y)
        {
            throw new NotImplementedException();
        }
        public int[] GetLastCoords()
        {
            throw new NotImplementedException();
        }
    }
}
