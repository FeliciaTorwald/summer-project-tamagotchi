using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeShooter : MonoBehaviour
{

    public GameObject bullet;
    public float moveSpeed = 5.0f;
    public float shootCooldown = 0.5f; // Adjust this value to set the cooldown time
    private float timeSinceLastShot;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > timeSinceLastShot + shootCooldown)
        {
            Shooting();
            timeSinceLastShot = Time.time; // Record the time of the last shot
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0);

        if (movement.magnitude > 1.0f)
        {
            movement.Normalize();
        }

        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    public void Shooting()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

}
