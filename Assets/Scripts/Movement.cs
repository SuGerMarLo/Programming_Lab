using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody _rb;
    public float _playerSpeed = 10f;
    public Transform _transform;
    public Vector3 _rotation;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        _rotation = transform.rotation.eulerAngles.normalized;
        Moving();
    }

    public void Moving()
    {
        Vector3 movementDir = new Vector3();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movementDir += new Vector3(0f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movementDir += new Vector3(0f, 0f, -1f);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movementDir += new Vector3(-1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movementDir += new Vector3(1f, 0f, 0f);
        }

        _rb.velocity = movementDir * (_playerSpeed);
    }
}
