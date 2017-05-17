using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Base class for all Melee Effects
*   </summary>
*/

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "Critical Effect", menuName = "Catalyst System/Effects/Critical")]
    public class EffectComponentCritical : EffectComponent
    {
        [Header("Critical Modifiers")]
        [SerializeField] private float _criticalChance;
        [SerializeField] private float _criticalMultiplier;
        public override void Effect(float damage, AgentController agentController)
        {
            float tempDamage = damage;
            if (Random.value <= _criticalChance)
            {
                Debug.Log(tempDamage);
                tempDamage *= _criticalMultiplier;
            }
                

            agentController.TakeDamage(tempDamage, Color.yellow);
        }
    }
}