using NConsoleGraphics;
using System;
using System.Collections.Generic;

namespace OOPGame
{

    public class Program
    {
        static void Main(string[] args)
        {
            // Screen resolution, font size, scale rate are affecting all these values.
            // This won't work as expected on other computers.
            Console.WindowWidth = (Console.LargestWindowHeight * 2) + 55; // 87 characters on a row, that's ~= Height - for a game, and 50 - for text.
            Console.WindowHeight = Console.LargestWindowHeight; // 41 rows is a max on Dell XPS 13"
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();

            Console.WriteLine("                                                             Game Started.");

            GameEngine engine = new GameEngine(graphics);
            engine.Start();
        }
    }
}
