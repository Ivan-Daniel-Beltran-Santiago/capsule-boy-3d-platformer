using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    bool dead = false;

    [SerializeField] AudioSource deathSound;

    private void Update() 
    {
        if(transform.position.y < -6.5f && !dead)
        {
            Transform childToRemove = transform.Find("Main Camera");
            childToRemove.parent = null;
            YouDied();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy Body") || collision.gameObject.CompareTag("Bullet"))
        {
            Dying();
            YouDied();
        }
    }

    private void OnTriggerEnter(Collider trigger) 
    {
        if(trigger.gameObject.tag == "Bullet"){
            Dying();
            YouDied();
        }

        if(trigger.gameObject.tag == "Finish Line"){
            Invoke(nameof(DontMove), 0.1f);
        }
    }

    void Dying()
    {
        GetComponent<MeshRenderer>().enabled = false;
        DontMove();
    }

    void DontMove()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Player_Controller>().enabled = false;
    }
    
    void YouDied()
    {
        Invoke(nameof(ReloadLevel), 1.25f);
        dead =  true;
        deathSound.Play();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
