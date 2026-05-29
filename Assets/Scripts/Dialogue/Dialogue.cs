using System;
using UnityEngine;

[Serializable]
public class Dialogue
{
    [field:SerializeField] public DialogueEntry[] entries { get; set; }
}
