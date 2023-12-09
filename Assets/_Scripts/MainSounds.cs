using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ambiance/Music", GetComponent<Transform>().position);
    }

    // Update is called once per frame
    void Update()
    {
        Sounds();
    }

    public void Sounds()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/EnemyDamage", GetComponent<Transform>().position);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/PlayerDamage", GetComponent<Transform>().position);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Pickup", GetComponent<Transform>().position);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CartoonJump", GetComponent<Transform>().position);
        }
    }
}
