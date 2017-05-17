using UnityEngine;

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "Cripple Effect", menuName = "Catalyst System/Effects/Cripple")]
    public class EffectComponentCripple : EffectComponent
    {
        [Header("Cripple Modifiers")]
        [SerializeField] private float _cripplePower;

        public override void Effect(float damage, AgentController agentController)
        {
            agentController.TakeDamage(damage);
            agentController.SlowMovement(_cripplePower);
        }
    }
}
