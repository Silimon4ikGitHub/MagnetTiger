using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable, IPositiveItem
{
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

    public void ApplyForce(Vector2 direction, float forse)
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, forse);
    }
}
