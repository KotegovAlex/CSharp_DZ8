/* Задача 2: Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов. */

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

int rows = Promt("Введите количество строк: ");
int columns = Promt("Введите количество столбцов: ");
Console.WriteLine();
int[,] array = GenerateArray(rows, columns, 1, 10);
Console.Write("Исходный двумерный массив: ");
PrintArray(array);
Console.WriteLine();

int RowNumber = MinSumElementsRow(RowELementsSum(array));
Console.WriteLine($"Строка с наименьшей суммой элементов под номером {RowNumber + 1}: ");
PrintLeastSumRow(array, RowNumber);