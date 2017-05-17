using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Knockback Effect
*   </summary>
*/

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "Knockback Effect", menuName = "Catalyst System/Effects/Knockback")]
    public class EffectComponentKnockback : EffectComponent
    {
        [Header("Knockback Modifiers")]
        [SerializeField] private float _knockbackPower;
        public override void Effect(float damage, AgentController agentController)
        {
            agentController.TakeDamage(damage);
            //agentController.Knockback(_knockbackPower);
        }
    }
}