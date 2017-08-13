using NConsoleGraphics;

namespace OOPGame
{

    public interface IGameObject
    {

        void Render(ConsoleGraphics graphics);

        void Update(GameEngine engine);

        int[] GetCoords();
        void SetCoords(int x, int y);
        int[] GetLastCoords();

    }
}