using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float decayAngle = 1f;
    [SerializeField] float minDecayAngle = 40f;
    [SerializeField] float decayLight = 0.05f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightIntensity()
    {
        if (myLight.spotAngle > minDecayAngle)
            myLight.spotAngle -= decayAngle * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        myLight.intensity -= decayLight * Time.deltaTime;
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float intensity)
    {
        myLight.intensity = intensity;
    }
}
