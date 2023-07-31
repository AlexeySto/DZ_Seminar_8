// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int rowsMatrix1 = GetNum("Введите количество строк исходной матрицы :");
int columsMatrix1 = GetNum("Введите количество столбцов исходной матрицы :");

if (rowsMatrix1 > 0 && columsMatrix1 > 0)
{
    int rowsMatrix2 = columsMatrix1;
    int columsMatrix2 = rowsMatrix1;

    Console.WriteLine("Введите исходную матрицу:");
    int[,] matrix1 = GetMatrix(rowsMatrix1, columsMatrix1);
    Console.WriteLine("Введите матрицу на которую будем перемножать :");
    int[,] matrix2 = GetMatrix(rowsMatrix2, columsMatrix2);
    
    Console.Clear();
    PrintMatrix(matrix1);
    Console.WriteLine("   *");
    PrintMatrix(matrix2);
    Console.WriteLine("   =");
    PrintMatrix(GetMatrixMultiplication(matrix1, matrix2));
}
else Console.WriteLine("Введена некоректная размерность матрицы.");

int GetNum(string message)
{
    Console.Write(message);
    int num = int.Parse(Console.ReadLine()!);
    return num;
}

int[,] GetMatrix(int rows, int colums)
{
    int[,] matrix = new int[rows, colums];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = GetNum($"Элемент матрицы [{i},{j}] = ");
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
            Console.Write($"{matrix[i,j]},");
        }
        Console.WriteLine("\b|");
    }
}

int[,] GetMatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    int[,] res = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                sum += matrix1[i,k] * matrix2[k,j];
            }
            res[i,j] = sum;
        }
    }
    return res;
}