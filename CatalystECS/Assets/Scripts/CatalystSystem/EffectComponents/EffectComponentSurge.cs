using UnityEngine;

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "Surge Effect", menuName = "Catalyst System/Effects/Surge")]
    public class EffectComponentSurge : EffectComponent
    {
        [Header("Surge Modifiers")]
        [SerializeField] private float _speedAmount;
        [SerializeField] private float _time;

        public override void Effect(float damage, AgentController agentController)
        {
            agentController.TakeDamage(damage);

            //PlayerMovement.Instance.MoveSpeed = PlayerMovement.Instance.MoveSpeedNormal + _speedAmount;
            //PlayerMovement.Instance._speedIncreaseCounter = _time;
        }
    }
}
