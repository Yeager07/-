using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForRigitBody : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            _rb.isKinematic = true;
            _rb.mass= 100.0f;
            _rb.drag = 0;
            _rb.angularDrag = 0.05f;
            _rb.useGravity= false;
        };
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            _rb.isKinematic = false;
            _rb.mass= 1.0f;
            _rb.drag = 0;
            _rb.angularDrag = 0.05f;
            _rb.useGravity= true;
        };
    }

}
