using UnityEngine;
using UnityEngine.UI;

public class SkillTreeInfoPanel : MonoBehaviour
{
    [SerializeField] private Button buyButton;
    private SkillNode currentNode;
    
    [SerializeField] private GameObject skillPanel;

    private void Start()
    {
        buyButton.onClick.AddListener(TryBuySkill);
    }

    public void ShowPanel(SkillNode node)
    {
        skillPanel.SetActive(true);
        currentNode = node;
    }

    public void TryBuySkill()
    {
        if (currentNode is null) return;

        int currentXP = GamemodeBase.Instance.GetPlayerState().XP;
        
        if ((currentNode.nodeState != SkillNodeState.Unlocked) || (currentXP < currentNode.skill.buyCost)) return;
        
        currentNode.AcquireNode();
    }
}
