// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.
// Например, задан массив размером 2 x 2 x 2.
// Результат:
// 66(0,0,0) 27(0,0,1) 25(0,1,0) 90(0,1,1)
// 34(1,0,0) 26(1,0,1) 41(1,1,0) 55(1,1,1)

bool CheckUniqueElement(int[,,] matrix, int number)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int x = 0; x < matrix.GetLength(2); x++)
            {
                if (matrix[i, j, x] == number)
                {
                    return false;
                }
            }
        }
    }
    return true;
}


void FillmatrixNonrepeatingNumbers(int[,,] matrix, int minNumber, int maxNumber)
{
    Random random = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int x = 0; x < matrix.GetLength(2); x++)
            {
                while (matrix[i, j, x] == 0)
                {
                    int number = random.Next(minNumber, maxNumber);
                    if (CheckUniqueElement(matrix, number) == true)
                    {
                        matrix[i, j, x] = number;
                    }
                }
            }
        }
    }
}

void Printmatrix(int[,,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int depth =  matrix.GetLength(2);

    for (int x = 0; x < depth; x++)
    {
        for (int i = 0; i < rows; i ++)
        {
            for (int j = 0; j < columns; j ++)
            {
                Console.Write($"{matrix[i, j, x]} ({i},{j},{x})\t"); 
            }
            Console.WriteLine();
        }
    }
}

Console.Write("Введите количество строк массива: x=");
int x = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов массива: y=");
int y = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите глубину массива: z=");
int z = Convert.ToInt32(Console.ReadLine());


if (x * y * z > 90) 
    {
        Console.WriteLine("Массив слишком большой! Массив должен содержать не более 90 элементов!");
    }

if (x * y * z < 91)
{
    int[,,] massiv = new int[x, y, z];
    FillmatrixNonrepeatingNumbers(massiv, 10, 100); 
    Printmatrix(massiv);
}