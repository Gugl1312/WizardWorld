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
        //Debug.Log(rb.constraints);
    }
    void FixedUpdate()
    {        
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * speed);
        cameraRotationX += -Input.GetAxis("Mouse Y") * sensitivity;
        cameraRotationXl = -Input.GetAxis("Mouse Y") * sensitivity;
        cameraRotationY += Input.GetAxis("Mouse X") * sensitivity;
        cameraRotationYl = Input.GetAxis("Mouse X") * sensitivity;
        //cameraRotationX = Mathf.Clamp(cameraRotationX, -45f, 45f);
        //cameraRotationY = Mathf.Clamp(cameraRotationY, -45f, 45f);
        //cameraRotation += new Vector3(-Input.GetAxis("Mouse Y") * sensitivity, Input.GetAxis("Mouse X") * sensitivity, 0);
        //kamera.localEulerAngles = new Vector3(cameraRotationX, cameraRotationY, 0);
        this.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        this.transform.localEulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
        //Debug.Log("X rotation: " + cameraRotationX);
        //Debug.Log("Y rotation: " + cameraRotationY);
        //Debug.Log(cameraRotationX);
        //Debug.Log(cameraRotationY);
        //kamera.RotateAround(lookAt.transform.position, Vector3.up, cameraRotationYl);
        kamera.LookAt(lookAt);        
        //Debug.Log(transform.rotation.eulerAngles.y);
        kamera.RotateAround(lookAt.transform.position, Vector3.right, -cameraRotationXl);
        kamera.LookAt(lookAt);        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jump;
            Debug.Log(rb.velocity);
        }
        Debug.Log(rb.velocity);
        //kamera.rotation.y = playerTrans.rotation.y;
        Debug.Log("Roation player: " + playerTrans.rotation);
        //cameraRotationX = cameraRotationXl;
        //cameraRotationY = cameraRotationYl;
    }
    public void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        this.transform.localEulerAngles = new Vector3(0, cameraRotationY, 0);
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }
}
