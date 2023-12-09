using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/FinalShiny", GetComponent<Transform>().position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
