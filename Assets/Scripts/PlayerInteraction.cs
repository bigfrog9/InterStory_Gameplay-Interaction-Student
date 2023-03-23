using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    public GameObject currentInterObject = null;

    [SerializeField]
    public InteractionObject currentInterObjectsScript = null;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && currentInterObject == true)
        {
            CheckInteraction();
        }
    }

    private void CheckInteraction()
    {
        if (currentInterObjectsScript.interType == InteractionObject.InteractableType.nothing)
        {
            currentInterObjectsScript.Nothing();
        }

        else if (currentInterObjectsScript.interType == InteractionObject.InteractableType.info)
        {
            currentInterObjectsScript.Info();
        }

        else if (currentInterObjectsScript.interType == InteractionObject.InteractableType.pickup)
        {
            currentInterObjectsScript.Pickup();
        }

        else if (currentInterObjectsScript.interType == InteractionObject.InteractableType.dialogue)
        {
            currentInterObjectsScript.Dialogue();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObject = other.gameObject;
            currentInterObjectsScript = currentInterObject.GetComponent<InteractionObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObject = null;
            currentInterObjectsScript = null;
        }
    }

}
