using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowStarship : MonoBehaviour
{

    public GameObject starship;
    public Vector3 offset = new Vector3(0, 0, 0);
     public float rotationSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position =
            starship.transform.position + offset;
        // transform.rotation = Quaternion.Lerp(transform.rotation, starship.transform.rotation, rotationSpeed * Time.deltaTime);
    }
}
