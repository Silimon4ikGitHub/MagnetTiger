using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public void MoveUp()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
