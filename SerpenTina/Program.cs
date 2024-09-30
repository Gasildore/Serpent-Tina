using SerpenTina;
using System.Diagnostics;

internal class Program
{
    const float _targetFrameTime = 1f / 60f;
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var gameLogic = new SnakeGameLogic();
        var input = new ConsoleInput();        
        var lastFrameTime = DateTime.Now;
        var palette = gameLogic.CreatePalette();

        var renderer0 = new ConsoleRenderer(palette);
        var renderer1 = new ConsoleRenderer(palette);

        var prevRenderer = renderer0;
        var currRenderer = renderer1;

        gameLogic.InitializeInput(input);

        while (true)
        {
            input.Update();
            var frameStartTime = DateTime.Now;
            float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;

            gameLogic.DrawNewState(deltaTime, currRenderer);

            if (!currRenderer.Equals(prevRenderer))
                currRenderer.Render();

            var tmp = prevRenderer;
            prevRenderer = currRenderer;
            currRenderer = tmp;
            currRenderer.Clear();

            lastFrameTime = frameStartTime;

            var nextFrameTime = frameStartTime + TimeSpan.FromSeconds(_targetFrameTime);
            var endFrameTime = DateTime.Now;

            if (nextFrameTime > endFrameTime)
                Thread.Sleep((int)(nextFrameTime - endFrameTime).TotalMilliseconds);
        }
    }
}