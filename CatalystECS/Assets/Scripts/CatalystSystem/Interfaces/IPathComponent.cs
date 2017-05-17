using CatalystSystem.EffectComponents;
using CatalystSystem.Projectiles;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Interface for the Spell Components
*   </summary>
*/

namespace CatalystSystem.Interfaces
{
    public interface IPathComponent
    {
        float Damage { get; }
        float Cooldown { get; }
        void Fire(int directionIndex, Vector3 position, Projectile projectile, EffectComponent effectComponent);
        void Initialize();
    }
}