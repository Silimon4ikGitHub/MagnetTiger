using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable, IPositiveItem
{
    public float attractionForce = 10.0f;
    [SerializeField] private int count = 1;
    [SerializeField] private GameManager manager;

    private Rigidbody2D rb;

    private void Awake()
    {
        manager = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        count = 1;
    }

    public void Collect()
    {
        manager.CoinsCollected += count;
        manager.UpdateScore();
    }

    public void ApplyForce(Vector2 direction)
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, attractionForce);
    }
}
