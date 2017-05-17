using System.Collections;
using CatalystSystem.EffectComponents;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Interface for Projectile
*   </summary>
*/

namespace CatalystSystem.Interfaces
{
    public interface IProjectile 
    {
        void Launch(Vector2 direction);
        void Initialize(float damage, EffectComponent effectComponent);
    }
}
