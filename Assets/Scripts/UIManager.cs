using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _manager;
    private void Awake()
    {
        _manager = FindAnyObjectByType<GameManager>();
    }
}
