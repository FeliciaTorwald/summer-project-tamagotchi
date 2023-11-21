using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed = 100.0f;
    public GameObject explosionPrefab;
    private PointManager pointManager;
    private void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();    
    }
    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosionPrefab, transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(50);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }
}
