using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryDoor : MonoBehaviour
{
    public Animator animator;
    public GameObject door_axis;
    public bool isOpen;
    AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        animator = door_axis.GetComponent<Animator>();
        isOpen = false;
        audioSource = GetComponent<AudioSource>();
        audioClip = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (/*other.CompareTag("MainCamera") || */other.CompareTag("Human"))
        {
            //update hp info
            animator.SetTrigger("Open");
            isOpen = true;
            //audioSource.Play();
            audioSource.PlayDelayed(0.5f);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (isOpen)
        {
            animator.SetTrigger("Close");
            isOpen = false;
            //audioSource.Play();
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(audioClip);

        }

    }
}
