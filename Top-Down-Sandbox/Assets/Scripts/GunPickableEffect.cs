using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickableEffect : MonoBehaviour
{
    private Player player;
    public Weapon weapon;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void equippGun()
    {
        player.equipWeapon(weapon);
        Destroy(gameObject);
    }
}
