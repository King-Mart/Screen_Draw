// See https://aka.ms/new-console-template for more information

class Program {
    
static int reallyLongLoop(int range) {
    int i = 0;
    while (i < range){
        i += 1;
    }
    return 1;
}
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Raylib_cs.Raylib.InitWindow(800, 600, "The grand evolution");

        reallyLongLoop(999999999);
        Raylib_cs.Raylib.CloseWindow();

    }


}
