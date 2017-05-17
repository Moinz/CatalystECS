using System;
using CatalystSystem.EffectComponents;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Balthazar's Sword
*   </summary>
*/

namespace CatalystSystem.MeleeComponents
{
    [CreateAssetMenu(fileName = "Balthazar's Bane", menuName = "Catalyst System/Melee/Balthazar's Bane")]
    public class MeleeComponentBalthazars : MeleeComponent
    {
        [Header("Balthazar's Modifyable Stats")]
        [SerializeField] private float _healthScalePercent;
        [SerializeField] private bool _inverted;
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

            var tempDamage = 0f;
            if (_inverted)
            {
                //tempDamage += Damage + (_healthScalePercent * TempPlayerController.Instance.healthCurrent);
            }
            else
            {
                //tempDamage += Damage + (TempPlayerController.Instance.healthCurrent / _healthScalePercent);
            }

            // Initialize the Hitbox
            hitbox.Initialize(.5f, tempDamage, effectComponent);
        }

        public override string ToString()
        {
            return string.Format("Melee Component Stick Initialized. Attack Speed = {0}, Damage = {1}, Health Scale {2}!", AttackSpeed, Damage, _healthScalePercent);
        }
    }
}