using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Interface for the Ultimate Spells
*   </summary>
*/

namespace CatalystSystem.Interfaces
{
    public interface IUltimateComponent
    {
        void Ultimate(Vector3 position);
        void Initialize(int points);
    }
}