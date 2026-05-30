using System;
using System.Collections;
using UnityEngine;

public class InputBlockMenu : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DisableClick());
    }

    //para dar un frame de tiempo por si otro se cierra yt este se abre
    private IEnumerator DisableClick()
    {
        yield return null;
        GamemodeBase.Instance.GetInputManager().EnableHUDInteraction();
    }
    
    private void OnDisable()
    {
        GamemodeBase.Instance.GetInputManager().DisableHUDInteraction();
    }
}
