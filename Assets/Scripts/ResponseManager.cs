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

    List<GameObject> tempResponseButton = new List<GameObject>();

    public void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
    }
    public void ShowResponses(Response[] responses)
    {
        float response_box_height = 0;

        foreach (Response response in responses)
        {
            GameObject response_button = Instantiate(response_button_template.gameObject, response_container);
            response_button.gameObject.SetActive(true);
            response_button.GetComponent<TMP_Text>().text = response.ResponseText;
            response_button.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response));

            tempResponseButton.Add(response_button);

            response_box_height += response_button_template.sizeDelta.y;
        }

        response_box.sizeDelta = new Vector2(response_box.sizeDelta.x, response_box_height);

        response_box.gameObject.SetActive(true);

    }
    private void OnPickedResponse(Response response)
    {
        response_box.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButton)
        {
            Destroy(button);
        }
        tempResponseButton.Clear();

        dialogueUI.ShowDialogue(response.Dialogue_Object);
    }
}
