using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour
{
    [SerializeField] private GameObject treePanel;
    [SerializeField] private GameObject infoPanel;
    
    [SerializeField] private Button buyButton;
    private SkillNode currentNode;
    
    [SerializeField] private GameObject skillPanel;

    private void Start()
    {
        buyButton.onClick.AddListener(TryBuySkill);
        
        treePanel.SetActive(false);
        infoPanel.SetActive(false);
    }

    public void ShowPanel(SkillNode node)
    {
        skillPanel.SetActive(true);
        currentNode = node;
    }

    private void HidePanel()
    {
        skillPanel.SetActive(false);
    }
    

    private void TryBuySkill()
    {
        if (currentNode is null) return;

        var currentXP = GamemodeBase.Instance.GetPlayerState().XP;
        
        if ((currentNode.nodeState != SkillNodeState.Unlocked) || (currentXP < currentNode.skill.buyCost)) return;
        
        currentNode.AcquireNode();
        
        DeselectAll();
        HidePanel();
    }

    public void DeselectAll()
    {
        foreach (Transform node in treePanel.transform)
        {
            if (node.TryGetComponent(out SkillNode skillNode))
            {
                skillNode.DeselectNode();
            }
        }
    }
}
