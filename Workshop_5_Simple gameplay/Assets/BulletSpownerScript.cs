using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpownerScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletVelocity = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(
                BulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletVelocity;
        }
    }
}
