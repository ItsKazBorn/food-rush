using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerController : Enemy
{
    protected override void Start()
    {
        base.Start();
        ChangeDirectionToRandomPoint();
    }

    protected override void ChangeDirection()
    {
        if (transform.position.x < -xBounds || transform.position.x > xBounds)
            direction = new Vector3(-direction.x, direction.y, direction.z);

        if (transform.position.y < -yBounds || transform.position.y > yBounds)
            direction = new Vector3(direction.x, -direction.y, direction.z);
    }

    void ChangeDirectionToRandomPoint()
    {
        float randomX = Random.Range(-xBounds, xBounds);
        float randomY = Random.Range(-yBounds, yBounds);

        Vector3 randomPos = new Vector3(randomX, randomY, 0);
        direction = (randomPos - transform.position).normalized;
    }
}
