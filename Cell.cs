using System.Numerics;

 class Cell {
    public Vector2 position  = new Vector2 (0,0);
    public Vector2 size = new Vector2 (1,1);
    public Raylib_cs.Color color = Raylib_cs.Color.Black;

    void draw() {
        Raylib_cs.Raylib.DrawRectangleV(position, size, color);
    }

}