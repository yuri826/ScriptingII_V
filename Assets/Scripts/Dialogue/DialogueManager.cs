using System;
using System.Collections;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum DialogueState
{
    Typing,
    CanContinue,
    Choice
}

public class DialogueManager : MonoBehaviour
{
    private DialogueState state = DialogueState.Typing;
    
    [SerializeField] private TextAsset inkJSONAsset;
    private Story story;

    private string currentLine;

    private Coroutine typeRoutine;
    
    [SerializeField] private GameObject buttonCanvas;
    [SerializeField] private TextMeshProUGUI bodyText;
    [SerializeField] private Button buttonPrefab;

    private void Start()
    {
        StartStory(inkJSONAsset);
    }

    public void OnClick()
    {
        switch (state)
        {
            case DialogueState.Typing: //WriteFullText(); -> Va medio raro
                break;
            
            case DialogueState.CanContinue: RefreshView();
                break;
            
            case DialogueState.Choice:
                break;
        }
    }
    
    private void StartStory(TextAsset inkJSON) 
    {
        state = DialogueState.Typing;
        story = new Story (inkJSON.text);
        RefreshView();
    }

    private void WriteFullText()
    {
        if (typeRoutine is not null) StopCoroutine(typeRoutine);
        bodyText.text = currentLine;
        
        EndLine();
    }

    private string ContinueStory()
    {
        return story.canContinue ? story.Continue() : "";
    }
    
    private void RefreshView()
    {
        RemoveChildren();

        currentLine = ContinueStory();
        typeRoutine = StartCoroutine(WriteText(currentLine));
    }

    private IEnumerator WriteText(string text)
    {
        bodyText.text = "";
        
        foreach (char ch in text)
        {
            bodyText.text += ch;
            yield return new WaitForSeconds(0.02f);
        }

        EndLine();
    }

    private void EndLine()
    {
        if (story.currentChoices.Count > 0)
        {
            if (story.currentChoices.Count > 0)
            {
                foreach (var choice in story.currentChoices)
                {
                    Button button = CreateChoiceView (choice.text.Trim());

                    var choice1 = choice;
                    button.onClick.AddListener (delegate { OnClickChoiceButton (choice1); });
                }
            }

            state = DialogueState.Choice;
        }
        else
        {
            state = DialogueState.CanContinue;
        }
    }

    private void OnClickChoiceButton (Choice choice) 
    {
        story.ChooseChoiceIndex (choice.index);
        RefreshView();
    }
    
    private Button CreateChoiceView (string text) 
    {
        // Creates the button from a prefab
        Button choice = Instantiate (buttonPrefab, buttonCanvas.transform, false) as Button;

        // Gets the text from the button prefab
        choice.GetComponentInChildren<TextMeshProUGUI>().text = text;

        // Make the button expand to fit the text
        choice.GetComponent<HorizontalLayoutGroup>().childForceExpandHeight = false;

        return choice;
    }
    
    private void RemoveChildren() 
    {
        foreach (Transform child in buttonCanvas.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
