using UnityEngine;

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "Lifesteal Effect", menuName = "Catalyst System/Effects/Lifesteal")]
    public class EffectComponentLifeSteal : EffectComponent
    {
        [Header("Lifesteal Modifiers")]
        [SerializeField, Tooltip("The chance of stealing life")] private float _lifestealChance;
        [SerializeField, Tooltip("The Percentage of the damage that gets stolen")] private float _lifestealPercent;

        public override void Effect(float damage, AgentController agentController)
        {
            agentController.TakeDamage(damage, Color.yellow);
            var r = Random.value;
            if (r <= _lifestealChance)
            {
                //TempPlayerController.Instance.healthCurrent += damage * _lifestealPercent;
            }
        }
    }
}
