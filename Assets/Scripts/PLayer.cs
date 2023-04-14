using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    private bool gameFinished;

    private void Start()
    {
        gameFinished = false;   
    }

    private void Update()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 2f))
        {
            GetComponent<Rigidbody>().velocity = Vector3.down * 25f;
            if(!gameFinished)
            {
                gameFinished = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().gameOver = true;
                GameManager.instance.GameOver();
                Destroy(gameObject, 5f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Diamond"))
        {
            GameManager.instance.UpdateDiamond();
            Destroy(other.gameObject);
        }
    }
}
