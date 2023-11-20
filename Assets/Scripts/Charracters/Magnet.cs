using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float MagnetForse;
    public float _attractionRadius;

    public void AttractItems()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attractionRadius);

        foreach (Collider2D collider in colliders)
        {
            ICollectable item = collider.GetComponent<ICollectable>();

            if (item != null)
            {
                Vector2 direction = (transform.position);
                item.ApplyForce(direction, MagnetForse);
            }
        }
    }
}
