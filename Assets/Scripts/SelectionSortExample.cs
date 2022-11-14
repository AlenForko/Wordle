using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSortExample : MonoBehaviour
{
    public int[] ints;

    [ContextMenu("BubbleSort")]
    public void TestSort()
    {
        //SelectionSort(ints);
        BubbleSort(ints);
        //BogoSort(ints);
    }
    
    public void SelectionSort(int[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            int min = i;
            
            for (int j = i + 1; j < input.Length; j++)
            {
                if (input[j] < input[min])
                {
                    min = j;
                }
            }

            (input[i], input[min]) = (input[min], input[i]);
        }
        
    }

    public void BubbleSort(int[] input)
    {
        for (int i = 0; i < input.Length - 1; i++)
        {
            for (int j = 0; j < input.Length - i - 1; j++)
            {
                if (input[j] > input[j+1])
                {
                    (input[j], input[j + 1]) = (input[j + 1], input[j]);
                }
            }
        }
    }

    public void BogoSort(int[] input)
    {
        while (!IsSorted(ints))
            Shuffle(ints);
    }

    void Shuffle(int[] input)
    {
        int temp, rnd;

        System.Random random = new System.Random();

        for (int i = 0; i < input.Length; i++)
        {
            rnd = random.Next(input.Length);
            temp = input[i];
            input[i] = input[rnd];
            input[rnd] = temp;
        }
    }

    private static bool IsSorted(int[] input)
    {
        int count = input.Length;

        while (--count >= 1)
            if (input[count] < input[count - 1]) return false;

        return true;
    }
}
