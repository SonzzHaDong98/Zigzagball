using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool gameOver;
    Vector3 offset;
    GameObject player;
    public float speed;

    private void Start()
    {
        gameOver = false;
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        if (gameOver) return;
        transform.position = Vector3.Lerp(transform.position,player.transform.position + offset,speed * Time.deltaTime);
    }
}
