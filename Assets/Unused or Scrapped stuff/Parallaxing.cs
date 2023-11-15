using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public float parallaxSpeed;
    Transform cam;
    Vector3 prevCamPosition;
    void Awake()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Start()
    {
        prevCamPosition = cam.position;
    }
    void Update()
    {
        float camMovementThisFrame = prevCamPosition.x - cam.position.x;
        float movementInX = camMovementThisFrame * parallaxSpeed;
        Vector3 newPosition = new Vector3(movementInX, this.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, newPosition, 1);
    }
}
