using System.Numerics;

 class Cell {
    public Vector2 position;
    public Vector2 size;
    public Raylib_cs.Color color;

    public Cell(Vector2 position, Vector2 size, Raylib_cs.Color color) {
        this.position = position;
        this.size = size;
        this.color = color;
    }

    public void draw() {
        Raylib_cs.Raylib.DrawRectangleV(position, size, color);
    }

}