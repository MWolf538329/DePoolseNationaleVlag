using DePoolseNationaleVlag;

List<Stone> stonePile = new List<Stone>();

bool Continue = true;

while (Continue)
{
    Console.WriteLine("Type the amount of red stones:");
    AddStonesToPile(Convert.ToInt32(Console.ReadLine()), CustomEnums.Colors.Red);

    Console.WriteLine("Type the amount of white stones:");
    AddStonesToPile(Convert.ToInt32(Console.ReadLine()), CustomEnums.Colors.White);

    ShuffleStones();

    Console.WriteLine("\nShuffled:");
    DisplayShuffledStones();

    SortStonesUsingBubble();

    Console.WriteLine("\n \n How do you want to display the flag? Text or Flag");

    string format = Console.ReadLine();

    Console.WriteLine("\n \nSorted:");

    switch (format)
    {
        case "Text":
            DisplaySortedStonesAsText();
            break;

        case "Flag":
            DisplaySortedStonesAsFlag();
            break;

        default:
            DisplaySortedStonesAsText();
            break;
    }

    stonePile.Clear();

    Console.WriteLine("Continue?");
    Continue = Convert.ToBoolean(Console.ReadLine());
}

#region Functions
void AddStonesToPile(int amount, CustomEnums.Colors color)
{
    /// Add red stonePile to list.
    for (int i = 0; i < amount; i++)
    {
        stonePile.Add(new Stone(color));
    }
}

void ShuffleStones()
{
    Random rdm = new Random();

    /// Randomizes the stonePile list.
    stonePile = stonePile.OrderBy(stone => rdm.Next()).ThenBy(stone => rdm.Next()).ThenBy(stone => rdm.Next()).ToList();
}

void DisplayShuffledStones()
{
    foreach (Stone stone in stonePile)
    {
        if (stone.Color == CustomEnums.Colors.Red)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (stone.Color == CustomEnums.Colors.White)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.Write(stone.Color);
        Console.Write(" ");
    }
}

void SortStonesUsingBubble()
{
    for (int currentStone = 0; currentStone < stonePile.Count; currentStone++)
    {
        for (int previousStone = currentStone - 1; previousStone < stonePile.Count; previousStone--)
        {
            if (previousStone >= 0)
            {
                if (stonePile[currentStone].Color == CustomEnums.Colors.Red && stonePile[previousStone].Color != CustomEnums.Colors.Red)
                {
                    stonePile.RemoveAt(currentStone);
                    stonePile.Insert(previousStone, new Stone(CustomEnums.Colors.Red));
                    currentStone--;
                }
            }
            else
            {
                break;
            }
        }
    }
}

void DisplaySortedStonesAsText()
{
    bool enterAdded = false;

    foreach (Stone stone in stonePile)
    {
        if (stone.Color == CustomEnums.Colors.Red)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(stone.Color);
            Console.Write(" ");
        }
        else
        {
            if (!enterAdded)
            {
                Console.WriteLine();
                enterAdded = true;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(stone.Color);
            Console.Write(" ");
        }
    }

    Console.WriteLine("\n \n");
}

void DisplaySortedStonesAsFlag()
{
    bool enterAdded = false;

    foreach (Stone stone in stonePile)
    {
        if (stone.Color == CustomEnums.Colors.Red)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"|\|/|");
            Console.Write(" ");
        }
        else
        {
            if (!enterAdded)
            {
                Console.WriteLine();
                enterAdded = true;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"|\|/|");
            Console.Write(" ");
        }
    }

    Console.WriteLine("\n \n");
}
#endregion