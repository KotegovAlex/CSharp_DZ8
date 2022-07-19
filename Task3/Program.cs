/* Задача 3: Задайте две матрицы. Напишите программу, 
которая будет находить произведение двух матриц. */

int Promt(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine());
}

int[,] GenerateArray(int rows, int columns, int min, int max)
{
    int[,] array = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = rnd.Next(min, max + 1);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }

    }
    Console.WriteLine();
}

int[] RowELementsSum(int[,] array)
{
    int[] sum = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum[i] = sum[i] + array[i, j];
        }
    }
    return sum;
}

int MinSumElementsRow(int[] sum)
{
    int RowNumber = 0;
    int LeastSum = sum[0];
    for (int i = 0; i < sum.Length; i++)
    {
        if (sum[i] < LeastSum)
        {
            LeastSum = sum[i];
            RowNumber = i;
        }
    }
    return RowNumber;
}

void PrintLeastSumRow(int[,] array, int Row)
{

    for (int j = 0; j < array.GetLength(1); j++)
    {
        Console.Write($"{array[Row, j]}\t");
    }

    Console.WriteLine();
}

int[,] MatrixMultiplication(int[,] array1, int[,] array2)
{
    int[,] result = new int[array1.GetLength(0), array2.GetLength(1)];
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array1.GetLength(1); j++)
        {
            for (int k = 0; k < array2.GetLength(1); k++)
            {
                result[i,k] = result[i,k] + array1[i,j]*array2[j,k];
            }
        }
    }
   return result;
}

Console.WriteLine("Операция умножения двух матриц выполнима только в том случае, " +
                "если число столбцов в первом сомножителе равно числу строк во втором");

int rows1 = Promt("Введите количество строк первой матрицы: ");
int columns1 = Promt("Введите количество столбцов первой матрицы: ");
Console.WriteLine();

int rows2 = Promt("Введите количество строк второй матрицы: ");
int columns2 = Promt("Введите количество столбцов второй матрицы: ");
Console.WriteLine();

if(columns1 != rows2)
{
    Console.WriteLine("Невозможно произвести умножение двух матриц");
}
else
{
int[,] matrix1 = GenerateArray(rows1, columns1, 1, 10);
Console.Write("Матрица 1: ");
PrintArray(matrix1);
Console.WriteLine();

int[,] matrix2 = GenerateArray(rows2, columns2, 1, 10);
Console.Write("Матрица 2: ");
PrintArray(matrix2);
Console.WriteLine();

int[,] MultiplicationResult = MatrixMultiplication(matrix1, matrix2);
Console.Write("Результат произведения двух матриц: ");
PrintArray(MultiplicationResult);
}