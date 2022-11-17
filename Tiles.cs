namespace Game_Off_2022;

public partial class Tiles : Form
{
    public TileButton[,] grid;

    public bool active = false;

    public Tiles(int w, int h)
    {
        grid = new TileButton[w, h];
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid.GetLength(i); j++) {
                Console.WriteLine(j);
                grid[i, j].x = i * 20;
                grid[i, j].y = j * 20;
                this.Controls.Add(grid[i, j]);
                grid[i, j].Clicked += tile_OnClick;
            }
        }
        Activate();
    }

    private void tile_OnClick(TileButton sender, int x, int y)
    {
        if (!active) {
            grid[x / 20, y / 20].state = TileState.None;
            // FillSpace();
        } else {
            sender.EvaluateTile(x, y);
        }
    }
}
