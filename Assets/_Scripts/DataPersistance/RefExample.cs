using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefExample : MonoBehaviour
{
    int a = 10;
    int b = 20;

    // Start is called before the first frame update
    void Start()
    {
        //From my understanding, a ref allows the user to change the used variable in a non void method
        AddValue(a);
        SubtractValue(ref b);

        Debug.Log(a);
        Debug.Log(b);
    }

    void AddValue(int arg)
    {
        arg += 1;
    }

    void SubtractValue(ref int b)
    {
        b -= 15;
    }
}
