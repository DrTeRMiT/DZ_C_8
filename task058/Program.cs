// Задача 58: Задайте две матрицы. 
// Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns]; // 0, 1
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

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

void CreatMatrixProduct(int[,] matrixA, int[,] matrixB)
{
    if (matrixA.GetLength(1) != matrixB.GetLength(0)) // проверям, возможно ли произведение матриц
    {
        Console.WriteLine("Произведение матриц невозможно! Число столбцов первой матрицы должно быть равно числу строк второй!");
    }

    int[,] matrixProduct = new int[matrixA.GetLength(0), matrixB.GetLength(1)]; // создаём массив для сохранения результата произведения матриц
    if (matrixA.GetLength(1) == matrixB.GetLength(0))
    {
        for (int i = 0; i < matrixA.GetLength(0); i++)
        {
            for (int j = 0; j < matrixB.GetLength(1); j++)
            {
                for (int x = 0; x < matrixA.GetLength(1); x++)
                {
                    matrixProduct[i, j] += matrixA[i, x] * matrixB[x, j];
                }
            }
        }
        Console.WriteLine("Результат произведения двух матриц: ");
        Console.WriteLine("");
        PrintMatrix(matrixProduct);
    }
}

Console.Write("Введите количество строк первого массива: m1=");
int m1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов первого массива: n1=");
int n1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("");

int[,] array2D1 = CreateMatrixRndInt(m1, n1, 1, 9);
PrintMatrix(array2D1);
Console.WriteLine("");

Console.Write("Введите количество строк второго массива: m2=");
int m2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов второго массива: n2=");
int n2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("");

int[,] array2D2 = CreateMatrixRndInt(m2, n2, 1, 9);
PrintMatrix(array2D2);
Console.WriteLine("");

CreatMatrixProduct(array2D1, array2D2);