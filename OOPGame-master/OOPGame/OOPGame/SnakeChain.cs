using NConsoleGraphics;
using System.Collections.Generic;

namespace OOPGame
{

    public enum SnakeChainVector
    {
        Right, Left, Up, Down
    }

    public class SnakeChain
    {
        private bool isFirst = false;

        private int x = 320, y = 320;
        private int lastX = 320, lastY = 320;

        private SnakeChainVector vector = SnakeChainVector.Right;
        private SnakeChainVector lastVector = SnakeChainVector.Right;


        public SnakeChain(ConsoleGraphics graphics)
        {
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFF00FF00, x, y, 20, 20);
        }

        public void Update(GameEngine engine, LinkedList<SnakeChain> snake)
        {
            lastX = x;
            lastY = y;
            lastVector = vector;

            if (Input.IsKeyDown(Keys.LEFT) && vector != SnakeChainVector.Right)
            {
                x -= engine.GetPixel();
                vector = SnakeChainVector.Left;
            }
            else if (Input.IsKeyDown(Keys.RIGHT) && vector != SnakeChainVector.Left)
            {
                x += engine.GetPixel();
                vector = SnakeChainVector.Right;
            }
            else if (Input.IsKeyDown(Keys.UP) && vector != SnakeChainVector.Down)
            {
                y -= engine.GetPixel();
                vector = SnakeChainVector.Up;
            }
            else if (Input.IsKeyDown(Keys.DOWN) && vector != SnakeChainVector.Up)
            {
                y += engine.GetPixel();
                vector = SnakeChainVector.Down;
            }
            else
            {
                SnakeChainVector checkedVector;

                if (isFirst == true)
                {
                    checkedVector = vector;
                }
                else
                {
                    checkedVector = lastVector;
                }

                switch (checkedVector)
                {
                    case SnakeChainVector.Left:
                        x -= engine.GetPixel();
                        break;

                    case SnakeChainVector.Right:
                        x += engine.GetPixel();
                        break;

                    case SnakeChainVector.Up:
                        y -= engine.GetPixel();
                        break;

                    case SnakeChainVector.Down:
                        y += engine.GetPixel();
                        break;
                }
            }
        }

        public void SetFirst()
        {
            isFirst = true;
        }

        public SnakeChainVector GetVector()
        {
            return vector;
        }
        public SnakeChainVector GetLastVector()
        {
            return lastVector;
        }
        public void SetVector(SnakeChainVector newVector)
        {
            vector = newVector;
        }

        public int[] GetCoords()
        {
            var coords = new int[2];
            coords[0] = x;
            coords[1] = y;

            return coords;
        }
        public int[] GetLastCoords()
        {
            var coordsLast = new int[2];

            coordsLast[0] = lastX;
            coordsLast[1] = lastY;

            return coordsLast;
        }
        public void SetCoords(int[] newCoords)
        {
            x = newCoords[0];
            y = newCoords[1];
        }

    }
}