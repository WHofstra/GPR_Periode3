using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    private PlayerHealth player;
    private Text text;

    private void Awake()
    {
        //Check if There is a Player
        player = FindObjectOfType<PlayerHealth>();
        text = GetComponent<Text>();

        if (player != null)
        {
            player = player.GetComponent<PlayerHealth>();
            player.ShowHealth += ChangePlayerHealth;
            player.PlayerDamaged += ChangePlayerHealth;
            player.PlayerDeath += GameOverText;
        }
    }

    private void ChangePlayerHealth(int currentHealth)
    {
        text.text = currentHealth + " hp";
    }

    private void GameOverText()
    {
        text.text = "Game Over";
    }
}
