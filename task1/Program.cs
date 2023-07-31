// Задайте двумерный массив. Напишите программу, которая
// упорядочит по убыванию элементы каждой строки двумерного массива.

int rows = GetNum("Введите количество строк: ");
int colums = GetNum("Введите количество столбцов: ");
if (rows > 0 && colums > 0)
{
    int[,] arrayRandom = GetArray(rows, colums);
    PrintArray(arrayRandom);
    Console.WriteLine("Упорядочим строки:");
    PrintArray(GetSortRowsArray(arrayRandom));
}
else Console.WriteLine("Введена некорректная размерность массива.");

int GetNum(string message)
{
    Console.Write(message);
    int num = int.Parse(Console.ReadLine()!);
    return num;
}

int[,] GetArray(int rows, int colums)
{
    int[,] array = new int[rows, colums];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(0, 10);
        }
    }
    return array;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]},");
        }
        Console.WriteLine("\b|");
    }
}

int[,] GetSortRowsArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int k = matrix.GetLength(1) - 1; k > 0; k--)
        {
            for (int j = k; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j - 1] < matrix[i, j])
                {
                    int temp = matrix[i, j - 1];
                    matrix[i, j - 1] = matrix[i, j];
                    matrix[i, j] = temp;
                }
            }
        }

    }
    return matrix;
}