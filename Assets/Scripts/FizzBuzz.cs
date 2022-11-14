using UnityEngine;

public class FizzBuzz : MonoBehaviour
{
    private int n = 100;

    private void Start()
    {
        for (int i = 1; i < n; i++)
        {  
            if (i % 3 == 0 && i % 5 == 0)
            {
                Debug.Log("Fizz Buzz");
            }
            else if (i % 3 == 0)
            {
                Debug.Log("Fizz");
            }
            else if (i % 5 == 0)
            {
                Debug.Log("Buzz");
            }
            else
            {
                Debug.Log(i);
            }
        }
    }
}
