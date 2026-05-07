using UnityEngine;

public class NPCBase : InteractableObject
{
    [SerializeField] private TextAsset npcInkStory;
    
    public override void OnInteract()
    {
        GamemodeBase.Instance.StartDialogue(npcInkStory);
    }
}
