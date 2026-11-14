<<<<<<< HEAD
using System.Threading;
Console.WriteLine("Выберите размер поля");
string input = Console.ReadLine();
bool success = int.TryParse(input, out int size);
if(!success)
{
    Console.WriteLine("Можно ввести только целое число!");
    return;
}
else if(size > 100 || size < 5)
{
    Console.WriteLine("Доска не может быть меньше 5 и больше 100!");
    return;
}
bool[,] land = new bool[size, size];
bool[,] nextLand = new bool[size, size];
InitializeLand(land);
while (true)
{
    Console.Clear();
    printLand(land);
    nextGeneration(nextLand, land);
    for(int row = 0; row < land.GetLength(0); row++)
    {
        for(int col = 0; col < land.GetLength(1); col++)
        {
            land[row, col] = nextLand[row, col];
        }
    }
    Thread.Sleep(500);
}



static int CountNeighbours(bool[,] land, int row, int col)
{
    int neighbours = 0;
    for(int rowOffset = -1; rowOffset < 2; rowOffset++)
    {
        for(int colOffset = -1; colOffset < 2; colOffset++)
        {
                int newRow = row + rowOffset;
                int newCol = col + colOffset;
            if(rowOffset == 0 && colOffset == 0){
                continue;
            }
            if(newRow >= land.GetLength(0) || newCol >= land.GetLength(1) || newRow < 0 || newCol < 0){
                continue;
            }
            if(land[newRow, newCol] is true){
                neighbours++;
            }
        }
    }
    return neighbours;
}
static void nextGeneration(bool[,] nextLand, bool[,] land)
{
    for(int row = 0; row < land.GetLength(0); row++)
    {
        for(int col = 0; col < land.GetLength(1); col++)
        {
            int neighbours = CountNeighbours(land, row, col);
            if(land[row, col] && (neighbours == 2 || neighbours == 3))
            {
                nextLand[row, col] = true;
            }
            else if(land[row, col] == false && neighbours == 3)
            {
                nextLand[row, col] = true;
            }
            else
            {
                nextLand[row, col] = false;
            }
        }
    }
}
static void printLand(bool[,] land)
{
    for(int row = 0; row < land.GetLength(0); row++)
    {
        for(int col = 0; col < land.GetLength(1); col++)
        {
            if(land[row, col] is true)
            {
                Console.Write("A ");
            }
            else
            {
                Console.Write("D ");
            }
        }
        Console.WriteLine();
    }
}
static void InitializeLand(bool[,] land)
{
    int answer = 0;
    Random random = new Random();
    while(true)
    {         
        Console.WriteLine("Выберите шанс. 1-100%");
        try
        {
            answer = int.Parse(Console.ReadLine());
        }
        catch(Exception)
            {
            Console.WriteLine("Неудалось преобразовать строку в число!");    
                continue;
            }
        if(answer > 100 || answer < 1)
            {
                Console.WriteLine("Допустимый диапозон от 1 до 100!");
                continue;
            }
        break;
    }
    for(int row = 0; row < land.GetLength(0); row++)
    {
        for(int col = 0; col < land.GetLength(1); col++)
        {
            int j = random.Next(1, 101);  
            if(j <= answer)
            {
                land[row, col] = true;
            }
            else
            {
                land[row, col] = false;
            }
        }
    }

}
=======
namespace GameOfLife;

public class gameOfLife
{
    private bool[,] land = new bool [5, 5];
    private int answer;
    public bool[,] Land => land;
    public bool[,] NextLand => nextLand;
    private bool[,] nextLand = new bool[5, 5];
    private int CountNeighbours(int row, int col)
{
    int neighbours = 0;
    
    for(int rowOffset = -1; rowOffset < 2; rowOffset++)
    {
        for(int colOffset = -1; colOffset < 2; colOffset++)
        {
                int newRow = row + rowOffset;
                int newCol = col + colOffset;
            if(rowOffset == 0 && colOffset == 0){
                continue;
            }
            if(newRow >= land.GetLength(0) || newCol >= land.GetLength(1) || newRow < 0 || newCol < 0){
                continue;
            }
            if(land[newRow, newCol] is true){
                neighbours++;
            }
        }
    }
    return neighbours;
}
    public void nextGeneration()
    {
        for(int row = 0; row < land.GetLength(0); row++)
        {
            for(int col = 0; col < land.GetLength(1); col++)
            {
                int neighbours = CountNeighbours(row, col);
                if(land[row, col] && (neighbours == 2 || neighbours == 3))
                {
                    nextLand[row, col] = true;
                }
                else if(land[row, col] == false && neighbours == 3)
                {
                    nextLand[row, col] = true;
                }
                else
                {
                    nextLand[row, col] = false;
                }

            }
        }
        bool[,] temp = land;
        land = nextLand;
        nextLand = temp;
    }
    public void InitializeLand()
        {   
        
        Random random = new Random();
        for(int row = 0; row < land.GetLength(0); row++)
        {
            for(int col = 0; col < land.GetLength(1); col++)
            {
                int j = random.Next(0, 100);  
                if(j <= answer)
                {
                    land[row, col] = true;
                }
                else
                {
                    land[row, col] = false;
                }
            }
        }

        }
      public gameOfLife(int gameSize, int gameChance)
    {
        answer = gameChance;
        land = new bool[gameSize, gameSize];
        nextLand = new bool[gameSize, gameSize];
        InitializeLand();

    }
}
>>>>>>> 995ee32 (Initial commit: Game of Life)
