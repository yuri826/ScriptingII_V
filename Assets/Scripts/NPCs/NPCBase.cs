using UnityEngine;

public class NPCBase : InteractableObject
{
    [SerializeField] protected Dialogue dialogue;
    
    public override void OnInteract()
    {
        GamemodeBase.Instance.StartDialogue(dialogue);
    }
}
