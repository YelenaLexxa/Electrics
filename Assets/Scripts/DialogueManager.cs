using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueBox;
    public GameObject ContinueButton;
    
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        DialogueBox.SetActive(false);
        ContinueButton.SetActive(false);
    }

    public void Talk()
    {
        DialogueBox.SetActive(true);
        ContinueButton.SetActive(true);
    }

    public void StartDialogue (Dialogue dialogue)
    {

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
    }

}
