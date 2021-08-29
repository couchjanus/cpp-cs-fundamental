using System;

namespace cs
{
using System;

namespace cs
{

// Применение нескольких параметров

// индексатор может принимать несколько параметров. 
// у нас есть класс, в котором хранилище определено в виде двухмерного массива или матрицы:

class Matrix
{
    private int[,] numbers = new int[,] { { 1, 2, 4}, { 2, 3, 6 }, { 3, 4, 8 } };
    
    // для определения индексатора используются два индекса - i и j. 
    public int this[int i, int j]
    {
        get
        {
            return numbers[i,j];
        }
        set
        {
            numbers[i, j] = value;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        // в программе мы должны обращаться к объекту, используя два индекса:
        Matrix matrix = new Matrix();
        Console.WriteLine(matrix[0, 0]);
        matrix[0, 0] = 111;
        Console.WriteLine(matrix[0, 0]);

    }
}
}

}
