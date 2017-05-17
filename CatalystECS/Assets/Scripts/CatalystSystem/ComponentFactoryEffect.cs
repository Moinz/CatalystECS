using UnityEngine;
using System.Collections.Generic;
using CatalystSystem.EffectComponents;

namespace CatalystSystem
{
    [CreateAssetMenu(fileName = "Effect Factory", menuName = "Catalyst System/Factories/Effect Factory")]
    public class ComponentFactoryEffect : ScriptableObject
    {
        [SerializeField] private List<EffectComponent>  _effectComponents;
//        [SerializeField] private List<EffectComponent> _effectComponentsInfernal;
//        [SerializeField] private List<EffectComponent> _effectComponentsPrimordial;
//        [SerializeField] private List<EffectComponent> _effectComponentsAbyssal;
//        [SerializeField] private List<EffectComponent> _effectComponentsCelestial;
//        [SerializeField] private List<EffectComponent> _effectComponentsTemporal;
//        [SerializeField] private List<EffectComponent> _effectComponentsSpectral;

        public EffectComponent GetEffectComponent(float randomValue, int points)
        {
            // Choose a random value
            var choice = randomValue * WeightedRandomization.CalculateTotalWeight(_effectComponents);

            // Choose a Melee Component from a Weighted Randomized list
            var temp = WeightedRandomization.Choose(_effectComponents, choice);

            // Check that we have enough points to get the component
            if (ValuedPurchase.ValidatePurchase(temp, points))
            {
                return temp;
            }

            // Find a new valid component
            temp = ValuedPurchase.FindValidPurchase(_effectComponents, points);
            return temp;
        }
    }
}
