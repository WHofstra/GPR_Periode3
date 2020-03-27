using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private PlayerHealth player;
    private Animator animator;

    private void Awake()
    {
        //Check if There is a Player
        player = FindObjectOfType<PlayerHealth>();

        if (player != null)
        {
            Debug.Log(player.gameObject.name + " is present.");
            player = player.GetComponent<PlayerHealth>();
            animator = GetComponent<Animator>();

            player.PlayerDamaged += Shake;
        }
    }

    private void Shake(int health)
    {
        Debug.Log("Shake!");
        animator.SetTrigger("Shake");
    }
}
