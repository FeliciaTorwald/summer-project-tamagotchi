using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] GameObject effectPrefab;

    Vector3 mousePosition;
    private Vector2 cursorHotspot;
    void Start()
    {
      cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
      Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            ClickEffect();
        }
    }

    void ClickEffect()
    {
        GameObject g = Instantiate(effectPrefab, mousePosition,Quaternion.identity);
        Destroy(g, 0.5f);
    }

}
