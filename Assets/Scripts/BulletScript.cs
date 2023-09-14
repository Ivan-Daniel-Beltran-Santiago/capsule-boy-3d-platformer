using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider trigger) 
    {
        if(trigger.gameObject.tag == "Player" || trigger.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
