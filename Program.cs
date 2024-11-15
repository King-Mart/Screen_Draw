// See https://aka.ms/new-console-template for more information

using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

class Program {
    
    static Vector2 villagerPosition;
    static Vector2 villagerSize = new Vector2 (48,48);
    static int currentPopulation;
    static Vector2 villagerMove;
    static Grid gridMap = new Grid((float)24, (float)2, Raylib_cs.Color.Blue);

    static Raylib_cs.Color gridMSGColor;
    static string gridMSG = "";
    
    static Random RandomNumGenerator = new Random();

    static int[]? activeCell = null;

    static Color[] colorCode = {Color.Green, Color.Red};
    static int[,] colorStory = new int[2,2];
    static int historyCount = 0;
    //This is the history of previously visited cells : { {cellCoord1}, {cellCoor2}}

    

    

    static int reallyLongLoop(int range) {
        int i = 0;
        while (i < range){
            i += 1;
        }
        return 1;
    }
    /// <summary>
/// Colors the cells in the grid based on their history.
/// </summary>
/// <param name="historyCount">The number of cells to color.</param>
/// <param name="colorStory">The history of cell coordinates to be colored.</param>
/// <param name="grid">The grid containing the cells.</param>
/// <param name="colorCode">The colors to apply to each cell in history.</param>
static void colorHistory(int historyCount, int[,] colorStory, Grid grid, Color[] colorCode) {
    // Iterate over each entry in the color history
    for (int i = 0; i < historyCount; i++) {
        // Apply the corresponding color to the cell in the grid
        grid.grid[colorStory[i,0], colorStory[i,1]].color = colorCode[i];
    }
}
    //Update the state of the simulation
    static int updateState() {

        villagerMove = new Vector2 ((float)RandomNumGenerator.Next(-1,2), (float)RandomNumGenerator.Next(-1, 2));


        Vector2 mousePosition = new Vector2((float)Raylib_cs.Raylib.GetMouseX(), (float)Raylib_cs.Raylib.GetMouseY());
        bool mouseInGrid = gridMap.in_vicinity(mousePosition);
        if (mouseInGrid) {
            gridMSG = "The mouse is in the grid";
            gridMSGColor = Raylib_cs.Color.Green;
            int[] cellCoord = gridMap.getCell(mousePosition);


            if (historyCount == 0) {
                historyCount += 1;
                colorStory[0,0] = cellCoord[0];
                colorStory[0,1] = cellCoord[1];
                colorHistory(historyCount, colorStory, gridMap, colorCode);
            }
            else {


                if (cellCoord[0] != colorStory[0,0] || cellCoord[1] != colorStory[0,1]) {
                    if (historyCount == 1) { historyCount += 1; }
                    if (historyCount == 2) {  gridMap.grid[colorStory[1,0], colorStory[1,1]].color = gridMap.cellColor; }
                    colorStory[1,0] = colorStory[0,0];
                    colorStory[1,1] = colorStory[0,1];
                    colorStory[0,0] = cellCoord[0];
                    colorStory[0,1] = cellCoord[1];
                    colorHistory(historyCount, colorStory, gridMap, colorCode);
                        
                }

            }
            // // Check if the cell is already hovered
            // if ( activeCell != null && !(activeCell[0] == cellCoord[0] && cellCoord[1] == activeCell[1])) {
            //     Console.WriteLine($"cell cord : ({cellCoord[0]}, {cellCoord[1]}),  active cell :({activeCell[0]}, {activeCell[1]})");
            //     gridMap.grid[cellCoord[0], cellCoord[1]].color = Color.Green;
            //     gridMap.grid[activeCell[0], activeCell[1]].color = gridMap.cellColor;
            //     activeCell = cellCoord;
            // }
            // else if (activeCell == null) {
            //     gridMap.grid[cellCoord[0], cellCoord[1]].color = Color.Green;
            //     activeCell = cellCoord;
            // }

        }
        else {
            if (activeCell != null) {
                gridMap.grid[activeCell[0], activeCell[1]].color = gridMap.cellColor;
                activeCell = null;
            }
            gridMSG = "The mouse is outside the grid";
            gridMSGColor = Raylib_cs.Color.Red;
        }
        return 1;

    }

    static int drawState() {
        Raylib.BeginDrawing();

        Raylib_cs.Raylib.ClearBackground(Raylib_cs.Color.RayWhite);
        Raylib_cs.Raylib.DrawText(gridMSG, 50, 50, 24, gridMSGColor);
        Raylib_cs.Raylib.DrawText("The current population is : " + currentPopulation.ToString(), 100, 100, 24, Raylib_cs.Color.DarkGray);
        Raylib.DrawRectangleV(villagerPosition, villagerSize, Raylib_cs.Color.Purple);
        Raylib_cs.Raylib.DrawText("The current position of purple is : " + villagerPosition.ToString(), 130, 130, 24, Raylib_cs.Color.DarkGray);
        Raylib_cs.Raylib.DrawText($"Your mouse is at coordinate : ({Raylib_cs.Raylib.GetMouseX()},{Raylib_cs.Raylib.GetMouseY()})", 170, 170, 24, Raylib_cs.Color.DarkGray);

        gridMap.draw();

        Raylib.EndDrawing();
        return 1;
    }

    static int Main()
    {
        const int screenWidth = 800;
        const int screenHeight = 600;
        

        Console.WriteLine("Hello, World!");
        Raylib_cs.Raylib.InitWindow(screenWidth, screenHeight, "The grand evolution");

        villagerPosition = new Vector2((float)screenWidth / 2, (float)screenHeight / 2);
        currentPopulation = 1;
        gridMap.topLeft = new Vector2 ((float)0, (float)200);
        gridMap.initGrid(20, 15);
        villagerPosition = gridMap.getBoundaries();

        Raylib_cs.Raylib.SetTargetFPS(120);

        while (!Raylib_cs.Raylib.WindowShouldClose()) {
            int updateStatus = updateState();

            // Console.WriteLine(format:"The frame computed with code " +  updateStatus.ToString());
            int drawStatus = drawState();
            // Console.WriteLine(format:"The frame drew itself with code %d" + drawStatus.ToString());
            
            
            
        }

        

        Raylib_cs.Raylib.CloseWindow();

        return 1;

    }

    


}
