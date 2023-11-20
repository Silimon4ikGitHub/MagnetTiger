using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector2 MouseVector()
    {
        Vector2 tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return tapPosition;
    }

    public Vector2 TouchVector()
    {
        Touch touch = Input.GetTouch(0);

        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        return touchPosition;
    }
}
