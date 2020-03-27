using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    private PlayerHealth player;
    private ShootingGun weapon;
    private Text text;

    private void Awake()
    {
        //Check if There is a Player and Weapon
        player = FindObjectOfType<PlayerHealth>();
        weapon = FindObjectOfType<ShootingGun>();
        text = GetComponent<Text>();

        if (player != null)
        {
            player = player.GetComponent<PlayerHealth>();
            player.ShowHealth += ChangePlayerHealth;
            player.PlayerDamaged += ChangePlayerHealth;
            player.PlayerDeath += GameOverText;
        }

        if (weapon != null)
        {
            weapon = weapon.GetComponent<ShootingGun>();
            weapon.UIChange += ChangeAmmoText;
        }
    }

    void ChangeAmmoText(string name, int ammo)
    {
        text.text = (name + ": [" + ammo + "]").ToString();
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
