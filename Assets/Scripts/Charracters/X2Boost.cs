using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X2Boost : MonoBehaviour
{
    public bool isActive = false;

    [SerializeField] private float _duration;

    [SerializeField] private GameManager _manager;
    
    public void Activate()
    {
        isActive = true;
        StartCoroutine(ResetCorutine());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
        {
            ICollectable collectable = other.GetComponent<ICollectable>();

            if (collectable != null)
            {
                collectable.Collect();
                Destroy(other.gameObject);
            }
        }
    }

    IEnumerator ResetCorutine()
    {
        yield return new WaitForSeconds(_duration);
        isActive = false;
    }
}
