using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDirector : MonoBehaviour
{
    [SerializeField] float DelayRestart = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !hasCrashed){
            hasCrashed = true;
            FindAnyObjectByType<PlayerController>().disabledControls();
            Debug.Log("hit the ground");
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", DelayRestart);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
