using System.Collections;
using UnityEngine;

namespace Interfaces
{
    public interface IDamageable
    {
        public void OnDamage(float damage)
        {
            
        }

        public IEnumerator ConstantDamage(float damage, float frequency)
        {
            yield return null;
        }
    }
}