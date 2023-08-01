// Задайтедвумерный массив из целых чисел. Напишите
// программу, которая удалит строку и столбец, на пересечении которых
// расположен наименьший элемент массива.

int rows = GetNum("Введите количество строк массива: ");
int colums = GetNum("Введите количество столбцов массива: ");
if (rows > 0 && colums > 0)
{
    int[,] arrayRandom = GetArray(rows, colums);
    PrintArray(arrayRandom);
    int[] minIndex = GetIndexMinElArray(arrayRandom);
    Console.WriteLine($"Наименьший элемент {arrayRandom[minIndex[0],minIndex[1]]}({minIndex[0]},{minIndex[1]}).");
    PrintArray(DeletRowAndColumIndex(arrayRandom, minIndex[0], minIndex[1]));
}
else Console.WriteLine("Введена некорректная размерность массива.");

int GetNum(string message)
{
    Console.Write(message);
    int num = Convert.ToInt32(Console.ReadLine()!);
    return num;
}

int[,] GetArray(int rows, int colums)
{
    int[,] array = new int[rows, colums];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(0, 100);
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

int[] GetIndexMinElArray(int[,] matrix)
{
    int[] res = new int[2];
    int temp = matrix[0,0];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[i,j] < temp)
            {
                res[0] = i;
                res[1] = j;
                temp = matrix[i,j];
            }
        }
    }
    return res;
}

int[,] DeletRowAndColumIndex(int[,] array, int indexI, int indexJ)
{
    int[,] result = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    int[,] temp1 = new int[array.GetLength(0), array.GetLength(1)];
    int[,] temp2 = new int[array.GetLength(0), array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < indexJ; j++)
        {
            temp1[i,j] = array[i,j];
        }

        for (int j = indexJ + 1; j < array.GetLength(1); j++)
        {
            temp1[i,j - 1] = array[i,j];
        }
    }
    for (int j = 0 ; j < array.GetLength(1); j++)
    {
        for (int i = 0; i < indexI; i++)
        {
            temp2[i,j] = temp1[i,j];
        }

        for (int i = indexI + 1; i < array.GetLength(0); i++)
        {
            temp2[i - 1,j] = temp1[i,j];
        }
    }
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i,j] = temp2[i,j];
        }
    }
    return result;
}