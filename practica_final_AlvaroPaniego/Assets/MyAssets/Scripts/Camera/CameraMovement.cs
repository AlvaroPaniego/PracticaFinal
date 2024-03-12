using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform cam;
    public Vector3 inputVector;
    public Vector3 moveVector;
    public float speed;
    public float zoomSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        speed = 20;
        zoomSpeed = 550;
    }

    // Update is called once per frame
    void Update()
    {
        SetInputVector();
        SetMoveVector();
        Translation();
        if(Input.GetKey(KeyCode.Q)){
            transform.Rotate(0f, transform.rotation.y + 2.5f, 0f, Space.Self);
        }
        if(Input.GetKey(KeyCode.E)){
            transform.Rotate(0f, transform.rotation.y - 2.5f, 0f, Space.Self);
        }
        
        cam.Translate(cam.forward * zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel"), Space.World);
        
    }
    void SetInputVector(){
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.z = Input.GetAxisRaw("Vertical");
        inputVector = inputVector.normalized;
    }
    void SetMoveVector(){
        moveVector = inputVector.x * cam.right + inputVector.z * cam.forward;
        moveVector.y = 0; 
    }
    void Translation(){
        transform.Translate(moveVector * Time.deltaTime * speed, Space.World);
    }
}
