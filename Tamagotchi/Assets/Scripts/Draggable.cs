using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Rigidbody2D rigidbody2d;
    Vector3 firstFrameHeld;
    Vector3 lastFrameHeld;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMousePosition();
        firstFrameHeld = gameObject.transform.position;
    }

    private void OnMouseDrag()
    {
        lastFrameHeld = gameObject.transform.position;
        transform.position = GetMousePosition() + mousePositionOffset;
    }
    private void OnMouseUp()
    {
        //float distance = Vector3.Distance(lastFrameHeld, firstFrameHeld);
        //Vector3 force = transform.forward * distance;
        //Vector3 force = GetMousePosition() - lastFrameHeld;
        Vector3 force = lastFrameHeld - firstFrameHeld;
        //Vector3 force = new Vector3(Random.Range(-5, 5),0,0);
        rigidbody2d.AddForce(force * 2, ForceMode2D.Impulse);
    }

}
