using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float levelLoadDelay = 2f;
   [SerializeField] AudioClip success;
   [SerializeField] AudioClip crash;

   [SerializeField] ParticleSystem successParticale;
   [SerializeField] ParticleSystem crashParticle;

   AudioSource audioSource;

   bool isTrangsitioning = false;
   bool collistionDisable = false;

   void Start()
   {
        audioSource = GetComponent<AudioSource>();
   }
   
     void Update()
     {
          RespondToDebugKeys();
     }

     void RespondToDebugKeys()
     {
          if (Input.GetKeyDown(KeyCode.L))
          {
               LoadNextLevel();
          }
          else if (Input.GetKeyDown(KeyCode.C))
          {
               collistionDisable = !collistionDisable;
          }
     }

   void OnCollisionEnter(Collision other) 
   {
        if (isTrangsitioning || collistionDisable)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
   }

   void StartSuccessSequence()
   {
        isTrangsitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticale.Play();
        GetComponent<Movement>().enabled = false;
        Invoke ("LoadNextLevel", levelLoadDelay);
   }

   void StartCrashSequence()
   {
        isTrangsitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke ("ReloadLevel", levelLoadDelay);
   }

   void ReloadLevel()
   {
        isTrangsitioning = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex +1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
   }

   void LoadNextLevel()
   {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
   }
}
