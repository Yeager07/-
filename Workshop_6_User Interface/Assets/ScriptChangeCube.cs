using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptChangeCube : MonoBehaviour
{
    private Rigidbody rb1;
    private Rigidbody rb2;
    private Rigidbody rb3;
    public GameObject win;
    public GameObject task;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = cube1.GetComponent<Rigidbody>();
        rb2 = cube2.GetComponent<Rigidbody>();
        rb3 = cube3.GetComponent<Rigidbody>();
    }

    public void Button1()
    {
        rb1.useGravity = false;
        rb2.useGravity = true;
        rb3.useGravity = true;
        win.SetActive(true);
        task.SetActive(false);
        cube1.GetComponent<Renderer>().material.color = Color.green;
        cube2.GetComponent<Renderer>().material.color = Color.red;
        cube3.GetComponent<Renderer>().material.color = Color.red;
    }

    public void Button2()
    {
        rb1.useGravity = true;
        rb2.useGravity = false;
        rb3.useGravity = true;
        win.SetActive(true);
        task.SetActive(false);
        cube1.GetComponent<Renderer>().material.color = Color.red;
        cube2.GetComponent<Renderer>().material.color = Color.green;
        cube3.GetComponent<Renderer>().material.color = Color.red;
    }

    public void Button3()
    {
        rb1.useGravity = true;
        rb2.useGravity = true;
        rb3.useGravity = false;
        win.SetActive(true);
        task.SetActive(false);
        cube1.GetComponent<Renderer>().material.color = Color.red;
        cube2.GetComponent<Renderer>().material.color = Color.red;
        cube3.GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
