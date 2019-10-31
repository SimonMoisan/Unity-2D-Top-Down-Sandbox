using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed = 5f;

    public Rigidbody2D rb;
    public Collider2D[] pickableObjectsPositions;

    private Vector2 movement;
    private Animator animator;
    private Inventory inventory;
    public Weapon weapon;

    public string orientation = "Right";
    public Transform[] gunPositions;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPickableObjects();

        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Pick an item
        if (Input.GetKeyDown(KeyCode.E) && !inventoryIsFull())
        {
            foreach(Collider2D obj in pickableObjectsPositions)
            {
                if(obj.gameObject.GetComponent<PickableObjects>() != null)
                {
                    Debug.Log("Pickable object found");
                    obj.gameObject.GetComponent<PickableObjects>().objectBeingPicked = true;
                    break;
                }
            }
        }

        //Animation management
        animator.SetFloat("x", movement.x);
        animator.SetFloat("y", movement.y);

        if (weapon != null)
        {
            if(orientation == "Left" && movement.x > 0)
            {
                weapon.gunPosition = gunPositions[0];
                orientation = "Right";
            }
            else if(orientation == "Right" && movement.x < 0)
            {
                weapon.gunPosition = gunPositions[1];
                orientation = "Left";
            }
        }
    }

    //Better with physic
    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }

    bool inventoryIsFull()
    {
        for(int i=0; i<inventory.isFull.Length; i++)
        {
            if(!inventory.isFull[i])
            {
                return false;
            }
        }
        return true;
    }

    void GetPickableObjects()
    {
        pickableObjectsPositions = Physics2D.OverlapCircleAll(transform.position, 1.5f);
    }

    public void equipWeapon(Weapon weaponPrefab)
    {
        weapon = Instantiate(weaponPrefab, gunPositions[0].position, Quaternion.identity);
        weapon.gunPosition = gunPositions[0];
    }
}
