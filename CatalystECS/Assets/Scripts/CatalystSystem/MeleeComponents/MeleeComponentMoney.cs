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
    [CreateAssetMenu(fileName = "Bling Hammer", menuName = "Catalyst System/Melee/Bling Hammer")]
    public class MeleeComponentMoney : MeleeComponent
    {
        [Header("Winged Staff Stats")]
        [SerializeField] private float _moneyScalePercent;
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

            //var tempDamage = Damage + (TempPlayerController.Instance.playerTrinsTotal / _moneyScalePercent);

            // Initialize the Hitbox
            hitbox.Initialize(.5f, 0f, effectComponent);
        }

        public override string ToString()
        {
            return string.Format("Bling Hammer Initialized. Attack Speed = {0}, Damage = {1}, MoneyScalePercent = {2}!", AttackSpeed, Damage, _moneyScalePercent);
        }
    }
}