using System;
using CatalystSystem.EffectComponents;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Two Slotted Variation of the Melee Components
*   </summary>
*/

namespace CatalystSystem.MeleeComponents
{
    [CreateAssetMenu(fileName = "Two Slotted Weapon", menuName = "Catalyst System/Melee/Two Slotted")]
    public class MeleeComponentTwoSlotted : MeleeComponent
    {
        [SerializeField] private EffectComponent _secondEffectComponent;
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

            // Initialize the Hitbox
            hitbox.Initialize(.5f, Damage, effectComponent, _secondEffectComponent);
        }

        public override string ToString()
        {
            return string.Format("Serrated Dagger Initialized. Attack Speed = {0}, Damage = {1}!", AttackSpeed, Damage);
        }
    }
}