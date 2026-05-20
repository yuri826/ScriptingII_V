using UnityEngine;

public class NPCBase : InteractableObject
{
    [SerializeField] protected TextAsset npcInkStory;
    
    public override void OnInteract()
    {
        GamemodeBase.Instance.StartDialogue(npcInkStory);
    }
}
