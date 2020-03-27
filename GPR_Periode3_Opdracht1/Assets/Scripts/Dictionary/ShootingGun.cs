using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootingGun : MonoBehaviour
{
    public event Action<string, int> UIChange;

    private enum Weapon
    {
        HANDGUN, RIFLE, SHOTGUN, EXPLOSIVES
    }

    private Dictionary<Weapon, string> weaponName = new Dictionary<Weapon, string>();
    private Dictionary<Weapon, int> ammo = new Dictionary<Weapon, int>();

    private Weapon currentWeapon = Weapon.HANDGUN;

    private void Start()
    {
        weaponName[Weapon.HANDGUN]    = "Handgun";
        weaponName[Weapon.RIFLE]      = "Rifle";
        weaponName[Weapon.SHOTGUN]    = "Shotgun";
        weaponName[Weapon.EXPLOSIVES] = "Explosives";

        ammo[Weapon.HANDGUN]    = 300;
        ammo[Weapon.RIFLE]      = 520;
        ammo[Weapon.SHOTGUN]    = 30;
        ammo[Weapon.EXPLOSIVES] = 10;

        UIChange(weaponName[currentWeapon], ammo[currentWeapon]);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            KeyInputs();
        }
    }

    void KeyInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo[currentWeapon] > 0)
        {
            ammo[currentWeapon]--;
            UIChange(weaponName[currentWeapon], ammo[currentWeapon]);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((int)currentWeapon < (System.Enum.GetValues(typeof(Weapon)).Length) - 1)
            {
                currentWeapon++;
            }
            else
            {
                currentWeapon = Weapon.HANDGUN;
            }

            UIChange(weaponName[currentWeapon], ammo[currentWeapon]);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if ((int)currentWeapon > 0)
            {
                currentWeapon--;
            }
            else
            {
                currentWeapon = (Weapon)(System.Enum.GetValues(typeof(Weapon)).Length - 1);
            }

            UIChange(weaponName[currentWeapon], ammo[currentWeapon]);
        }
    }
}
