// Вывести первые N строк треугольника Паскаля. Сделать вывод
// в виде равнобедренного треугольника

int rows = GetNum("Введите количество строк треугольника Паскаля N = ");
if (rows > 1)
{
    PrintTriangle(GetTrianglePaskale(rows));
}
else Console.WriteLine("Количество строк должно быть больше 1.");

int GetNum(string message)
{
    Console.Write(message);
    int num = int.Parse(Console.ReadLine()!);
    return num;
}

int[,] GetTrianglePaskale(int n)
{
    int[,] triangle = new int[n,n];
    for (int i = 0; i < triangle.GetLength(0); i++)
    {
        triangle[i,0] = 1;
    }
    triangle[1,1] = 1;
    for (int i = 2; i < triangle.GetLength(0); i++)
    {
        for (int j = 1; j < triangle.GetLength(1); j++)
        {
            triangle[i,j] = triangle[i - 1, j - 1] + triangle[i - 1, j];
        }
    }
    return triangle;
}

void PrintTriangle(int[,] array)
{
    string space = " ";
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int k = array.GetLength(0) - i; k > 0; k--)
        {
            Console.Write(space + space);
        }
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i,j] != 0) Console.Write(array[i,j] + space + space +space);
        }
        Console.WriteLine();
    }
}