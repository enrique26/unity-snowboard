using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] float DelayRestart = 1f;
    [SerializeField] ParticleSystem finishEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("finish");
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", DelayRestart);
        }
        
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
