using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CracklingLight : MonoBehaviour
{
    // Ref
    Light myLight;

    // Config
    public float crackleSpeed = 0.15f;
    public float minIntensity = 1.75f;
    public float maxIntensity = 6.5f;

    // Var
    private float currentTimer = 0;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer >= crackleSpeed)
        {
            currentTimer = 0;
            myLight.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}
