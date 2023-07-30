// Задайте прямоугольный двумерный массив. Напишите
// программу, которая будет находить строку с наименьшей суммой элементов.

int rows = GetNum("Введите количество строк: ");
int colums = GetNum("Введите количество столбцов: ");
if (rows > 0 && colums > 0 && rows != colums)
{
    int[,] arrayRandom = GetArray(rows, colums);
    PrintArray(arrayRandom);
    Console.WriteLine($"Строка с наименьшей суммой элементов имеет индекс i = {GetIndexRowMinSumElement(arrayRandom)}.");
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

int GetIndexRowMinSumElement(int[,] matrix)
{
    int index = 0;
    int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[0,j];
        }
    int sumTemp = sum;
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i,j];
        }
        if (sumTemp > sum)
        {
            index = i;
            sumTemp = sum;
        } 
    }
    return index;
}
