using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int _health;

    [SerializeField]
    private Text _healthText;

    private void Start()
    {
        _healthText.text = "Health: " + _health;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        _health -= 10;
        _healthText.text = "Health: " + _health;
    }
}
