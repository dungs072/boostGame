using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] float mainThrust = 100f ; 
    [SerializeField] float RotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBoots;
    [SerializeField] ParticleSystem leftBoots;
    [SerializeField] ParticleSystem rightBoots;
    CollisionHandler coHandler;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coHandler = GetComponent<CollisionHandler>();
        audioSource = GetComponent<AudioSource>();
        coHandler.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
        //PlayAudio();
    }
    void ProcessThrust()
    {
       
        if(Input.GetKey(KeyCode.Space))
        {
            StartThursting();
        }
         else
            {
               ThrustingStop();
            }
        
        
    }
   void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            leftRotation();
        }

        else if(Input.GetKey(KeyCode.D))
        {
            
            rightRotation();
        }
        else
        {
           RotationStop();
        }
    }
    void StartThursting()
    {
            mainBoots.Play();
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
               audioSource.PlayOneShot(mainEngine);
            }
    }
    void leftRotation()
    {
        valueRotation(-1f);
        leftBoots.Play();
    }
    void rightRotation()
    {
        valueRotation(1f);
        rightBoots.Play();
    }    
    void RotationStop()
    {
        leftBoots.Stop();
        rightBoots.Stop();
    }
     void ThrustingStop()
    {
        mainBoots.Stop();
        audioSource.Stop();
    }
    void valueRotation(float value)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually roate
        transform.Rotate(-Vector3.forward * value * RotationThrust * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotationso the physics system can take over
    }  
    
}
