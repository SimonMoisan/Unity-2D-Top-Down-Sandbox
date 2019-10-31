using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickableEffect : MonoBehaviour
{
    //Attributs
    public void useEffect()
    {
        Debug.Log("Potion used");
        Destroy(gameObject);
    }
}
