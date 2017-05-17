using CatalystSystem.EffectComponents;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright � 2017 All Rights Reserved
*	
*	<summary>  
*   	The Interface for the Melee Components for the Catalyst
*   </summary>
*/

namespace CatalystSystem.Interfaces
{
    public interface IMeleeComponent
    {
        float AttackSpeed { get; }
        float Damage { get; }
        void Attack(int index, Vector3 position, EffectComponent effectComponent);
        void Initialize();
    }
}