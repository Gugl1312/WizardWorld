using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform kamera;
    public Transform lookAt;
    public float speed;
    public float sensitivity;
    public float cameraRotationX;
    public float cameraRotationXl;
    public float cameraRotationY;
    public float cameraRotationYl;
    private Vector3 movement;
    public bool rotateX = true;
    public bool rotateY = true;
    private Rigidbody rb;
    public float jump;
    public Transform playerTrans;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {        
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * speed);
        cameraRotationX += Input.GetAxis("Mouse Y") * sensitivity;
        cameraRotationXl = Input.GetAxis("Mouse Y") * sensitivity;
        cameraRotationY += Input.GetAxis("Mouse X") * sensitivity;
        cameraRotationYl = Input.GetAxis("Mouse X") * sensitivity;
        this.transform.localEulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
        kamera.LookAt(this.transform.position);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jump;
        }
    }
    public void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        this.transform.localEulerAngles = new Vector3(cameraRotationX, cameraRotationY, 0);
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }
}
