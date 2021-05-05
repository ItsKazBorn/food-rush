using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatataMovement : MonoBehaviour
{
    private GameObject player;
    
    public float speed = 3;

    private float xBounds = 16;
    private float yBounds = 6;

    private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirectionToPlayerPosition();
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    void ChangeDirectionToPlayerPosition()
    {
        direction = (player.transform.position - transform.position).normalized;
    }
}
