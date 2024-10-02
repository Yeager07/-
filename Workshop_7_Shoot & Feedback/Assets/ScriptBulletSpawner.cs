using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    AudioSource bulletSound;
    public float BulletVelocity = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        bulletSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(BulletPrefab,
            transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletVelocity;
            newBullet.GetComponent<Rigidbody>().useGravity = true;
            bulletSound.Play();
        }
    }
}
