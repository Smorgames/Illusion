using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip disappearSound, disappearReverseSound;
    public AudioClip chainBreakSound, tonFallSound;
    public AudioClip runSound, switchSound, creepySound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FalseObject" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(disappearSound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FalseObject" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(disappearReverseSound);
        }
    }

    public void BreakChainLink()
    {
        audioSource.PlayOneShot(chainBreakSound);
    }

    public void TonFallSound()
    {
        audioSource.PlayOneShot(tonFallSound);
    }

    public void RunSound()
    {
        audioSource.PlayOneShot(runSound);
    }

    public void SwitchSound()
    {
        audioSource.PlayOneShot(switchSound);
    }

    public void CreepySound()
    {
        audioSource.PlayOneShot(creepySound);
    }
}
