using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed;

    Vector2 targetPos;


    private void Start()
    {
        targetPos = endPoint.position;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, endPoint.position) < 0.1)
        {
            targetPos = startPoint.position;
        }

        if (Vector2.Distance(transform.position, startPoint.position) < 0.1)
        {
            targetPos = endPoint.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
