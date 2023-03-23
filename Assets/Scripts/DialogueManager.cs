using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public GameObject DialogueUI;

    public TMP_Text DialogueText;

    public GameObject Player;

    public Animator Animator;


    private Queue<string> dialogue;



    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences)
    {
        dialogue.Clear();
        DialogueUI.SetActive(true);

        SuspendPlayerControl();

        foreach (string currentLine in sentences)
        {
            dialogue.Enqueue(currentLine);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogue.Count == 0)
        {

            EndDialogue();
            return;
        }

        string currentline = dialogue.Dequeue();

        DialogueText.text = currentline;
    }

    void EndDialogue()
    {
        DialogueUI.SetActive(false);
        dialogue.Clear();

        Player.GetComponent<PlayerMovement_2D>().enabled = true;
        Player.GetComponent<PlayerInteraction>().enabled = true;
    }

    public void SuspendPlayerControl()
    {
        Player.GetComponent<PlayerMovement_2D>().enabled = false;
        Player.GetComponent<PlayerInteraction>().enabled = false;

        Animator.SetFloat("Speed", 0);
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
