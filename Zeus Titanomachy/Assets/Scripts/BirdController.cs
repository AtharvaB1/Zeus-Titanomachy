using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float FlySpeed = 5;
    public float YawAmount = 1;
    public float PitchAmount = 1;
    public float xVelocity, yVelocity, 
                    zVelocity = 1;


    private float Yaw;
    private float Pitch;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xVelocity, yVelocity, zVelocity) * FlySpeed * Time.deltaTime;


        xVelocity += Input.GetAxis("Horizontal");
        yVelocity += Input.GetAxis("Vertical");
        zVelocity = 1;

        xVelocity /= 2;
        yVelocity /= 2;
        
        //yaw, pitch, roll
        Yaw += xVelocity * YawAmount * Time.deltaTime;
        Pitch += yVelocity * PitchAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 50, Mathf.Abs(yVelocity)) * Mathf.Sign(xVelocity);
        float roll = Mathf.Lerp(0, 70, Mathf.Abs(yVelocity)) * -Mathf.Sign(xVelocity);

        //apply rotation.
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);
        transform.localRotation = Quaternion.Euler(Vector3.right * Pitch + Vector3.left * pitch + Vector3.forward * roll);

    }
    

}