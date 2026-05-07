using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class InputManager : GamemodeSubsystem
{
    [field: SerializeField] public InputReaderSO inputReader { get; private set; }

    public override void OnEnable()
    {
        inputReader.onClickStarted += gamemodeParent.OnLClick;
        inputReader.onActiveSkill1 += gamemodeParent.OnEquipActiveSkill;
        inputReader.onActiveSkill2 += gamemodeParent.OnEquipActiveSkill;
    }
    
    public void EnableHUDInteraction()
    {
        Debug.Log("In"); 
        inputReader.EnableHUDInteraction(); 
    }

    public void DisableHUDInteraction()
    {
        Debug.Log("Out");
        inputReader.DisableHUDInteraction();
    }
}
