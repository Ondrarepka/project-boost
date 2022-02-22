using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 380f;
    [SerializeField] float turnThrust = 100f;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        //space input
        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        else
        {
            audioSource.Stop();
        }
        
    }

    void ProcessRotation()
    {
        //left input
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(turnThrust);
        }
        //right input
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-turnThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation from physics, so we can rotate manualy
        transform.Rotate(rotationThisFrame * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false; //unfreezing rotation again
    }
}
