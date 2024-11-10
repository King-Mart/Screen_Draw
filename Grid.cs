using System.Numerics;


class Grid {
    public float cellSize, cellSpacing;
    public Raylib_cs.Color cellColor;
    public int gridHeight, gridLenght;
    public Cell[,] grid;

    public Vector2 topLeft = new Vector2 (0, 0);
    public Grid(float cellSize, float cellSpacing, Raylib_cs.Color cellColor){
        this.cellColor = cellColor;
        this.cellSize = cellSize;
        this.cellSpacing = cellSpacing;
    }

    public void initGrid(int  gridLenght, int gridHeight) {
        this.gridLenght = gridLenght;
        this.gridHeight = gridHeight;
        this.grid = new Cell[gridHeight, gridLenght];
        for (int i = 0; i < gridHeight; i++) {
            for (int j = 0; j < gridLenght; j++) {
                this.grid[i, j] = new Cell(topLeft + new Vector2 (j * (cellSize + cellSpacing), i * (cellSize + cellSpacing)), new Vector2 (cellSize, cellSize), cellColor);
                this.grid[i, j].number = i * gridLenght + j;
            }
        }
    }

    public void draw() {
        foreach (Cell cell in this.grid) {
            cell.draw();
        }
    }


}