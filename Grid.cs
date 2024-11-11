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
        for (int row = 0; row < gridHeight; row++) {
            for (int column = 0; column < gridLenght; column++) {
                this.grid[row, column] = new Cell(topLeft + new Vector2 (column * (cellSize + cellSpacing), row * (cellSize + cellSpacing)), new Vector2 (cellSize, cellSize), cellColor);
                this.grid[row, column].number = row * gridLenght + column;
            }
        }
    }

    /// <summary>
    /// Returns the size of the grid in pixels. The size is calculated
    /// by multiplying the cellSize plus cellSpacing by the gridLenght
    /// and gridHeight, and then subtracting the cellSpacing.
    /// </summary>
    /// <returns>The size of the grid in pixels as a Vector2.</returns>
    public Vector2 getBoundaries() {
        float width = (float)this.gridLenght;
        float height = (float)this.gridHeight;
        width = (this.cellSize + this.cellSpacing) * width - this.cellSpacing;
        height = (this.cellSize + this.cellSpacing) * height - this.cellSpacing;


        return new Vector2(width, height) + topLeft;
    }

    /// <summary>
    /// Draws each cell in the grid.
    /// </summary>
    public void draw() {
        foreach (Cell cell in this.grid) {
            cell.draw();
        }
    }


}