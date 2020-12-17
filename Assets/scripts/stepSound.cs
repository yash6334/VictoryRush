using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepSound : MonoBehaviour
{
    [SerializeField] AudioSource stepSource;
    [SerializeField] AudioClip stepAudio;
    [SerializeField] AudioClip runAudio;
    [SerializeField] AudioClip jumpAudio;
    [SerializeField] AudioClip landAudio;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            StepSounds();
        }
        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            StepSounds();
        }
        if (Input.GetKeyDown("space"))
        {
            stepSource.Stop();
            stepSource.PlayOneShot(jumpAudio);
            stepSource.PlayOneShot(landAudio);
        }
    }

    private void StepSounds()
    {
        if (Input.GetKey("left shift"))
        {
            if (stepSource.isPlaying == false)
                stepSource.PlayOneShot(runAudio);
        }
        else
        {
            if (stepSource.isPlaying == false)
                stepSource.PlayOneShot(stepAudio);
        }
    }
}
