using UnityEngine;
using System.Collections.Generic;
using CatalystSystem.CurseComponents;
using CatalystSystem.MeleeComponents;

namespace CatalystSystem
{
    [CreateAssetMenu(fileName = "Catalyst Factory", menuName = "Catalyst System/Factories/Catalyst Factory")]
    public class ComponentFactoryCatalyst : ScriptableObject
    {
        [SerializeField] private List<MeleeComponent> _meleeComponents;
        [SerializeField] private List<CurseComponent> _curseComponents;

        public List<MeleeComponent> MeleeComponents
        {
            get { return _meleeComponents; }
            private set { _meleeComponents = value; }
        }

        public MeleeComponent GetMeleeComponent(float randomValue, int points)
        {
            // Choose a random value
            var choice = randomValue * WeightedRandomization.CalculateTotalWeight(_meleeComponents);

            // Choose a Melee Component from a Weighted Randomized list
            var temp = WeightedRandomization.Choose(_meleeComponents, choice);

            // Check that we have enough points to get the component
            if (ValuedPurchase.ValidatePurchase(temp, points))
            {
                return temp;
            }

            // Find a new valid component
            temp = ValuedPurchase.FindValidPurchase(_meleeComponents, points);
            return temp;
        }

        public CurseComponent GetCurseComponent(float value)
        {
            var choice = value * WeightedRandomization.CalculateTotalWeight(_curseComponents);
            return WeightedRandomization.Choose(_curseComponents, choice);
        }
    }
}
