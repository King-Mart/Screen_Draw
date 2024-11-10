using System.Numerics;

 class Cell {
    public Vector2 position;
    public Vector2 size;
    public Raylib_cs.Color color;

    public int number = 0;

    public Cell(Vector2 position, Vector2 size, Raylib_cs.Color color) {
        this.position = position;
        this.size = size;
        this.color = color;
    }

    public void draw() {
        Raylib_cs.Raylib.DrawRectangleV(this.position, this.size, this.color);
        Raylib_cs.Raylib.DrawText(this.number.ToString(), (int)( this.position.X), (int)(this.position.Y), (int)(Math.Min(this.size.X/2, this.size.Y/2)), Raylib_cs.Color.RayWhite);
    }

}