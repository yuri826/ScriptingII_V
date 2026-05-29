using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum DialogueState
{
    Typing,
    CanContinue,
    Choice
}

public class DialogueManagerNew : MonoBehaviour
{
    private DialogueState state = DialogueState.Typing;
    
    [Header("Story")]
    private Dialogue dialogue;

    private int lineIndex = 0;

    private string currentLine;
    private Coroutine typeRoutine;

    [Header("Components")] 
    [SerializeField] private GameObject textBox;
    [SerializeField] private Image portrait;
    [SerializeField] private GameObject buttonCanvas;
    [SerializeField] private TextMeshProUGUI bodyText;
    [SerializeField] private TextMeshProUGUI nameText;
    
    public void StartStory(Dialogue dialogue)
    {
        this.dialogue = dialogue;
        lineIndex = 0;
        textBox.SetActive(true);
        state = DialogueState.Typing;
        RefreshDialogue();
    }

    private void RefreshDialogue()
    {
        print("rfd");
        portrait.sprite = dialogue.entries[lineIndex].portrait;
        nameText.text = dialogue.entries[lineIndex].name;
        StartCoroutine(WriteText(dialogue.entries[lineIndex].body));
    }

    //Input
    public void OnClick()
    {
        print("clock");
        switch (state)
        {
            case DialogueState.Typing: WriteFullText();
                break;
            
            case DialogueState.CanContinue: ContinueLine();
                break;
            
            case DialogueState.Choice:
                break;
        }
    }

    private void WriteFullText()
    {
        print("wft");
        StopAllCoroutines();
        bodyText.text = dialogue.entries[lineIndex].body;
        EndLine();
    }

    private void ContinueLine()
    {
        print("ctl");
        if (lineIndex < dialogue.entries.Length-1)
        {
            print("del-1");
            lineIndex++;
            RefreshDialogue();
        }
        else
        {
            print("del+1");
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        textBox.SetActive(false);
        StartCoroutine(RetrieveInput());
    }

    private IEnumerator RetrieveInput()
    {
        yield return null;
        GamemodeBase.Instance.EndDialogue();
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
        state = DialogueState.CanContinue;
    }
}
