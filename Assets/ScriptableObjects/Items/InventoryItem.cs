using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Scriptable Objects/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    [field:SerializeField] public string Name { get; private set; }
    [TextArea(2,4)][field:SerializeField] public string Info { get; private set; }
    [field:SerializeField] public Sprite Image { get; private set; }
    [field:SerializeField] public Sprite InventorySprite { get; private set; }
}
