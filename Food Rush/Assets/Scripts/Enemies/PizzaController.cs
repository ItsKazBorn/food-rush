using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : Enemy
{
    private GameObject player;
    [SerializeField] private GameObject sprite;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        ChangeDirectionToPlayerPosition();
    }

    protected override void ChangeDirection()
    {
        if (transform.position.x < -xBounds || transform.position.x > xBounds || transform.position.y < -yBounds || transform.position.y > yBounds)
            ChangeDirectionToPlayerPosition();
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
