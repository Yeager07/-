using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider colliderCube1;
    public Collider colliderCube2;
    void Start()
    {
        Physics.IgnoreCollision(colliderCube1, colliderCube2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
