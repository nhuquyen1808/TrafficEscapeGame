using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothTime;

    [Header("Axis Limitation")]

    public Vector2 maxPos;
    public Vector2 minPos;
    public GameObject player;
    private void Awake()
    {
       // target = player.transform;
    }
    private void FixedUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothTime);
        }
    }
}
    