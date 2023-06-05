using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseManager : MonoBehaviour
{
    [SerializeField] private RectTransform response_box;
    [SerializeField] private RectTransform response_button_template;
    [SerializeField] private RectTransform response_container;

    private DialogueUI dialogueUI;
    private ResponseEvent[] ResponseEvents;

    List<GameObject> tempResponseButton = new List<GameObject>();

    public void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
    }
    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        this.ResponseEvents = responseEvents;
    }
    public void ShowResponses(Response[] responses)
    {
        float response_box_height = 0;

        for (int i = 0; i < responses.Length; i++)
        {
            Response response = responses[i];
            int response_Index = i;

            GameObject response_button = Instantiate(response_button_template.gameObject, response_container);
            response_button.gameObject.SetActive(true);
            response_button.GetComponent<TMP_Text>().text = response.ResponseText;
            response_button.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, response_Index));

            tempResponseButton.Add(response_button);

            response_box_height += response_button_template.sizeDelta.y;
        }

        response_box.sizeDelta = new Vector2(response_box.sizeDelta.x, response_box_height);

        response_box.gameObject.SetActive(true);

    }
    private void OnPickedResponse(Response response, int responseIndex)
    {

        foreach (GameObject button in tempResponseButton)
        {
            Destroy(button);
        }
        tempResponseButton.Clear();

        if (ResponseEvents != null && responseIndex <= ResponseEvents.Length)
        {
            ResponseEvents[responseIndex].OnPickedResponse?.Invoke();
        }

        ResponseEvents = null;

        response_box.gameObject.SetActive(false);

        if (response.Dialogue_Object)
        {
            dialogueUI.ShowDialogue(response.Dialogue_Object);
        }
        else
        {
            dialogueUI.CloseDialogueBox(response.Dialogue_Object.IsPlayer);
        }
        
    }
}
