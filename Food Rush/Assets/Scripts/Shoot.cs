using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float cooldown = 1f;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0f) {
            time -= Time.deltaTime;
        }
        else if (Input.GetMouseButton(0)) {
            Instantiate(bullet, transform.position, transform.rotation);
            time = cooldown;
        }
    }
}
