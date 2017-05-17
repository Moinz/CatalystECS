using UnityEngine;

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "AOE Effect", menuName = "Catalyst System/Effects/AOE")]
    public class EffectComponentAoe : EffectComponent
    {
        [Header("Area of Effect Modifiers")]
        [SerializeField] private float _aoeRadius;

        public override void Effect(float damage, AgentController agentController)
        {
            agentController.TakeDamage(damage, _aoeRadius);
        }
    }
}
