using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Vector3 screenSize;
    public float screenMargin;

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

    void RotateAndMoveTowardsDirection()
    {
        Vector3 screenSizeInPoint = new Vector3(Screen.width + screenMargin, Screen.height + screenMargin, 0.0f);
        screenSize = Camera.main.ScreenToWorldPoint(screenSizeInPoint);

        //get random point to look at
        float pointX = Random.Range(-1.0f, 1.0f);
        float pointY = Random.Range(-1.0f, 1.0f);
        // Get angle in Radians
        float AngleRad = Mathf.Atan2(pointY - transform.position.y, pointX - transform.position.x);
        // To Degree
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg-90);
        
        GetComponent<Rigidbody>().AddForce(transform.up * 100f);
    }

}
