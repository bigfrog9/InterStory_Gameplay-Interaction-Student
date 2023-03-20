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


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObject = other.gameObject;
        }
    }

}
