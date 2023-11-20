using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public bool isActive = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(isActive)
        {
            ICollectable collectable = other.GetComponent<ICollectable>();

            if (collectable != null)
            {
                collectable.Collect();
                Destroy(other.gameObject);
            }
        }

    }
}
