/* Задача 1: Задайте двумерный массив. Напишите программу, 
которая упорядочит по убыванию элементы каждой строки двумерного массива. */

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

int[,] SortRowNumbers(int[,] array)
{
    int temp = 0;
    int indexmax = 0;
    int m = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            indexmax = 0;
            for (int k = 0; k < array.GetLength(1) - j; k++)
            {
                if (array[i, k] > array[i, indexmax])
                {
                    indexmax = k;
                }
                m = k;
            }
            temp = array[i, indexmax];
            array[i, indexmax] = array[i, m];
            array[i, m] = temp;
        }
    }
    return array;
}

int rows = Promt("Введите количество строк: ");
int columns = Promt("Введите количество столбцов: ");

int[,] array1 = GenerateArray(rows, columns, 1, 100);
PrintArray(array1);
Console.WriteLine();

int[,] array2 = SortRowNumbers(array1);
PrintArray(array2);