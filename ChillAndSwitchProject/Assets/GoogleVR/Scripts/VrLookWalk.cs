using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrLookWalk : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 2.0f;
    public bool moveForward;

    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();   
    }

    void Update()
    {
        moveForward = vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f;
        Debug.Log(vrCamera.eulerAngles.x);

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            float acceleration = (vrCamera.eulerAngles.x - toggleAngle) / 10;
            cc.SimpleMove(forward * speed * acceleration);
        }

    }
}
