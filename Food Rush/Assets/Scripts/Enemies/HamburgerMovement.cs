using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerMovement : MonoBehaviour
{
    private Vector3 screenSize;

    public float speed = 10;

    private bool spawning = true;
    private float xBounds = 16;
    private float yBounds = 6;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
        float randomX = Random.Range(-xBounds, xBounds);
        float randomY = Random.Range(-yBounds, yBounds);

        Vector3 randomPos = new Vector3(randomX, randomY, 0);
        direction = (randomPos - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirectionOnBorder();
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void ChangeDirectionOnBorder()
    {
        if (!spawning)
        {
            if (transform.position.x < -xBounds || transform.position.x > xBounds)
            {
                direction = new Vector3(-direction.x, direction.y, direction.z);
            }

            if (transform.position.y < -yBounds || transform.position.y > yBounds)
            {
                direction = new Vector3(direction.x, -direction.y, direction.z);
            }
        }
        else
        {
            if (transform.position.x > -xBounds && transform.position.x < xBounds
                                                && transform.position.y > -yBounds && transform.position.y < yBounds)
            {
                spawning = false;
            }
        }
    }
}
