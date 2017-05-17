using UnityEngine;

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "Slow Effect", menuName = "Catalyst System/Effects/Slow")]
    public class EffectComponentSlow : EffectComponent
    {
        [Header("Slow Modifiers")]
        [SerializeField] private float _slowPower;
        [SerializeField] private float _slowDuration;

        public override void Effect(float damage, AgentController agentController)
        {
            agentController.TakeDamage(damage);
            agentController.SlowMovement(_slowPower, _slowDuration);
        }
    }
}
