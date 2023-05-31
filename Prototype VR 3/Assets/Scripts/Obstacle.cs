using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody obstacleRb;
    private GameObject alas;
    // Start is called before the first frame update
    void Start()
    {
        obstacleRb = GetComponent<Rigidbody>();
        alas = GameObject.Find("Alas Satu");
    }

    // Update is called once per frame
    void Update()
    {
        
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
