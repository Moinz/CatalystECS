using System.Collections.Generic;
using CatalystSystem.PathComponents;
using CatalystSystem.Projectiles;
using CatalystSystem.UltimateComponents;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Description Here
*   </summary>
*/

namespace CatalystSystem
{
    [CreateAssetMenu(fileName = "Spellbook Factory", menuName = "Catalyst System/Factories/Spellbook Factory")]
    public class ComponentFactorySpellbook : ScriptableObject
    { 
        [SerializeField] private List<PathComponent> _pathComponentsList;
        [SerializeField] private List<UltimateComponent> _ultimateComponentsList;
        [SerializeField] private List<Projectile> _projectilesList;

        public PathComponent GetPathComponent(float randomValue, int points)
        {
            // Choose a random value
            var choice = randomValue * WeightedRandomization.CalculateTotalWeight(_pathComponentsList);

            // Choose a random spellcomponent
            var temp = WeightedRandomization.Choose(_pathComponentsList, choice);

            // Check that we have enough points to get the component
            if (ValuedPurchase.ValidatePurchase(temp, points))
            {
                return temp;
            }

            // Find a new valid component
            temp = ValuedPurchase.FindValidPurchase(_pathComponentsList, points);
            return temp;
        }

        public Projectile GetProjectile(float randomValue, int points)
        {
            // Choose a random value
            var choice = randomValue * WeightedRandomization.CalculateTotalWeight(_projectilesList);

            // Choose a random spellcomponent
            var temp = WeightedRandomization.Choose(_projectilesList, choice);

            // Check that we have enough points to get the component
            if (ValuedPurchase.ValidatePurchase(temp, points))
            {
                return temp;
            }

            // Find a new valid component
            temp = ValuedPurchase.FindValidPurchase(_projectilesList, points);
            return temp;
        }

        public UltimateComponent GetUltimateComponent(float randomValue, int points)
        {
            // Choose a random value
            var choice = randomValue * WeightedRandomization.CalculateTotalWeight(_ultimateComponentsList);

            // Choose a random spellcomponent
            var temp = WeightedRandomization.Choose(_ultimateComponentsList, choice);

            // Check that we have enough points to get the component
            if (ValuedPurchase.ValidatePurchase(temp, points))
            {
                return temp;
            }

            // Find a new valid component
            temp = ValuedPurchase.FindValidPurchase(_ultimateComponentsList, points);
            return temp;
        }
    }
}
