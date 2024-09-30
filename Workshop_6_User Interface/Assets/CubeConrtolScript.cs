using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeConrtolScript : MonoBehaviour
{
    private Rigidbody _rb;
    public GameObject _go;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void StartButton()
    {
        _rb.useGravity = true;
        _go.SetActive(true);
    }

    public void StopButton()
    {
        _rb.useGravity = false;
    }

    public void ChangeColorButton()
    {
        _rb.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
    void Update()
    {
        
    }
}
