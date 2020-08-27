using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSound : MonoBehaviour
{
    public void RunSoundEffect(float speed, AudioSource audioSource)
    {
        if(speed != 0)
            if(!audioSource.isPlaying)
                audioSource.Play();
        else if(speed == 0)
        {
            audioSource.Stop();
        }
    }

    public void Test()
    {
        print("Test");
    }
}
