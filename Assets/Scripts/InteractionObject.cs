using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    public enum InteractableType
    {
        nothing,
        info,
        pickup,
        dialogue
    }

    [Header("Type of interactable")]
    public InteractableType interType;

    [Header("Simple Info Message")]
    public string InfoMessage;
    private TMP_Text InfoText;

    [Header("Dialogue Text")]
    [TextArea]
    public string[] sentences;

    public void Start()
    {
        InfoText = GameObject.Find("InfoText").GetComponent<TMP_Text>();
    }

    public void DebugTest()
    {
        Debug.Log("This is a "+gameObject.name);
    }

    public void Nothing()
    {
        Debug.LogWarning("Object "+this.gameObject.name+" has no type set.");
    }

    public void Info()
    {
        //InfoText.text = InfoMessage;

        StartCoroutine(ShowInfo(InfoMessage, 2.5f));
    }

    public void Pickup()
    {
        Debug.Log("You picked up " + this.gameObject.name);
        this.gameObject.SetActive(false);
    }

    public void Dialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        InfoText.text = message;
        yield return new WaitForSeconds(delay);
        InfoText.text = null;
    }
}
