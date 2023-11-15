using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    GameObject player;
    public float yOffset = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 cameraPos = this.transform.position;
        cameraPos.x = playerPos.x;
        cameraPos.y = playerPos.y + yOffset;
        player.transform.position = playerPos;
        this.transform.position = cameraPos;
    }
}
