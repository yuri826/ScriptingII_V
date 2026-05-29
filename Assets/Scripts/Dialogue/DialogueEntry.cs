using System;
using UnityEngine;

[Serializable]
public class DialogueEntry
{
    [field:SerializeField] public string body { get; set; }
    [field:SerializeField] public string name { get; set; }
    [field:SerializeField] public Sprite portrait { get; set; }
}
