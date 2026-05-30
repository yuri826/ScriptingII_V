using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    [Serializable]
    public class EnemyLoot : EnemySubsystem
    {
        [SerializeField] private int XPTogive;
        [SerializeField] private GameObject[] possibleLoot;
        [SerializeField] private int maxLoot;

        public void DropLoot(Vector3 pos)
        {
            GamemodeBase.Instance.GetPlayerState().ChangeXp(XPTogive);
            int lootAmount = Random.Range(0, maxLoot);
            
            for (int i = 0; i < lootAmount; i++)
            {
                int lootIndex = Random.Range(0, possibleLoot.Length);
                GameObject.Instantiate(possibleLoot[lootIndex], 
                    pos + new Vector3(Random.Range(-1,1),0,Random.Range(-1,1)), 
                    Quaternion.identity);
            }
        }
    }
}

