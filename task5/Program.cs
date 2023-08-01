// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int rows = GetNum("Введите количество строк: ");
int colums = GetNum("Введите количество столбцов: ");
if (rows > 0 && colums > 0)
{
    int[,] arraySpiral = GetArraySpiral(rows, colums);
    PrintArray(arraySpiral);
}
else Console.WriteLine("Введена некорректная размерность массива.");

int GetNum(string message)
{
    Console.Write(message);
    int num = int.Parse(Console.ReadLine()!);
    return num;
}

int[,] GetArraySpiral(int rows, int colums)
{
    int[,] array = new int[rows, colums];
    int countFinishPosition = rows;
    if (rows > colums) countFinishPosition = colums;
    countFinishPosition = countFinishPosition / 2 + countFinishPosition % 2;
    int count = 0;
    int elValue = 0;
    while (count < countFinishPosition)
    {
        for (int j = count; j < colums - count; j++)
        {
            if (array[count, j] == 0) array[count, j] = ++elValue;
        }

        for (int i = count + 1; i <= rows - count - 2; i++)
        {
            if (array[i, colums - count - 1] == 0) array[i, colums - count - 1] = ++elValue;
        }

        for (int j = colums - count - 1; j >= count; j--)
        {
            if ( array[rows - count -1, j] == 0) array[rows - count -1, j] = ++elValue;
        }

        for (int i = rows - count -2; i >= count +1; i--)
        {
            if (array[i, count ] == 0) array[i, count ] = ++elValue;
        }
        count++;
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
