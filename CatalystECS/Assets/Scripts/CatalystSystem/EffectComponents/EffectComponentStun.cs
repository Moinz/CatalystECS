using UnityEngine;

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "Stun Effect", menuName = "Catalyst System/Effects/Stun")]
    public class EffectComponentStun : EffectComponent
    {
        [Header("Stun Modifiers")]
        [SerializeField] private float _stunTime;

        public override void Effect(float damage, AgentController agentController)
        {
            agentController.TakeDamage(damage);
            //agentController.Stun(_stunTime);
        }
    }
}
