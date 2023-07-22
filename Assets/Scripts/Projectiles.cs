using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    public string playerTag = "Player";


   private void OnCollisionEnter2D(Collision2D collision)
    {
         
        if (!collision.gameObject.CompareTag(playerTag))
        {
            Destroy(this.gameObject);
        }
    }
}

