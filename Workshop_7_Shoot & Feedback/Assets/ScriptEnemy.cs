using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptEnemy : MonoBehaviour
{
    public GameObject cubePiecePrefab;
    public AudioSource boomSound; //NEW
    public float explodeForce = 500.0f;
    [SerializeField] TextMeshProUGUI textScore;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            boomSound.Play(); //NEW
            ExplodeCube();
            AddScore();
        }
    }

    void Start()
    {
        textScore.text = "Score: " + ScriptProgress.Instance.PlayerInfo.Score.ToString();
    }

    public void AddScore()
    {
        ScriptProgress.Instance.PlayerInfo.Score += 10;
        textScore.text = "Score: " + ScriptProgress.Instance.PlayerInfo.Score.ToString();
        if(ScriptProgress.Instance.PlayerInfo.Score == 100)
        {
            SceneManager.LoadScene("Workshop_7_Shoot & Feedback");
        }
    }

    private void ExplodeCube()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Vector3 piecePosition = transform.position + new Vector3(x, y, z) * 0.5f;
                    GameObject piece = Instantiate(cubePiecePrefab, piecePosition, Quaternion.identity);
                    Rigidbody pieceRigidbody = piece.GetComponent<Rigidbody>();
                    pieceRigidbody.AddExplosionForce(explodeForce, transform.position, 5.0f);
                }
            }
        }

        Destroy(gameObject);
    }
}
