using SerpenTina;
using System.Diagnostics;

internal class Program//a
{
    static void Main()//b
    {
        var gameLogic = new SnakeGameLogic();//c
        var input = new ConsoleInput();//d
        gameLogic.InitializeInput(input);//e
        var lastFrameTime = DateTime.Now;//f
        gameLogic.GoToGameplay();//g

        while (true)//h
        {
            input.Update();//h
            var frameStartTime = DateTime.Now;//i
            float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;//j
            gameLogic.Update(deltaTime);//k
            lastFrameTime = frameStartTime;//l
        }
    }
}