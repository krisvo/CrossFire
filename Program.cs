using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossFire
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var matrix = new List<List<int>>();
            FillMatrix(size, matrix);

            var command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                var splitCommand = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var row = splitCommand[0];
                var col = splitCommand[1];
                var radius = splitCommand[2];

                for (int rowIndex = row - radius; rowIndex <= row + radius; rowIndex++)
                {
                    if (IsInRange(rowIndex, col, matrix))
                    {
                        matrix[rowIndex][col] = -1;
                    }
                }


                for (int colIndex = col - radius; colIndex <= col + radius; colIndex++)
                {

                    if (IsInRange(row, colIndex, matrix))
                    {
                        matrix[row][colIndex] = -1;
                    }
                }

                RemoveElements(matrix);

                command = Console.ReadLine();
            }

            foreach (var rows in matrix)
            {
                Console.WriteLine(string.Join(" ", rows));
            }

        }

        private static void FillMatrix(int[] size, List<List<int>> matrix)
        {
            int count = 1;
            for (int rowIndex = 0; rowIndex < size[0]; rowIndex++)
            {
                matrix.Add(new List<int>());
                for (int colIndex = 0; colIndex < size[1]; colIndex++)
                {
                    matrix[rowIndex].Add(count);
                    count++;
                }
            }
        }

    

        private static bool IsInRange(int currentRow, int currentCol, List<List<int>> matrix)
        { 
            if(currentRow >= 0 && currentRow < matrix.Count && currentCol >= 0 && currentCol < matrix[currentRow].Count)
            {
                return true;
            }
            return false;
        }

        private static void RemoveElements(List<List<int>> matrix)
        {
            for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = matrix[rowIndex].Count - 1; colIndex >= 0; colIndex--)
                {
                    if (matrix[rowIndex][colIndex] == -1)
                    {
                        matrix[rowIndex].RemoveAt(colIndex);
                    }
                    
                }
                    if (matrix[rowIndex].Count == 0)
                    {
                        matrix.RemoveAt(rowIndex);
                    }
            }
        }
    }
}
