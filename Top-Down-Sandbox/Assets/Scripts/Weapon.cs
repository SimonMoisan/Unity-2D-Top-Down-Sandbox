using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float angleMouse;
    public Transform gunPosition;
    public Animator animator;
    public AttackType attackType;

    public float rotationOffeset;

    public float damage;

    private float timeBtwAttacks;
    public float startTimeBtwAttacks;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnnemy;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gunPosition != null)
        {
            transform.position = gunPosition.position;
        }

        FollowMouse();
        if (Input.GetMouseButtonDown(0) && animator != null && attackType != null)
        {
            if (timeBtwAttacks <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //animator.SetTrigger("Attack");
                    attackType.attack(attackRange, damage, whatIsEnnemy);
                }
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else
            {
                timeBtwAttacks -= Time.deltaTime;
            }
        }
    }

    public void FollowMouse()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        angleMouse = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if(angleMouse > 90 || angleMouse < -90)
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        transform.rotation = Quaternion.AngleAxis(angleMouse + rotationOffeset, Vector3.forward);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
