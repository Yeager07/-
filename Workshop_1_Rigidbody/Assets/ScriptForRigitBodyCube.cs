using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForRigitBodyCube : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)) 
        {
            //_rb.isKinematic = false;
            _rb.mass= 1.0f;
            _rb.drag = 0;
            _rb.angularDrag = 0;
            _rb.useGravity= true;
        };
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            //_rb.isKinematic = true;
            _rb.mass= 1.0f;
            _rb.drag = 2;
            _rb.angularDrag = 2;
            _rb.useGravity= false;
        };
    }

}
