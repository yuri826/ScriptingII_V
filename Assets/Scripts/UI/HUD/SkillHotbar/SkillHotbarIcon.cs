using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillHotbarIcon : MonoBehaviour
{
    private Animator anim;
    private Button button;
    
    [SerializeField] private PlayerSkill skill;
    [SerializeField] private Image iconImage;

    private int currentSlot;

    private void Start()
    {
        anim = GetComponent<Animator>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Show(transform));
        iconImage.sprite = skill.icon;
    }

    public void Show(Transform hotbarSocket)
    {
        transform.SetParent(hotbarSocket);
        transform.localPosition = Vector3.zero;
        anim.SetTrigger("Show");
    }
    
    public void Hide(Transform poolPosition)
    {
        anim.SetTrigger("Hide");
        StartCoroutine(HideRoutine(poolPosition));
    }

    private void EquipSkill()
    {
        GamemodeBase.Instance.GetSkillManager().SetSkill(currentSlot, skill);
    }

    private IEnumerator HideRoutine(Transform poolPosition)
    {
        yield return new WaitForSeconds(0.4f);
        transform.SetParent(poolPosition);
        transform.localPosition = Vector3.zero;
    }
}
