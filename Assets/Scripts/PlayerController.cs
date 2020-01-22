using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float turningSpeed;

    private Rigidbody rb;
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Rotate(Vector3.up, moveHorizontal);

        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f;

        rb.AddForce(movement * playerSpeed);
    }
}
