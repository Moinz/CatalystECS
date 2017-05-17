using UnityEngine;

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "DamageOverTime Effect", menuName = "Catalyst System/Effects/DOT")]
    public class EffectComponentDot : EffectComponent
    {
        [Header("Damage over Time Modifiers")]
        [SerializeField, Tooltip("Prefab for the DOT")] DamageOverTime _dotPrefab;
        [SerializeField, Tooltip("Duration of the Dot")] private float _damageTime;
        [SerializeField, Tooltip("The percentage of damage dealt. Value from 0 to 1")] private float _damageRatio;
        [SerializeField, Tooltip("Amount of times the Damage is dealt")] private int _damageTicks;

        public override void Effect(float damage, AgentController agentController)
        {
            DamageOverTime temp = Instantiate(_dotPrefab, agentController.transform.position, Quaternion.identity);
            temp.Initialize(agentController, damage, _damageRatio, _damageTime, _damageTicks);
            temp.transform.parent = agentController.transform;
        }
    }
}
