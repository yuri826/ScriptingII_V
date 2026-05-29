using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputBlockButton : Button
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("In");
        GamemodeBase.Instance.GetInputManager().EnableHUDInteraction();
    }
    
    public override void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Out");
        GamemodeBase.Instance.GetInputManager().DisableHUDInteraction();
    }
}
