using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float _magnetSpeed;
    public float _attractionRadius;

    public void MoveMagnet(Vector2 dirrection)
    {
        transform.position = Vector2.MoveTowards(transform.position, dirrection, _magnetSpeed);
    }

    public void AttractItems()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attractionRadius);

        foreach (Collider2D collider in colliders)
        {
            ICollectable item = collider.GetComponent<ICollectable>();

            if (item != null)
            {
                Debug.Log("here");
                Vector2 direction = (transform.position);
                item.ApplyForce(direction);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.position, _attractionRadius);
    }
}
