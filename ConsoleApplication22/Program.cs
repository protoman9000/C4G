using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApplication22
{
    class Program
    {
        enum rows
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3,
            E = 4,
            F = 5,
            G = 6
        };

        public static int oneInput(string player1)
        {
            string n = player1;
            rows input = (rows)Enum.Parse(typeof(rows), n);
            int x = (int)input;
            return x;
        }

        static void Main(string[] args)
        {
            int t = 6;
            int o = 7;
            
            Console.WriteLine("Starting Connect 4!!!!");
            string[,] newGrid = new string[t, o];
            
            t = 0;
            o = 0;
            int newTurn = 0;

            while (newTurn <= 5)
            {
                if (t < 6 && o < 7)
                {
                    newGrid[t, o] = "0";
                    o++;
                }
                else
                {
                    t++;
                    o = 0;
                    if (newTurn < 5)
                    {
                        newGrid[t, o] = "0";
                    }                  
                    newTurn++;
                }
            }
            
            int turn = 0;
            while (turn < 42)
            {

                Console.WriteLine("Player 1, Select a letter from A - G");
                string P1 = Console.ReadLine();
                int userInput = oneInput(P1);
                int yNumber = 5;
                while (newGrid[yNumber, userInput] != "0")
                {
                    yNumber--;
                }
                newGrid[yNumber, userInput] = "Red   ";

                //Display the grid
                int rowLength = newGrid.GetLength(0);
                int colLength = newGrid.GetLength(1);

                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.Write(string.Format("{0}", newGrid[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }

                //Check if R wins, horizontal
                int redColumn = 0;
                int redRow = 5;
                int redColumnLimit = 7;
                int redRowLimit = -1;
                int redCount = 5;
                string redWordCheck = null;
                string redWin = "Red   Red   Red   Red   ";
                
                for (int time = 0; time <= 147; time++)
                {
                    if (redRow > redRowLimit && redColumn < redColumnLimit)
                    {
                        redWordCheck += newGrid[redRow, redColumn];
                        redRow--;
                        if (redWordCheck == redWin)
                        {
                            Console.WriteLine("Red Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (redRow == redRowLimit)
                    {
                        redCount--;
                        redRow = redCount;
                        redWordCheck = null;
                    }
                    else if (redRow < redRowLimit && redColumn < redColumnLimit)
                    {
                        redRow = 5;
                        redColumn++;
                        redCount = 5;
                        redWordCheck = null;
                    }
                }

                //Check if R wins, vertical
                redColumn = 0;
                redRow = 5;
                redColumnLimit = 7;
                redRowLimit = 0;
                redCount = 0;
                redWordCheck = null;

                for (int time = 0; time < 168; time++)
                {
                    if (redColumn < redColumnLimit && redRow > redRowLimit)
                    {
                        redWordCheck += newGrid[redRow, redColumn];
                        redColumn++;
                        if (redWordCheck == redWin)
                        {
                            Console.WriteLine("Red Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (redColumn == redColumnLimit)
                    {
                        redCount++;
                        redColumn = redCount;
                        redWordCheck = null;
                    }
                    else if (redColumn > redColumnLimit && redRow > redRowLimit)
                    {
                        redRow--;
                        redColumn = 0;
                        redCount = 0;
                        redWordCheck = null;
                    }
                }

                //Check if R wins, diagonal =>
                redColumn = 0;
                redRow = 0;
                redColumnLimit = 7;
                redRowLimit = 6;
                redCount = 0;
                int redCount2 = 0;
                int tmp = 0;
                redWordCheck = null;

                for (int time = 0; time < 110; time++)
                {
                    if (redRow < redRowLimit && redColumn < redColumnLimit)
                    {
                        redWordCheck += newGrid[redRow, redColumn];
                        redRow++;
                        redColumn++;
                        if (redWordCheck == redWin)
                        {
                            Console.WriteLine("Red Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (redRow == redRowLimit)
                    {
                        redCount++;
                        redRow = redCount;
                        redColumn = redCount - tmp;
                        redWordCheck = null;
                    }
                    if (redCount == 7)
                    {
                        redCount = redCount2;
                        redRow = redCount;                        
                        redColumn = 0;
                        tmp++;
                        redCount2++;
                        redWordCheck = null;
                    }
                }

                //Check if R wins, diagonal <=
                redColumn = 6;
                redRow = 5;
                redColumnLimit = 0;
                redRowLimit = 0;
                redCount = 5;
                redCount2 = 5;
                tmp = 6;
                redWordCheck = null;

                for (int time = 0; time < 110; time++)
                {
                    if (redRow > redRowLimit && redColumn > redColumnLimit)
                    {
                        redWordCheck += newGrid[redRow, redColumn];
                        redRow--;
                        redColumn--;
                        if (redWordCheck == redWin)
                        {
                            Console.WriteLine("Red Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (redColumn == redColumnLimit)
                    {
                        redCount--;
                        redRow = redCount;
                        tmp--;
                        redColumn = tmp;
                        redWordCheck = null;
                    }
                    if (redCount == -1)
                    {
                        tmp = 6;
                        redColumn = tmp;
                        redCount2--;
                        redCount = redCount2;
                        redRow = redCount2;
                        redWordCheck = null;
                    }
                }

                //R wins, corner #2
                redColumn = 0;
                redRow = 5;
                redColumnLimit = 6;
                redRowLimit = 0;
                redCount = 5;
                redCount2 = 4;
                tmp = 0;
                redWordCheck = null;

                for (int time = 0; time < 110; time++)
                {
                    if (redRow >= redRowLimit && redColumn < redColumnLimit)
                    {
                        redWordCheck += newGrid[redRow, redColumn];
                        redRow--;
                        redColumn++;
                        if (redWordCheck == redWin)
                        {
                            Console.WriteLine("Red Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (redRow == redRowLimit)
                    {
                        redCount--;
                        redRow = redCount;
                        tmp++;
                        redColumn = tmp;
                        redWordCheck = null;
                    }
                    if (redCount == -1)
                    {
                        redCount = redCount2;
                        redRow = redCount;
                        redColumn = 0;
                        tmp = 0;
                        redCount2--;
                        redWordCheck = null;
                    }
                }

                //R wins, Corner #3
                redColumn = 6;
                redRow = 0;
                redColumnLimit = 0;
                redRowLimit = 6;
                redCount = 0;
                redCount2 = 1;
                tmp = 6;
                redWordCheck = null;

                for (int time = 0; time < 110; time++)
                {
                    if (redRow < redRowLimit && redColumn > redColumnLimit)
                    {
                        redWordCheck += newGrid[redRow, redColumn];
                        redRow++;
                        redColumn--;
                        if (redWordCheck == redWin)
                        {
                            Console.WriteLine("Red Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (redRow == redRowLimit)
                    {
                        redCount++;
                        redRow = redCount;
                        tmp--;
                        redColumn = tmp;
                        redWordCheck = null;
                    }
                    if (redCount == 6)
                    {
                        redCount = redCount2;
                        redRow = redCount;
                        redColumn = 6;
                        tmp = 6;
                        redCount2++;
                        redWordCheck = null;
                    }
                }


                //Player 2
                Console.WriteLine("Player 2, Select a letter from A - G");
                string P2 = Console.ReadLine();
                int userInput2 = oneInput(P2);
                int yNumber2 = 5;
                while (newGrid[yNumber2, userInput2] != "0")
                {
                    yNumber2--;
                }
                newGrid[yNumber2, userInput2] = "Black  ";

                //Display the grid
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.Write(string.Format("{0}", newGrid[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }

                //Check if B wins, horizontal
                int blackColumn = 0;
                int blackRow = 5;
                int blackColumnLimit = 7;
                int blackRowLimit = -1;
                int blackCount = 5;
                string blackWordCheck = null;
                string blackWin = "Black  Black  Black  Black  ";

                for (int time = 0; time <= 147; time++)
                {
                    if (blackRow > blackRowLimit && blackColumn < blackColumnLimit)
                    {
                        blackWordCheck += newGrid[blackRow, blackColumn];
                        blackRow--;
                        if (blackWordCheck == blackWin)
                        {
                            Console.WriteLine("Black Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (blackRow == blackRowLimit)
                    {
                        blackCount--;
                        blackRow = blackCount;
                        blackWordCheck = null;
                    }
                    else if (blackRow < blackRowLimit && blackColumn < blackColumnLimit)
                    {
                        blackRow = 5;
                        blackColumn++;
                        blackCount = 5;
                        blackWordCheck = null;
                    }
                }

                //Check if B wins, vertical
                blackColumn = 0;
                blackRow = 5;
                blackColumnLimit = 7;
                blackRowLimit = 0;
                blackCount = 0;
                blackWordCheck = null;

                for (int time = 0; time < 168; time++)
                {
                    if (blackColumn < blackColumnLimit && blackRow > blackRowLimit)
                    {
                        blackWordCheck += newGrid[blackRow, blackColumn];
                        blackColumn++;
                        if (blackWordCheck == blackWin)
                        {
                            Console.WriteLine("Black Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (blackColumn == blackColumnLimit)
                    {
                        blackCount++;
                        blackColumn = blackCount;
                        blackWordCheck = null;
                    }
                    else if (blackColumn > blackColumnLimit && blackRow > blackRowLimit)
                    {
                        blackRow--;
                        blackColumn = 0;
                        blackCount = 0;
                        blackWordCheck = null;
                    }
                }

                //Check if B wins, diagonal =>
                blackColumn = 0;
                blackRow = 0;
                blackColumnLimit = 7;
                blackRowLimit = 6;
                blackCount = 0;
                int blackCount2 = 0;
                tmp = 0;
                blackWordCheck = null;

                for (int time = 0; time < 110; time++)
                {
                    if (blackRow < blackRowLimit && blackColumn < blackColumnLimit)
                    {
                        blackWordCheck += newGrid[blackRow, blackColumn];
                        blackRow++;
                        blackColumn++;
                        if (blackWordCheck == blackWin)
                        {
                            Console.WriteLine("Black Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (blackRow == blackRowLimit)
                    {
                        blackCount++;
                        blackRow = blackCount;
                        blackColumn = blackCount - tmp;
                        blackWordCheck = null;
                    }
                    if (blackCount == 7)
                    {
                        blackCount = blackCount2;
                        blackRow = blackCount;
                        blackColumn = 0;
                        tmp++;
                        blackCount2++;
                        blackWordCheck = null;
                    }
                }

                //Check if B wins, diagonal <=
                blackColumn = 6;
                blackRow = 5;
                blackColumnLimit = 0;
                blackRowLimit = 0;
                blackCount = 5;
                blackCount2 = 5;
                tmp = 6;
                blackWordCheck = null;

                for (int time = 0; time < 110; time++)
                {
                    if (blackRow > blackRowLimit && blackColumn > blackColumnLimit)
                    {
                        blackWordCheck += newGrid[blackRow, blackColumn];
                        blackRow--;
                        blackColumn--;
                        if (blackWordCheck == blackWin)
                        {
                            Console.WriteLine("Black Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (blackColumn == blackColumnLimit)
                    {
                        blackCount--;
                        blackRow = blackCount;
                        tmp--;
                        blackColumn = tmp;
                        blackWordCheck = null;
                    }
                    if (blackCount == -1)
                    {
                        tmp = 6;
                        blackColumn = tmp;
                        blackCount2--;
                        blackCount = blackCount2;
                        blackRow = blackCount2;
                        blackWordCheck = null;
                    }
                }

                //R wins, corner #2
                blackColumn = 0;
                blackRow = 5;
                blackColumnLimit = 6;
                blackRowLimit = 0;
                blackCount = 5;
                blackCount2 = 4;
                tmp = 0;
                blackWordCheck = null;

                for (int time = 0; time < 110; time++)
                {
                    if (blackRow >= blackRowLimit && blackColumn < blackColumnLimit)
                    {
                        blackWordCheck += newGrid[blackRow, blackColumn];
                        blackRow--;
                        blackColumn++;
                        if (blackWordCheck == blackWin)
                        {
                            Console.WriteLine("Black Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (blackRow == blackRowLimit)
                    {
                        blackCount--;
                        blackRow = blackCount;
                        tmp++;
                        blackColumn = tmp;
                        blackWordCheck = null;
                    }
                    if (blackCount == -1)
                    {
                        blackCount = blackCount2;
                        blackRow = blackCount;
                        blackColumn = 0;
                        tmp = 0;
                        blackCount2--;
                        blackWordCheck = null;
                    }
                }

                //R wins, Corner #3
                blackColumn = 6;
                blackRow = 0;
                blackColumnLimit = 0;
                blackRowLimit = 6;
                blackCount = 0;
                blackCount2 = 1;
                tmp = 6;
                blackWordCheck = null;

                for (int time = 0; time < 110; time++)
                {
                    if (blackRow < blackRowLimit && blackColumn > blackColumnLimit)
                    {
                        blackWordCheck += newGrid[blackRow, blackColumn];
                        blackRow++;
                        blackColumn--;
                        if (blackWordCheck == blackWin)
                        {
                            Console.WriteLine("Black Wins!!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    if (blackRow == blackRowLimit)
                    {
                        blackCount++;
                        blackRow = blackCount;
                        tmp--;
                        blackColumn = tmp;
                        blackWordCheck = null;
                    }
                    if (blackCount == 6)
                    {
                        blackCount = blackCount2;
                        blackRow = blackCount;
                        blackColumn = 6;
                        tmp = 6;
                        blackCount2++;
                        blackWordCheck = null;
                    }
                }
                turn++;
            }
            //check method
            //method to declare winner 
            Console.WriteLine("Good Game");
            Console.ReadKey();

        }
       
    }
}
