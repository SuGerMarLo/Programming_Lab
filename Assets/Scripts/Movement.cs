using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rb;
    public float _playerSpeed;
    public float _jump;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Jump();
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            checkJump();
        }
    }

    public void Moving()
    {
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(xinput, 0, zinput) * _playerSpeed;
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;

        Vector3 orientation = new Vector3(xinput, 0, zinput);
        if (orientation.magnitude > 0)
        {
            transform.forward = orientation;
        }
    }

    public void checkJump()
    {
        _rb.AddForce(Vector3.up * _jump, ForceMode.Impulse);
    }
}
