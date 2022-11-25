// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void PrintMatrix(int[,] matrix)

{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],5} |");
            else Console.Write($"{matrix[i, j],5}");
        }
        Console.WriteLine(" |");
    }
}

void CreateMatrixHelix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (i == 0)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = j + 1;
            }
        }

        if (i == 3)
        {
            int temp = 1;
            for (int j = matrix.GetLength(1) - 1; j > -1; j--)
            {
                matrix[i, j] = i + j + temp;
                temp += 2;
            }
        }

        if (i == 1)
        {
            int temp = 12;
            for (int j = 1; j < matrix.GetLength(1) - 1; j++)
            {
                matrix[i, j] = j + temp;
            }
        }

        if (i == 2)
        {
            int temp = 9;
            for (int j = matrix.GetLength(1) - 1; j > 0; j--)
            {
                matrix[i, j] = i + j + temp;
                temp += 2;
            }
        }
    }

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (j == 3)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, j] = i + 4;
            }
        }

        if (j == 0)
        {
            int temp = 9;
            for (int i = 2; i > 0; i--)
            {
                matrix[i, j] = i + temp;
                temp += 2;
            }
        }
    }
}

int[,] array2DHelix = new int[4, 4];
CreateMatrixHelix(array2DHelix);
PrintMatrix(array2DHelix);