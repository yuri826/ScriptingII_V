using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHotbarManager : MonoBehaviour
{
    [SerializeField] private Transform hotbarSocketParent;
    [SerializeField] private Transform[] hotbarSockets;
    [SerializeField] private Transform poolPosition;
    public List<SkillHotbarIcon> hotbarIcons { get; set; } = new List<SkillHotbarIcon>();

    public bool isOpening { get; set; }
    private Coroutine showRoutine;
    private Coroutine hideRoutine;

    public void ShowIcons(Transform hotbarParent, int slotN)
    {
        foreach (var t in hotbarIcons)
        {
            t.currentSlot = slotN;
        }
        
        hotbarSocketParent.SetParent(hotbarParent);
        hotbarSocketParent.localPosition = Vector3.zero;
        StartCoroutine(ShowRoutine());
    }

    public void AddIcon(SkillHotbarIcon skill)
    {
        hotbarIcons.Add(skill);
    }
    
    public void HideIcons()
    {
        for (int i = hotbarIcons.Count-1; i >= 0 ; i--)
        {
            hotbarIcons[i].Hide(poolPosition);
        }
        isOpening = false;
    }

    private IEnumerator ShowRoutine()
    {
        isOpening = true;
        
        for (int i = 0; i < hotbarIcons.Count; i++)
        {
            hotbarIcons[i].Show(hotbarSockets[i]);
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(0.3f);
        
        isOpening = false;
    }
    
    private IEnumerator HideRoutine()
    {
        isOpening = true;
        
        for (int i = hotbarIcons.Count-1; i >= 0 ; i--)
        {
            hotbarIcons[i].Hide(poolPosition);
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(0.3f);
        
        isOpening = false;
    }
}
