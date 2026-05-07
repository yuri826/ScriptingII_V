using System;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    [SerializeField] private GameObject treePanel;
    [SerializeField] private GameObject infoPanel;

    private void Start()
    {
        treePanel.SetActive(false);
        infoPanel.SetActive(false);
    }

    public void DeselectAll()
    {
        foreach (Transform node in transform)
        {
            if (node.TryGetComponent(out SkillNode skillNode))
            {
                skillNode.DeselectNode();
            }
        }
    }
}
