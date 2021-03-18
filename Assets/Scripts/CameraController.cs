using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform farBackground, middleBackground;

    public float minHeight, maxHeight;

    private Vector2 lastPosition;


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;          // Set Camera initial position      // Convert to Vector2 (set x, y & chop off z)
    }

    // Update is called once per frame
    void Update()
    {
     /* transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);       // Camera target Player position
        float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);                           // Clamp Camera height to Min & Max values
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);             // Camera clamped Y values        */

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);    // Combine Above Lines


        Vector2 amountToMove = new Vector2(transform.position.x - lastPosition.x, transform.position.y - lastPosition.y);       // Calculate how far camera has moved                   //float amountToMoveX = transform.position.x - lastXPosition;   // Calculate how far camera has moved

        farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);               // Move far-background with Camera
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;      // Move mid-background with Camera

        lastPosition = transform.position;              // Update Camera last X position
    }
}
