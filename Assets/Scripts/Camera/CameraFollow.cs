using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing = 5f;

    private Vector3 offset;

    private void Start()
    {
        //calculating the initioal offset
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        //makes a position for the camera to follow based on the offset
        Vector3 targetPosition = target.position + offset;

        //make the transition of the camera from one position to another smooth
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing*Time.deltaTime);
    }

}
