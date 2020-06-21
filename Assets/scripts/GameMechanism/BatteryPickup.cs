using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    FlashLightSystem flashLight;
    // Start is called before the first frame update
    void Start()
    {
        flashLight = FindObjectOfType<FlashLightSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            flashLight.RestoreLightAngle(75f);
            flashLight.RestoreLightIntensity(4f);
        }
    }
}
