using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public PlayerBall player;
    Transform playerTransform;
    Vector3 Offset;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = player.transform;
        Offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }
}
