using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject ClosedDoor;
    public GameObject OpenDoor;

    [HideInInspector] public bool open = false;

    public void Interact()
    {
        if (open)
        {
            Close();
        } else
        {
            Open();
        }
    }

    void Open()
    {
        OpenDoor.SetActive(true);
        ClosedDoor.SetActive(false);
        open = true;
    }

    void Close()
    {
        ClosedDoor.SetActive(true);
        OpenDoor.SetActive(false);
        open = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
