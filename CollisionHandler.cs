using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
     [SerializeField] float levelLoadDelay = 1f;
     [SerializeField] AudioClip success;
     [SerializeField] AudioClip crash;
     [SerializeField] ParticleSystem successParticles;
     [SerializeField] ParticleSystem crashParticles;
     bool isTransitioning = false;
     bool collisionDisable = false;
     void Start() {
         audioSource = GetComponent<AudioSource>();
     }
     void Update() {
         cheatDebug();
     }
     void OnCollisionEnter(Collision other) {
      
       if (isTransitioning||collisionDisable)
       {
           return;
       }
       switch (other.gameObject.tag)
       {
           case "Friendly":
           {
               Debug.Log("this is friendly for rocket");
               break;
           }
           case "Finish":
           {           
               startNewLevel();
               break;
           }
           case "Fuel":
           {
               Debug.Log("you have full fuel");
               break;
           }
           default:
           {
               startCrashSequence();
               break;
           }
       }
   }
   void startCrashSequence()
   {
       isTransitioning = true;
       
       audioSource.Stop();
       audioSource.PlayOneShot(crash);
       crashParticles.Play();
       GetComponent<Movement>().enabled = false;
       Invoke("ReloadLevel",levelLoadDelay);
   }
   void startNewLevel()
   {
       isTransitioning = true;
       
       audioSource.Stop();
       audioSource.PlayOneShot(success);
       successParticles.Play();
       GetComponent<Movement>().enabled = false;
       Invoke("passLevel",levelLoadDelay);
       
   }
   void ReloadLevel()
   {
       
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;
       SceneManager.LoadScene(currentSceneIndex);
   }
   void passLevel()
   {
       
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       int nextSceneIndex = currentSceneIndex +1;
       if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
       {
           nextSceneIndex =  0;
       }
       SceneManager.LoadScene(nextSceneIndex);
   }
   void cheatDebug()
   {
       if(Input.GetKeyDown(KeyCode.L))
       {
           passLevel();
       }
       else if(Input.GetKeyDown(KeyCode.C))
       {
           collisionDisable = !collisionDisable;
       }
   }
}
