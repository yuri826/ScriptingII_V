using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillNode : MonoBehaviour
{
    [field: SerializeField] public SkillNodeState nodeState { get; private set; } = SkillNodeState.Locked;
    [SerializeField] private SkillNode[] nextNodes;

    [field: SerializeField] public PlayerSkill skill { get; set; }

    [SerializeField] private Image skillIcon;
    [SerializeField] private Image bgImage;
    
    [SerializeField] private GameObject select;
    [SerializeField] private GameObject acquired;
    
    private SkillTreeManager treeManager;

    private Button button;

    private void Start()
    {
        treeManager = transform.parent.parent.GetComponent<SkillTreeManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectNode);
        skillIcon.sprite = skill.icon;
        
        if (nodeState == SkillNodeState.Locked) bgImage.color = new Color(0.2f,0.2f,0.2f,1);
    }

    public void AcquireNode()
    {
        foreach (SkillNode node in nextNodes) node.UnlockNode();

        nodeState = SkillNodeState.Acquired;
        
        bgImage.color = new Color(0.5f,0.5f,0.5f,1);
        acquired.SetActive(true);

        GamemodeBase.Instance.GetPlayerState().ChangeXp(-skill.buyCost);
        GamemodeBase.Instance.GetSkillManager().AddSkill(skill);
    }

    public void SelectNode()
    {
        treeManager.DeselectAll();
        treeManager.ShowPanel(this);
        select.SetActive(true);
    }
    
    public void DeselectNode()
    {
        select.SetActive(false);
    }

    public void UnlockNode()
    {
        nodeState = SkillNodeState.Unlocked;
        bgImage.color = new Color(0.5f,0.5f,0.5f,1);
    }
}
