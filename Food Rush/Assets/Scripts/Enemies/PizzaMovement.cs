using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMovement : MonoBehaviour
{
    private GameObject player;
    public GameObject sprite;
    
    public float speed = 10;

    private bool spawning = true;
    private float xBounds = 16;
    private float yBounds = 6;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ChangeDirectionToPlayerPosition();
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
            if (transform.position.x < -xBounds || transform.position.x > xBounds || transform.position.y < -yBounds || transform.position.y > yBounds)
            {
                ChangeDirectionToPlayerPosition();
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

    void ChangeDirectionToPlayerPosition()
    {
        direction = (player.transform.position - transform.position).normalized;
        TurnSprite();
    }

    void TurnSprite()
    {
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sprite.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
