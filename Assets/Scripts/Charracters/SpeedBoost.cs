using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float _increasedSpeed;
    [SerializeField] private float _originalSpeed;
    [SerializeField] private float _duration;

    [SerializeField] private GameManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<GameManager>();
    }

    public void Activate()
    {
        _originalSpeed = _manager.Player.speed;
        _manager.Player.speed = _increasedSpeed;

        SubscribeAttractPositive();
        StartCoroutine(ResetCorutine());
    }

    private void ResetSpeed(float speed)
    {
        _manager.Player.speed = speed;
    }

    private void AttractPositiveItems()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _manager.Magnet._attractionRadius);

        foreach (Collider2D collider in colliders)
        {
            IPositiveItem item = collider.GetComponent<IPositiveItem>();

            if (item != null)
            {
                Debug.Log("here");
                Vector2 direction = (transform.position);
                item.ApplyForce(direction);
            }
        }
    }

    IEnumerator ResetCorutine()
    {
        yield return new WaitForSeconds(_duration);
        ResetSpeed(_originalSpeed);
        UnSubscribeAttractPositive();
    }

    private void SubscribeAttractPositive()
    {
        _manager.Boost += AttractPositiveItems;
    }

    private void UnSubscribeAttractPositive()
    {
        _manager.Boost -= AttractPositiveItems;
    }
}
