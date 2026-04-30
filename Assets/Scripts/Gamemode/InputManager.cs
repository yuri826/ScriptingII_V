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
    }
}
