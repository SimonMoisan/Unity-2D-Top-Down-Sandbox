using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDropedItems : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void SpawnDroppedItem()
    {
        Vector2 newPos = new Vector2(player.position.x, player.position.y + 2);
        Instantiate(item, newPos, Quaternion.identity);
    }
}
