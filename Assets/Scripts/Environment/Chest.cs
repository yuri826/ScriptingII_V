using UnityEngine;

public class Chest : InteractableObject
{
    private bool isOpened = false;
    
    public override void OnInteract()
    {
        if (isOpened) return;
        
        Debug.Log("Chest opened!");
        isOpened = true;
    }
}
