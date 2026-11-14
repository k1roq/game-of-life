namespace GameOfLife;

public partial class Form1 : Form
{
    private Label sizeLabel;
    private Label chanceLabel;
    int size = 5;
    int chance = 50;
    private gameOfLife game;
    private System.Windows.Forms.Timer timer;
    private NumericUpDown sizeSelector;
    private Button generateGeneration;
    private NumericUpDown aliveChance;
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        for(int row = 0; row < size; row++)
        {
            for(int col = 0; col < size; col++)
            {
                int x = col * cellSize;
                int y = row * cellSize;
                if(game.Land[row, col])
                {
                    e.Graphics.FillRectangle(Brushes.Black, x, y, cellSize, cellSize);
                    e.Graphics.DrawRectangle(Pens.Gray, x, y, cellSize, cellSize);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, x, y, cellSize, cellSize);
                    e.Graphics.DrawRectangle(Pens.Gray, x, y, cellSize, cellSize);
                }
                
            }
        }
    } 

    int cellSize = 60;
    public Form1()
    {
        InitializeComponent();
        DoubleBuffered = true;
        sizeSelector = new NumericUpDown();
        sizeSelector.Minimum = 5;
        sizeSelector.Maximum = 20;
        sizeSelector.Value = 15;
        sizeSelector.Width = 40;
        size = Convert.ToInt32(sizeSelector.Value);
        Controls.Add(sizeSelector);
        generateGeneration = new Button();
        generateGeneration.Text = "Generate new Generation";
        Controls.Add(generateGeneration);
        aliveChance = new NumericUpDown();
        aliveChance.Minimum = 1;
        aliveChance.Maximum = 100;
        aliveChance.Value = 50;
        aliveChance.Width = 40;
        chance = Convert.ToInt32(aliveChance.Value);
        Controls.Add(aliveChance);
        ClientSize = new Size(size * cellSize + 180, size * cellSize);
        sizeLabel = new Label();
        sizeLabel.Text = "Размер поля:";
        sizeLabel.AutoSize = true;
        Controls.Add(sizeLabel);
        chanceLabel = new Label();
        chanceLabel.Text = "Вероятность живых клеток (%):";
        chanceLabel.AutoSize = true;
        Controls.Add(chanceLabel);
        sizeSelector.Location = new Point(size * cellSize + 15, size * cellSize - sizeSelector.Height - 100);
        generateGeneration.Location = new Point(size * cellSize + 65, size * cellSize - generateGeneration.Height - 50);
        aliveChance.Location = new Point(size * cellSize + 15, size * cellSize - aliveChance.Height - 50);
        sizeLabel.Location = new Point(sizeSelector.Left - 5, sizeSelector.Top - 20);
        chanceLabel.Location = new Point(aliveChance.Left - 5, aliveChance.Top - 20);
        timer = new System.Windows.Forms.Timer();
        timer.Interval = 500;
        timer.Tick += (sender, e) =>
        {
          game.nextGeneration();
          Invalidate();  
        };
        game = new gameOfLife(size, chance);
        timer.Start();
        generateGeneration.Click += (sender, e) =>
        {
            timer.Stop();
            size = Convert.ToInt32(sizeSelector.Value);
            chance = Convert.ToInt32(aliveChance.Value);
            game = new gameOfLife(size, chance);
            ClientSize = new Size(size * cellSize + 180, size * cellSize);
            sizeSelector.Location = new Point(size * cellSize + 15, size * cellSize - sizeSelector.Height - 100);
            generateGeneration.Location = new Point(size * cellSize + 65, size * cellSize - generateGeneration.Height - 50);
            aliveChance.Location = new Point(size * cellSize + 15, size * cellSize - aliveChance.Height - 50);
            chanceLabel.Location = new Point(aliveChance.Left - 5, aliveChance.Top - 20);
            sizeLabel.Location = new Point(sizeSelector.Left - 5, sizeSelector.Top - 20);
            Invalidate();
            timer.Start();
        };
        Invalidate();
    }
}
