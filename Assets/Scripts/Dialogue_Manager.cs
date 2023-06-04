using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    private Queue<string> sentences;
    public TMP_Text name_text;
    public TMP_Text sentence_text;
    public Animator animator;
    private void Start()
    {
        sentences = new Queue<string>();
    }
    public void Start_Dialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen",true);
        Debug.Log("Starting Conversation with: " + dialogue.name);
        name_text.text = dialogue.name;

        sentences.Clear();


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            
        }

        Display_Next_Sentence();
    }

    public void Display_Next_Sentence()
    {
        if (sentences.Count == 0)
        {
            End_Dialogue();
            return; 
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Type_Sentence(sentence));
    }

    IEnumerator Type_Sentence (string sentence)
    {
        sentence_text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            sentence_text.text += letter;
            yield return new WaitForSeconds(0.075f);
        }
    }

    void End_Dialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
