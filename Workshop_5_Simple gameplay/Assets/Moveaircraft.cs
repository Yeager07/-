using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveaircraft : MonoBehaviour
{
    private Rigidbody Rigidbody;
    public float Speed = 5.0f; // Aircraft speed
    public float RotationSpeed = 1.0f; //Aircraft rotation
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * RotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * Speed;

        Rigidbody.AddRelativeForce(0f, 0f, forwardForce);
        Rigidbody.AddRelativeTorque(0f, sideForce, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
