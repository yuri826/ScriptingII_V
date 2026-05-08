using System;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class EnemyLoot : EnemySubsystem
    {
        //[SerializeField] private EnemyLoot[] possibleLoot;
        //[SerializeField] private int maxLoot;

        public void DropLoot()
        {
            // int lootAmount = Random.Range(0, maxLoot);
            //
            // for (int i = 0; i < lootAmount; i++)
            // {
            //     int lootIndex = Random.Range(0, possibleLoot.Length);
            //     Instantiate(possibleLoot[lootIndex]);
            // }
        }
    }
}

