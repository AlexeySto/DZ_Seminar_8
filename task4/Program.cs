// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
//  Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int lengthMatrix = GetNum("Введите длину трехмерного массива :");
int widthMatrix = GetNum("Введите ширину трехмерного массива :");
int heightMatrix = GetNum("Введите высоту трехмерного массива :");

if (lengthMatrix > 0 && widthMatrix > 0 && heightMatrix > 0 && lengthMatrix * heightMatrix * widthMatrix < 100)
{
    int[,,] array = GetArray(lengthMatrix, widthMatrix, heightMatrix);
    PrintArray(array);
}
else Console.WriteLine("Введена некорректная размерность массива.");

int GetNum(string message)
{
    Console.Write(message);
    int num = int.Parse(Console.ReadLine()!);
    return num;
}

int[,,] GetArray(int leng, int wid, int heig)
{
    int[,,] array = new int[leng, wid, heig];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                int temp = new Random().Next(10, 100);
                while (ElNotEqualPrevious(array, temp))
                    temp = new Random().Next(10, 100);
                array[i, j, k] = temp;
            }
        }
    }
    return array;
}

bool ElNotEqualPrevious(int[,,] inArray, int el)
{
    bool res = false;
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int k = 0; k < inArray.GetLength(2); k++)
            {
                if (inArray[i, j, k] == el) 
                {
                    res = true;
                }
            }
        }
    }
    return res;
}

void PrintArray(int[,,] arr)
{
    for (int k = 0; k < arr.GetLength(2); k++)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j, k]}({i},{j},{k}),");
            }
            Console.WriteLine("\b ");
        }
    }
}