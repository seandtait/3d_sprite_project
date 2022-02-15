using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSingleSprite : MonoBehaviour
{
    private static Camera cam;
    private static float cameraFacing;
    static bool updatedThisFrame = false;

    private SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {  
        if (cam == null)
        {
            cam = Camera.main;
        }

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        updatedThisFrame = false;
    }

    void LateUpdate()
    {
        // Billboard
        transform.rotation = cam.transform.rotation;
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

    }

}
