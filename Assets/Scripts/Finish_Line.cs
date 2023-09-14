using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Line : MonoBehaviour
{
    [SerializeField] AudioSource finishLine;
    private void OnTriggerEnter(Collider finish) 
    {
        if(finish.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(NextLevel), 0.75f);
            finishLine.Play();
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
