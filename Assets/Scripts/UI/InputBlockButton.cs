using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputBlockButton : Button
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        GamemodeBase.Instance.GetInputManager().EnableHUDInteraction();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        GamemodeBase.Instance.GetInputManager().DisableHUDInteraction();
    }
}
