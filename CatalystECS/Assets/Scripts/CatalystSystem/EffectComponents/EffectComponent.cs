using System;
using CatalystSystem.Interfaces;
using Interfaces;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Base Class for Spell Effects
*   </summary>
*/

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "Basic Effect", menuName = "Catalyst System/Effects/Basic")]
    public class EffectComponent : ScriptableObject, IEffectComponent, IWeighted, IValued
    {
        [Header("Value and Weight values")]
        [SerializeField]private int _weight;
        [SerializeField]private int _value;

        public virtual void Effect (float damage, AgentController agentController)
        {
            agentController.TakeDamage(damage);
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}