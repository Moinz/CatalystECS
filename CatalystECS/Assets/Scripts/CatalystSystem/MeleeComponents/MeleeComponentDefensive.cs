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
    [CreateAssetMenu(fileName = "Defensive Melee", menuName = "Catalyst System/Melee/Defensive")]
    public class MeleeComponentDefensive : MeleeComponent
    {
        [Header("Defensive Stats")]
        [SerializeField] private float _defensivePercent;

        public override void Initialize()
        {
            //TempPlayerController.Instance.playerDefense = TempPlayerController.Instance.playerDefense - _defensivePercent;
            base.Initialize();
        }

        public override string ToString()
        {
            return string.Format("Winged Staff Initialized. Attack Speed = {0}, Damage = {1}, Defense Percent = {2}!", AttackSpeed, Damage, _defensivePercent);
        }
    }
}