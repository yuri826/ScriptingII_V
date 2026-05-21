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
    [SerializeField] private Image[] paths;
    
    [SerializeField] private GameObject select;
    [SerializeField] private GameObject acquired;
    [SerializeField] private Sprite acquiredPathSprite;
    [SerializeField] private Sprite unlockedSprite;
    [SerializeField] private Sprite lockedSprite;
    
    private SkillTreeManager treeManager;

    private Button button;

    private void Start()
    {
        treeManager = transform.parent.parent.GetComponent<SkillTreeManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectNode);
        skillIcon.sprite = skill.icon;
        
        switch (nodeState)
        {
            case SkillNodeState.Locked:
                bgImage.sprite = lockedSprite;
                skillIcon.color = new Vector4(1, 1, 1, 0.2f);
                break;
            case SkillNodeState.Unlocked:
                bgImage.sprite = unlockedSprite;
                skillIcon.color = new Vector4(1, 1, 1, 1);
                break;
        }
    }

    public void AcquireNode()
    {
        foreach (SkillNode node in nextNodes) node.UnlockNode();

        nodeState = SkillNodeState.Acquired;
        
        acquired.SetActive(true);

        for (var index = 0; index < paths.Length; index++)
        {
            paths[index].sprite = acquiredPathSprite;
        }

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

    private void UnlockNode()
    {
        nodeState = SkillNodeState.Unlocked;
        bgImage.sprite = unlockedSprite;
        skillIcon.color = new Vector4(1, 1, 1, 1);
    }
}
