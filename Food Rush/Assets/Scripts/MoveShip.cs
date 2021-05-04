using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{

    public bool drift;
    public float rotationSpeed;
    public float movementSpeed;

    public float rotationStep;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveShipDirectional();
        moveShipTurn();
        rotateShip();
        
        clampPositionInsideViewport();
    }

    private void FixedUpdate () {
    }


    void moveShipTurn () {
        if (Input.GetKey(KeyCode.W)) {
            rigidbody.AddForce(transform.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            rigidbody.AddForce(transform.up * -movementSpeed * Time.deltaTime);
        }
    }

    void moveShipDirectional () {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementHorizontal, movementVertical, 0.0f);

        if (drift) {
            rigidbody.AddForce(movement);
        }
        else {
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    void rotateShip () {
        if (Input.GetKey(KeyCode.A)) {
            rigidbody.AddTorque(transform.forward * rotationSpeed * Time.deltaTime);
            //transform.Rotate(0.0f, 0.0f, rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D)) {
            rigidbody.AddTorque(transform.forward * -rotationSpeed * Time.deltaTime);
            //transform.Rotate(0.0f, 0.0f, -rotationSpeed);
        }
    }

    void clampPositionInsideViewport () {
        // Clamp Object inside Camera View
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
