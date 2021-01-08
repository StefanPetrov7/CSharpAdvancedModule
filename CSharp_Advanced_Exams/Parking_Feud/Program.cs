using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Feud
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parkingSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> driverStarts = new List<int>() { int.Parse(Console.ReadLine()) };
            string[,] parking = new string[parkingSize[0] + parkingSize[0] - 1, parkingSize[1] + 2];
            Stack<string> parkingAttempts = new Stack<string>();

            int parkingRows = 1;
            string letters = "ABCDEFGHIJ";
            for (int r = 0; r < parking.GetLength(0); r++)
            {
                for (int c = 1; c < parking.GetLength(1) - 1; c++)
                {
                    if (r % 2 != 0) break;

                    parking[r, c] = letters[c - 1].ToString();
                    parking[r, c] += parkingRows.ToString();

                }
                parkingRows = r % 2 == 0 ? parkingRows += 1 : parkingRows;
            }

            string input = Console.ReadLine();
            bool IsParkSuccesfully = false;
            int finalCounter = 0;

            while (!IsParkSuccesfully)
            {
                bool finalDestinationFound = false;
                List<string> parkingSpots = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string parkingNumber = parkingSpots[driverStarts[0] - 1];
                parkingSpots.RemoveAt(driverStarts[0] - 1);
                parkingSpots.Insert(driverStarts[0] - 1, "replaced");

                int secondDriverStart = 0;
                if (parkingSpots.Contains(parkingNumber))
                {
                    secondDriverStart = parkingSpots.FindIndex(x => x == parkingNumber);
                    driverStarts.Add(secondDriverStart + 1);
                }


                int parkRow = 0;
                int parkCol = 0;
                int finishRow = 0;

                for (int r = 0; r < parking.GetLength(0); r++)
                {
                    for (int c = 0; c < parking.GetLength(1); c++)
                    {
                        if (r % 2 != 0) break;

                        if (parking[r, c] == parkingNumber)
                        {
                            parkRow = r;
                            parkCol = c;
                            finalDestinationFound = true;
                            break;
                        }
                    }
                    if (finalDestinationFound) break;
                }


                int[] bestDistance = new int[driverStarts.Count];

                for (int i = 0; i < driverStarts.Count; i++)
                {
                    int row = driverStarts[i] + driverStarts[i] - 1;
                    int col = 0;

                    if (row > parkRow)
                    {
                        finishRow = parkRow + 1;
                        parking[finishRow, parkCol] = "finish";
                    }
                    else
                    {
                        finishRow = parkRow - 1;
                        parking[finishRow, parkCol] = "finish";
                    }

                    int counter = 0;
                    string direction = "right";
                    bool parkingReached = false;
                    Stack<string> directions = new Stack<string>();

                    while (parkingReached == false)
                    {
                        if (direction == "right" && col <= parking.GetLength(1) - 1)
                        {
                            col++;
                            counter++;
                            if (col > parking.GetLength(1) - 1)
                            {
                                col--;
                                direction = row < parkRow ? "down" : "up";
                                directions.Push("left");
                            }
                            if (parking[row, col] == parking[finishRow, parkCol])
                            {
                                parkingReached = true;
                                break;
                            }
                            continue;
                        }

                        if (direction == "down")
                        {
                            row += 2;
                            counter++;
                            direction = directions.Pop();
                            continue;
                        }

                        if (direction == "up")
                        {
                            row -= 2;
                            counter++;
                            direction = directions.Pop();
                            continue;
                        }

                        if (direction == "left" && col >= 0)
                        {
                            col--;
                            counter++;

                            if (col < 0)
                            {
                                direction = row < parkRow ? "down" : "up";
                                col++;
                                directions.Push("right");
                            }

                            if (parking[row, col] == parking[finishRow, parkCol])
                            {
                                parkingReached = true;
                                break;
                            }
                            continue;
                        }
                    }

                    bestDistance[i] = counter;
                }

                if (bestDistance.Length > 1)
                {
                    driverStarts.RemoveAt(1);
                    if (bestDistance[0] <= bestDistance[1])
                    {
                        IsParkSuccesfully = true;
                        finalCounter += bestDistance[0];
                    }
                    else
                    {
                        finalCounter += bestDistance[0] * 2;
                        IsParkSuccesfully = false;
                    }
                }
                else if (bestDistance.Length == 1)
                {
                    finalCounter += bestDistance[0];
                    IsParkSuccesfully = true;
                }

                parking[finishRow, parkCol] = "";
                parkingAttempts.Push(parkingNumber);

                if (IsParkSuccesfully) break;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Parked successfully at {parkingAttempts.Pop()}.");
            Console.WriteLine($"Total Distance Passed: {finalCounter}");

        }
    }
}
