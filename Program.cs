using System;

//Recursive implementation of fast exponentiation of a number
static long Recursive(long i, int j)
{
    if (j == 0)
    {
        return 1;
    }

    if (j % 2 == 0)
    {
        var p = Recursive(i, j / 2);
        return p * p;
    }
    else
    {
        return i * Recursive(i, j - 1);
    }
}

//Iterative implementation of fast exponentiation of a number
static long Iterative(long i, int j)
{
    var result = 1L;
    while (j > 0)
    {
        if ((j & 1) == 0)
        {
            i *= i;
            j >>= 1;
        }
        else
        {
            result *= i;
            --j;
        }
    }

    return result;
}

//Bubble Sort algorithm example
class BubbleSort
{

    class Program
    {
        //element exchange
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        //BubbleSort 
        static int[] BubbleSort(int[] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter array numbers: ");
            var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            var array = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = Convert.ToInt32(parts[i]);
            }

            Console.WriteLine("Sort array: {0}", string.Join(", ", BubbleSort(array)));

            Console.ReadLine();
        }
    }
}

//Shaker sort algorithm example
class Program1
{
    //element exchange
    static void Swap(ref int e1, ref int e2)
    {
        var temp = e1;
        e1 = e2;
        e2 = temp;
    }

    //Shaker sort
    static int[] ShakerSort(int[] array)
    {
        for (var i = 0; i < array.Length / 2; i++)
        {
            var swapFlag = false;
            for (var j = i; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                    swapFlag = true;
                }
            }

            for (var j = array.Length - 2 - i; j > i; j--)
            {
                if (array[j - 1] > array[j])
                {
                    Swap(ref array[j - 1], ref array[j]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
            {
                break;
            }
        }

        return array;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter array numbers: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Sort Array: {0}", string.Join(", ", ShakerSort(array)));

        Console.ReadLine();
    }
}

class Program2
{
    //subarray element evaluation evaluation method
    static int IndexOfMin(int[] array, int n)
    {
        int result = n;
        for (var i = n; i < array.Length; ++i)
        {
            if (array[i] < array[result])
            {
                result = i;
            }
        }

        return result;
    }

    //element exchange
    static void Swap(ref int x, ref int y)
    {
        var t = x;
        x = y;
        y = t;
    }

    //Selection sort
    static int[] SelectionSort(int[] array, int currentIndex = 0)
    {
        if (currentIndex == array.Length)
            return array;

        var index = IndexOfMin(array, currentIndex);
        if (index != currentIndex)
        {
            Swap(ref array[index], ref array[currentIndex]);
        }

        return SelectionSort(array, currentIndex + 1);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter array numbers: ");
        var s = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var a = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            a[i] = Convert.ToInt32(s[i]);
        }

        Console.WriteLine("Sort Array: {0}", string.Join(", ", SelectionSort(a)));
        Console.ReadLine();
    }
}

class Program3
{
    //Basic counting sort method
    static int[] BasicCountingSort(int[] array, int k)
    {
        var count = new int[k + 1];
        for (var i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }

        var index = 0;
        for (var i = 0; i < count.Length; i++)
        {
            for (var j = 0; j < count[i]; j++)
            {
                array[index] = i;
                index++;
            }
        }

        return array;
    }

    //method for getting an array filled with random numbers
    static int[] GetRandomArray(int arraySize, int minValue, int maxValue)
    {
        var random = new Random();
        var randomArray = new int[arraySize];
        for (var i = 0; i < randomArray.Length; i++)
        {
            randomArray[i] = random.Next(minValue, maxValue);
        }

        return randomArray;
    }

    static void Main(string[] args)
    {
        var arr = GetRandomArray(10, 0, 9);
        Console.WriteLine("Enter data: {0}", string.Join(", ", arr));
        Console.WriteLine("Sort array: {0}", string.Join(", ", BasicCountingSort(arr, 9)));
        Console.ReadLine();
    }
}
