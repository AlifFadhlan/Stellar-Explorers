using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesawatControl : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    [SerializeField] float rollSpeed;
    [SerializeField] float pitchFactor;

    [SerializeField] float xBound;
    [SerializeField] float yBound;

    float horizontalInput;
    float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float xDelta = Time.deltaTime * horizontalInput * movementSpeed;
        float yDelta = Time.deltaTime * verticalInput * movementSpeed;

        float xPos = transform.position.x + xDelta;
        float yPos = transform.position.y + yDelta;

        xPos = Mathf.Clamp(xPos, -xBound, xBound);
        yPos = Mathf.Clamp(yPos, -yBound, yBound);

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }

    void RotatePlayer()
    {
        float roll = rollSpeed * horizontalInput;
        float pitch = pitchFactor * verticalInput;
        transform.rotation = Quaternion.Euler(pitch, transform.rotation.y, roll);
    }
}
