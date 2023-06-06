using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadixSortOptimizedWithVisualizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lastSorted = new int[10]; // array from 0 - 9

            int toInsertValue = 0;
            int toInsertLSD = 0;

            int baseNum = 1;

            bool sorted = false;

            int charToDisplay = 0;
            string temp = "";
            int tempVal = 0;

            int[] visualizerSize = { 29, 120 }; // rows and columns of console
            Random rnd = new Random(); 
            int[] arr = new int[visualizerSize[1]];
            int[] LSD = new int[arr.Length];
            int[] newDispl = new int[visualizerSize[1]];
            int[] curDispl = new int[visualizerSize[1]];
            /*
             * Possible colors:
             * 0 : Reset Color
             * 1 : Blue
             * 2 : Red
             * 3 : Green
             * 4 : Cyan
             * 5 : Dark Blue
             * 6 : Foreground Red
             */

            for (int x = 0; x < arr.Length; x++)
                arr[x] = rnd.Next(visualizerSize[0]) + 1;

            // this line just sets the window size to always display in a 
            // 120 * 30 characters in size
            Console.SetWindowSize(visualizerSize[1], visualizerSize[0] + 1);

            #region Visualizing initial display
            for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
            {
                for (int b = 0; b < arr.Length; b++) // dictate number of columns
                {
                    if (arr[b] >= a)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
            }
            Console.Write("To be sorted using Radix (Optimized) sort... Press any key to begin...");
            Console.ReadKey();
            //Console.Clear(); 
            #endregion

            while (!sorted)
            {
                sorted = true;

                // reset lastSorted array
                for (int a = 0; a < lastSorted.Length; a++)
                    lastSorted[a] = 0;

                for (int x = 0; x < arr.Length; x++)
                {
                    LSD[x] = arr[x] / baseNum % 10;
                    if (LSD[x] > 0)
                        sorted = false;
                }

                if (sorted)
                    break;

                for (int x = 0; x < LSD.Length; x++)
                {
                    // display

                    newDispl[x] = 4;
                    #region Highlighting cell to be checked
                    for (int a = 0; a < arr.Length; a++)
                    //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = visualizerSize[0]; b > 0; b--)
                        //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                        {
                            if (newDispl[a] != curDispl[a])
                            {
                                Console.SetCursorPosition(a, b - 1);
                                switch (newDispl[a])
                                {
                                    case 0:
                                        Console.ResetColor();
                                        break;
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                    case 4:
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        break;
                                    case 5:
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        break;
                                    case 6:
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        break;
                                }

                                if (arr[a] > visualizerSize[0] - b)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }

                        curDispl[a] = newDispl[a];
                        newDispl[a] = 0;
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Base {0} : Number to be moved {1} LSD {2}. . .                              "
                        , baseNum, arr[x], LSD[x]);
                    //Console.ReadKey();
                    //Thread.Sleep(200);
                    //Console.Clear(); 
                    #endregion

                    toInsertValue = arr[x];
                    toInsertLSD = LSD[x];
                    arr[x] = -1;

                    // display
                    newDispl[x] = 6;
                    #region Removing Value from current position
                    for (int a = 0; a < arr.Length; a++)
                    //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = visualizerSize[0]; b > 0; b--)
                        //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                        {
                            if (newDispl[a] != curDispl[a])
                            {
                                Console.SetCursorPosition(a, b - 1);
                                switch (newDispl[a])
                                {
                                    case 0:
                                        Console.ResetColor();
                                        break;
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                    case 4:
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        break;
                                    case 5:
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        break;
                                    case 6:
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        break;
                                }

                                if (arr[a] > visualizerSize[0] - b)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }

                        curDispl[a] = newDispl[a];
                        newDispl[a] = 0;
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Base {0} : Removing value {1} to move to index {2}. . .                     "
                        , baseNum, toInsertValue, lastSorted[LSD[x]]);
                    //Console.ReadKey();
                    //Thread.Sleep(200);
                    //Console.Clear(); 
                    #endregion

                    for (int y = x - 1; y >= lastSorted[LSD[x]]; y--)
                    {
                        arr[y + 1] = arr[y];
                        arr[y] = -1;

                        // display
                        newDispl[y] = 6;
                        newDispl[y + 1] = 6;
                        #region Moving values around
                        for (int a = 0; a < arr.Length; a++)
                        //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                        {
                            for (int b = visualizerSize[0]; b > 0; b--)
                            //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                            {
                                if (newDispl[a] != curDispl[a])
                                {
                                    Console.SetCursorPosition(a, b - 1);
                                    switch (newDispl[a])
                                    {
                                        case 0:
                                            Console.ResetColor();
                                            break;
                                        case 1:
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            break;
                                        case 2:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        case 4:
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            break;
                                        case 5:
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            break;
                                        case 6:
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            break;
                                    }

                                    if (arr[a] > visualizerSize[0] - b)
                                        Console.Write("*");
                                    else
                                        Console.Write(" ");
                                }
                            }

                            curDispl[a] = newDispl[a];
                            newDispl[a] = 0;
                        }
                        Console.SetCursorPosition(0, 29);
                        Console.Write("Base {0} : Moving values around. . .                                        "
                            , baseNum);
                        //Console.ReadKey();
                        //Thread.Sleep(200);
                        //Console.Clear(); 
                        #endregion
                    }

                    arr[lastSorted[LSD[x]]] = toInsertValue;
                    LSD[lastSorted[LSD[x]]] = toInsertLSD;

                    // display
                    #region Inserting value into correct location
                    for (int a = 0; a < arr.Length; a++)
                    //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = visualizerSize[0]; b > 0; b--)
                        //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                        {
                            if (newDispl[a] != curDispl[a])
                            {
                                Console.SetCursorPosition(a, b - 1);
                                switch (newDispl[a])
                                {
                                    case 0:
                                        Console.ResetColor();
                                        break;
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                    case 4:
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        break;
                                    case 5:
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        break;
                                    case 6:
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        break;
                                }

                                if (arr[a] > visualizerSize[0] - b)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }

                        curDispl[a] = newDispl[a];
                        newDispl[a] = 0;
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Base {0} : Value is now in its correct location. . .                        "
                        , baseNum);
                    //Console.ReadKey();
                    //Thread.Sleep(200);
                    //Console.Clear(); 
                    #endregion

                    for (int y = toInsertLSD; y < lastSorted.Length; y++)
                        lastSorted[y]++;
                }

                // display

                // just to display all bucket ares
                for (int i = 0; i < lastSorted.Length; i++)
                    if(lastSorted[i] < newDispl.Length)
                        newDispl[lastSorted[i]] = 3;
                #region Completion of base number
                for (int a = 0; a < arr.Length; a++)
                //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                {
                    for (int b = visualizerSize[0]; b > 0; b--)
                    //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                    {
                        if (newDispl[a] != curDispl[a])
                        {
                            Console.SetCursorPosition(a, b - 1);
                            switch (newDispl[a])
                            {
                                case 0:
                                    Console.ResetColor();
                                    break;
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    break;
                                case 6:
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    break;
                            }

                            if (arr[a] > visualizerSize[0] - b)
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                    }

                    curDispl[a] = newDispl[a];
                    newDispl[a] = 0;
                }
                Console.SetCursorPosition(0, 29);
                Console.Write("Base {0} : Completed!                                                       "
                    , baseNum);
                //Console.ReadKey();
                //Thread.Sleep(200);
                //Console.Clear(); 
                #endregion

                baseNum *= 10;
                charToDisplay++;
            }

            Console.SetCursorPosition(0, 29);
            Console.Write("Done!!!!!!!!!                                              ");
            Console.ReadKey();
        }
    }
}
