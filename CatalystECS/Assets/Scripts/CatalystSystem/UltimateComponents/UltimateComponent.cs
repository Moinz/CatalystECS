using CatalystSystem.Interfaces;
using CrimsonCouncil.Moin.Catalyst;
using Interfaces;
using UnityEngine;
/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	The base class for the Ultimate Spells
*   </summary>
*/

namespace CatalystSystem.UltimateComponents
{
    [CreateAssetMenu(fileName = "Ultimate Component", menuName = "Catalyst System/Ultimates/Basic")]
    public class UltimateComponent : ScriptableObject, IUltimateComponent, IWeighted, IValued
    {
        [SerializeField] private int _weight;
        [SerializeField] private int _value;

        public virtual void Ultimate(Vector3 position)
        {
            Debug.Log("Ultimate Spell: " + position.ToString());
        }

        public virtual void Initialize(int points)
        {
            name = "Balthazar's " + this.ToString();
        }

        public override string ToString()
        {
            return "Ultimate Spell";
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