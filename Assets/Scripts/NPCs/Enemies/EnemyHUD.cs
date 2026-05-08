using System;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    [Serializable]
    public class EnemyHUD : EnemySubsystem
    {
        [SerializeField] private Image healthbarFill;

        public void UpdateBarFill(float amount, int maxAmount)
        {
            healthbarFill.fillAmount = amount/maxAmount;
        }
    }
}

