using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAttack : AttackType
{
    public Transform attackPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    new public void attack(float attackRange, float damage, LayerMask whatIsEnnemy)
    {
        Collider2D[] ennemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnnemy);
        for (int i = 0; i < ennemiesToDamage.Length; i++)
        {
            ennemiesToDamage[i].GetComponent<Ennemy>().TakeDamage(damage);
        }
    }
}
