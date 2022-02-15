using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool running = false;
    private Camera cam;

    float interactionRange = 1.4f;

    public TMPro.TextMeshProUGUI interactHover;
    public GameObject HoverGameObject;
    private GameObject lastHoveredGameObject;

    // Start is called before the first frame update
    void Start()
    {
        HoverGameObject = null;
        lastHoveredGameObject = gameObject;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input
        GetMovementInput();
        Interact();
        
        

    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (HoverGameObject == null)
            {
                return;
            }
            Door _d = HoverGameObject.GetComponentInParent<Door>();
            if (_d != null)
            {
                _d.Interact();
            }
        }
    }

    void GetMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        } else
        {
            running = false;
        }
    }

    private void FixedUpdate()
    {
        // Check GameObject in close range of player
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionRange))
        {
            HoverGameObject = hit.collider.gameObject;
        } else
        {
            HoverGameObject = null;
        }

        if (lastHoveredGameObject != HoverGameObject)
        {
            lastHoveredGameObject = HoverGameObject;
            CheckForInteractionHover();
        }

    }

    public void CheckForInteractionHover()
    {
        if (HoverGameObject == null)
        {
            SetInteractionHoverText("");
            return;
        }

        bool textSet = false;

        Door _d = HoverGameObject.GetComponentInParent<Door>();
        if (_d != null)
        {
            if (_d.open)
            {
                SetInteractionHoverText("Close Door");
            } else
            {
                SetInteractionHoverText("Open Door");
            }
            textSet = true;
        }

        if (!textSet)
        {
            SetInteractionHoverText("");
        }
    }

    public void SetInteractionHoverText(string _msg)
    {
        interactHover.text = _msg;
    }

}
