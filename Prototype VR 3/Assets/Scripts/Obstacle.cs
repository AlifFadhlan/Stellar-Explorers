using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody obstacleRb;
    private float speed;
    private GameObject alas;
    private SpawnManager spawnManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        obstacleRb = GetComponent<Rigidbody>();
        alas = GameObject.Find("Alas Satu");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (alas.transform.position - transform.position);
        obstacleRb.AddForce(lookDirection * speed * Time.deltaTime);
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        speed = spawnManagerScript.enemySpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Alas Satu")
        {
            Destroy(gameObject);
        }
    }
}
