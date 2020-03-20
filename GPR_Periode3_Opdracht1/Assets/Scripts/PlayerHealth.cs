using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    const int HEALTH_LOSE = 10;

    [SerializeField]
    private int _health;

    public event Action<int> ShowHealth;
    public event Action<int> PlayerDamaged;
    public event Action PlayerDeath;

    private void Awake()
    {
        ShowHealth(_health);
    }

    private void Update()
    {
        if (_health <= 0)
        {
            PlayerDeath();
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        _health -= HEALTH_LOSE;
        PlayerDamaged(_health);
    }
}
