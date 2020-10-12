using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    float sightAngle, angularSpeed, rotationY, rotationX;
    CharacterController cController;
    // Start is called before the first frame update
    void Start()
    {
        cController = GetComponent<CharacterController>();
        sightAngle = 0f;
        angularSpeed = 0.001f;
        rotationY = 0f;
        rotationX = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //sightAngle += angularSpeed * Input.GetAxis("Mouse X")*Time.deltaTime;
        //transform.Rotate(new Vector3(0, sightAngle,0));//sets up the sight direction of player.

        rotationX -= Input.GetAxis("Mouse Y");
        rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        if(Input.GetButton("Vertical"))
        {
            float speed = 0f;
            if (Input.GetKey(KeyCode.W))
            {
                speed = 5f;
            }
            else speed = -5;
                
            Vector3 dir = transform.forward * speed*Time.deltaTime;
            //dir = transform.TransformDirection(dir);
            dir.y = 0;
            cController.Move(dir);
        }
    }
}
