namespace Game_Off_2022;

public class TileButton : Button
{
    public int x;
    public int y;
    public bool Unclicked;
    public TileState state;
    public delegate void ClickHandler(TileButton self, int x, int y);
    public event ClickHandler? Clicked;

    public TileButton(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.Unclicked = true;
        this.Size = new Size(20, 20);
        this.Location = new Point(x, y);
        this.Text = Unclicked ? "" : Convert.ToString((int)state);
        this.Click += new EventHandler(OnClick);
    }

    public void EvaluateTile(int x, int y)
    {
        this.state = TileState.Three; // Three as temporary test
        this.Text = (int)state == 0 ? "" : Convert.ToString((int)state);
    }

    private void OnClick(object? sender, EventArgs e)
    {
        this.Unclicked = false;
        Clicked?.Invoke(this, this.x, this.y);
    }
}

public enum TileState : int
{
    None,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven
}
