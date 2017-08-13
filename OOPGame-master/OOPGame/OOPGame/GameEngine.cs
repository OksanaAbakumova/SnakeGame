using NConsoleGraphics;
using System.Collections.Generic;
using System.Threading;
using System;
using System.Linq;

namespace OOPGame
{
    public class GameEngine
    {
        private int pixel = 20;
        private ConsoleGraphics graphics;
        private LinkedList<SnakeChain> snake = new LinkedList<SnakeChain>();

        private int applesEaten = 0;
                
        public GameEngine(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public int GetPixel()
        {
            return pixel;
        }

        public void Start()
        {
            snake.AddFirst(new SnakeChain(graphics));

            Apple apple = new Apple();
            apple.Update(this);

            // Game loop.
            while (true)
            {
                // Snake Loop
                int i = 0;
                foreach (var snakeChain in snake)
                {
                    if(i==0)
                    {
                        snakeChain.SetFirst();
                    }
                    snakeChain.Update(this, snake);
                    i++;
                }

                // clearing screen before painting new frame
                graphics.FillRectangle(0xFF000000, 0, 0, 655, 656);
                graphics.DrawRectangle(0xFFA9A9A9, 10, 10, 640, 640, 20); // FFA9A9A9-dark grey 

                // Thus, we have a matrix 34x34 for a game.
                // But as we have a frame which has the same h/w as a snake - this reduces the playable zone to 32x32.
 
                int[] snakeHeadCoords = snake.First().GetCoords(); /// !!!!!!!!!!!!!!!!!!!!!!!!!!

                if (
                    (snakeHeadCoords[0] == 0 || snakeHeadCoords[0] >= 640) ||
                    (snakeHeadCoords[1] == 0 || snakeHeadCoords[1] >= 640)
                )
                {
                    GameOver("out-of-frame");
                    return;
                }
                
                // Let's paint the apple
                apple.Render(graphics);

                // Have we eaten an apple?
                if (IsAppleEaten(snake.First(), apple))
                {
                    applesEaten++;
                    Console.WriteLine("                                                             Apples eaten: " + applesEaten);
                    
                    SaveNextSnakeChain();

                    // Regenerate apple coords.
                    apple.Update(this);
                }

                foreach (var snakeChain in snake)
                {
                    snakeChain.Render(graphics);
                }

                // double buffering technique is used
                graphics.FlipPages();

                Thread.Sleep(100);
            }
        }

        public Boolean IsAppleEaten(SnakeChain snakeChain, Apple apple)
        {
            return snakeChain.GetCoords().SequenceEqual(apple.GetCoords());
        }

        public void SaveNextSnakeChain()
        {
            SnakeChain lastChain = snake.Last();
            int[] lastCoords = lastChain.GetLastCoords();

            SnakeChain tempSnakeChain = new SnakeChain(graphics);
            tempSnakeChain.SetCoords(lastCoords);
            tempSnakeChain.SetVector(lastChain.GetLastVector());

            snake.AddLast(tempSnakeChain);
        }

        public void GameOver(string reason)
        {
            if (reason == "out-of-frame")
            {
                Console.WriteLine("                                                             You are out of game area.");
                Console.WriteLine("                                                             GAME OVER!");
            }

            if (reason == "test")
            {
                Console.WriteLine("                                                             TEST");
            }
        }
    }
}
