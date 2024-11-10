// See https://aka.ms/new-console-template for more information

using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Program {
    
    static Vector2 villagerPosition;

    static int reallyLongLoop(int range) {
        int i = 0;
        while (i < range){
            i += 1;
        }
        return 1;
    }

    //Update the state of the simulation
    static int updateState() {
        Console.WriteLine(villagerPosition);
        return 1;

    }

    static void Main()
    {
        const int screenWidth = 800;
        const int screenHeight = 8600;

        Console.WriteLine("Hello, World!");
        Raylib_cs.Raylib.InitWindow(screenWidth, screenHeight, "The grand evolution");

        villagerPosition = new Vector2((float)screenWidth / 2, (float)screenHeight / 2);

        Raylib_cs.Raylib.SetTargetFPS(120);

        while (!Raylib_cs.Raylib.WindowShouldClose()) {
            
        }

        

        reallyLongLoop(999999999);
        Raylib_cs.Raylib.CloseWindow();

    }


}
