﻿// See https://aka.ms/new-console-template for more information

using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

class Program {
    
    static Vector2 villagerPosition;
    static Vector2 villagerSize = new Vector2 (48,48);
    static int currentPopulation;
    static Cell testCell;
    static Vector2 villagerMove;
    
    static Random RandomNumGenerator = new Random();

    static int reallyLongLoop(int range) {
        int i = 0;
        while (i < range){
            i += 1;
        }
        return 1;
    }

    //Update the state of the simulation
    static int updateState() {

        villagerMove = new Vector2 ((float)RandomNumGenerator.Next(-1,2), (float)RandomNumGenerator.Next(-1, 2));

        villagerPosition += villagerMove;
        testCell.size += villagerMove;
        return 1;

    }

    static int drawState() {
        Raylib.BeginDrawing();

        Raylib_cs.Raylib.ClearBackground(Raylib_cs.Color.RayWhite);
        Raylib_cs.Raylib.DrawText("The current population is : " + currentPopulation.ToString(), 100, 100, 24, Raylib_cs.Color.DarkGray);
        Raylib_cs.Raylib.DrawText("The current movement vector is : " + villagerMove.ToString(), 130, 130, 24, Raylib_cs.Color.DarkGray);
        Raylib.DrawRectangleV(villagerPosition, villagerSize, Raylib_cs.Color.Purple);
        testCell.draw();

        Raylib.EndDrawing();
        return 1;
    }

    static void Main()
    {
        const int screenWidth = 800;
        const int screenHeight = 600;
        

        Console.WriteLine("Hello, World!");
        Raylib_cs.Raylib.InitWindow(screenWidth, screenHeight, "The grand evolution");

        villagerPosition = new Vector2((float)screenWidth / 2, (float)screenHeight / 2);
        currentPopulation = 1;
        testCell = new Cell(villagerPosition - villagerSize, new Vector2(16, 16), Raylib_cs.Color.Black);

        Raylib_cs.Raylib.SetTargetFPS(120);

        while (!Raylib_cs.Raylib.WindowShouldClose()) {
            
            int updateStatus = updateState();

            // Console.WriteLine(format:"The frame computed with code " +  updateStatus.ToString());
            int drawStatus = drawState();
            // Console.WriteLine(format:"The frame drew itself with code %d" + drawStatus.ToString());
            
        }

        

        Raylib_cs.Raylib.CloseWindow();

    }


}
