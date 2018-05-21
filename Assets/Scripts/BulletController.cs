using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    private GameController gameController;

    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward*speed;
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Hazard"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Hazard"))
        {
            gameController.AddHit();
            //Destroy(gameObject);
            //Destroy(other.gameObject);
        }
    }
}
