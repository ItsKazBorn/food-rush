using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Border") {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter (Collision collision) {
        Debug.Log("Collision detected");
        if (collision.gameObject.layer == 8) {
            Debug.Log("Collided with enemy");
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
