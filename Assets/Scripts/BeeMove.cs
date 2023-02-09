using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMove : MonoBehaviour
{
    public float speed;
    public Vector3 offsetEndPos;
    Vector3 startPos;
    public Vector3 targetPos;


    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if(transform.position == targetPos)
        {
            if(targetPos == startPos)
            {
                targetPos = startPos + offsetEndPos;
            }
            else if (targetPos == startPos + offsetEndPos)
            {
                targetPos = startPos;
            }
        }
    }
}
