using CatalystSystem.EffectComponents;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Katana
*   </summary>
*/

namespace CatalystSystem.MeleeComponents
{
    [CreateAssetMenu(fileName = "Katana Melee", menuName = "Catalyst System/Melee/Katana")]
    public class MeleeComponentKatana : MeleeComponent
    {
        [Header("Critical Stats")]
        [SerializeField] private float _criticalChance;
        [SerializeField] private float _criticalMultiplier;

        public override void Attack(int index, Vector3 position, EffectComponent effectComponent)
        {
            // Make sure the index is valid
            var tempIndex = ConstantVectors.HandleIndex(index);

            // Get direction and spawn the Hitbox
            Vector3 dir = position + ConstantVectors.Origins[tempIndex];
            Hitbox hitbox = Instantiate(HitboxPrefab, dir, Quaternion.identity);

            // Rotate the hitbox to face the player
            dir = hitbox.transform.position - position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            hitbox.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            var tempDamage = Damage;
            if (Random.value < _criticalChance)
                tempDamage *= _criticalMultiplier;

            // Initialize the Hitbox
            hitbox.Initialize(.5f, tempDamage, effectComponent);
        }
        public override string ToString()
        {
            return string.Format("Katana Initialized. Attack Speed = {0}, Damage = {1}, Critical Chance = {2}, Critical Multiplier = {3}!", AttackSpeed, Damage, _criticalChance, _criticalMultiplier);
        }
    }
}