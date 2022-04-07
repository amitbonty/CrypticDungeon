using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    void Start()
    {
        transform.position = player.position;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.Lerp(transform.position, player.position, speed);
        }
    }
    private void LateUpdate()
    {
        if (player != null)
        {
            float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(player.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
        }
    }
}
