using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    Transform target;
    public float cameraSpeed;

    void Start()
    {
        target = player.GetComponent<Transform>();
    }

    void Update()
    {
        if (player != null) 
        {
            updatelocation();
        }
    }

    void updatelocation()
    {
        if (target.position.y < 75)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, 75, -10), cameraSpeed);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, -10), cameraSpeed);
        }
    }
}
