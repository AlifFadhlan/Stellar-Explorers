using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControll : MonoBehaviour
{
    public Transform topOfJoystick;

    [SerializeField]
    private float forwardBacwardTilt = 0;
    [SerializeField]
    private float sideToSideTilt = 0;

    // Update is called once per frame
    void Update()
    {
        // move something using forwardBackwardTilt as speed
        forwardBacwardTilt = topOfJoystick.rotation.eulerAngles.x;
        if (forwardBacwardTilt < 355 && forwardBacwardTilt > 290)
        {
            forwardBacwardTilt = Mathf.Abs(forwardBacwardTilt - 360);
            Debug.Log("Backward: " + forwardBacwardTilt);
        }
        else if (forwardBacwardTilt > 5 && forwardBacwardTilt < 74)
        {
            Debug.Log("Forward: " + forwardBacwardTilt);
        }
        
        // turn something using sideToSideTilt as speed
        sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Mathf.Abs(sideToSideTilt - 360);
            Debug.Log("Right: " + sideToSideTilt);
        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            Debug.Log("Left: " + sideToSideTilt);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
