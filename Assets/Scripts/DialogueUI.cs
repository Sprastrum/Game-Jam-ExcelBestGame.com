using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text name_label;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject mainDialogueObj;
    [SerializeField] private GameObject dialogue_box;

    private TypeWriterEffect typeWriterEffect;
    private ResponseManager response_manager;
    // Start is called before the first frame update
    void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        response_manager = GetComponent<ResponseManager>();

        CloseDialogueBox();
        ShowDialogue(mainDialogueObj);
    }
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        OpenDialogueBox();
        name_label.text = dialogueObject.Name_Field;
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeWriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        if (dialogueObject.HasResponses)
        {
            response_manager.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
        

    }
    private void OpenDialogueBox()
    {
        Animator animator = dialogue_box.GetComponent<Animator>();
        animator.SetBool("IsOpen", true);
    }
    private void CloseDialogueBox()
    {
        Animator animator = dialogue_box.GetComponent<Animator>();
        animator.SetBool("IsOpen", false);
        textLabel.text = string.Empty;
    }
}
