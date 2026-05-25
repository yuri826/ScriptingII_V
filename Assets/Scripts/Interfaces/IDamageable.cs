using System.Collections;
using UnityEngine;

namespace Interfaces
{
    public interface IDamageable
    {
        public void OnDamage(int damage)
        {
            
        }

        public IEnumerator ConstantDamage(float damage, float frequency)
        {
            yield return null;
        }
    }
}