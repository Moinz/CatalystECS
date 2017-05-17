using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Interface for on hit effects
*   </summary>
*/

namespace CatalystSystem.Interfaces
{
    public interface IEffectComponent
    {
        void Effect(float damage, AgentController agentController);
    }
}