// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

void PrintArray(int[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1) Console.Write($"{array[i]}, ");
        else Console.Write($"{array[i]}");
    }
    Console.WriteLine("]");
}

int[] FindSumOfRows(int[,] array) // метод для нахождения строки с наименьшей суммой элементов
{
    int[] result = new int[array.GetLength(0)]; // одномерный массив для сохранения результата
    
    for (int i = 0; i < array.GetLength(0); i++) // заполняем одномерный массив суммами каждой строки (один элемент одномерного массива = сумме элементов строки двумерного исходного массива)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                result[i] += array[i, j];
            }
        }
    return result;
}

int Result(int[] massiv)
{   //перебираем элементы нового одномерного массива для нахождения строки с минимальной суммой элементов
    int minSumm = massiv[0];
    int minNumberRow = 0;
    for (int i = 0; i < massiv.Length; i++)
    {
        if(massiv[i] < minSumm)
        {
            minSumm = massiv[i];
            minNumberRow = i;
        }
    }
    return minNumberRow;
}

Console.Write("Введите количество строк массива: m=");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов массива: n=");
int n = Convert.ToInt32(Console.ReadLine());

int[,] array2D = CreateMatrixRndInt(m, n, 1, 9);
PrintMatrix(array2D);
Console.WriteLine("");

PrintArray(FindSumOfRows(array2D));

int[] resultSumm = new int[m]; 
resultSumm = FindSumOfRows(array2D);
Console.WriteLine();
Console.WriteLine($"Номер строки с наименьшей суммой элементов: {Result(resultSumm) + 1}.");