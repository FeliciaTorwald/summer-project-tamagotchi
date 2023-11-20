using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeShooter : MonoBehaviour
{

    public GameObject bullet;
    public float moveSpeed = 5.0f;
    private void Start()
    {
       
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        if (movement.magnitude > 1.0f)
        {
            movement.Normalize();
        }

        transform.Translate(movement * moveSpeed * Time.deltaTime);

    }
    public void Shooting()
    {
        Instantiate(bullet,transform.position, transform.rotation);
    }
}
