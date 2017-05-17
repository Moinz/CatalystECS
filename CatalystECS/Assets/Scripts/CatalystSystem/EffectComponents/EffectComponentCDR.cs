using UnityEngine;

namespace CatalystSystem.EffectComponents
{
    [CreateAssetMenu(fileName = "CDR Effect", menuName = "Catalyst System/Effects/CDR")]
    public class EffectComponentCDR : EffectComponent
    {
        [Header("Cooldown Reduction Modifiers")]
        [SerializeField, Tooltip("The amount of cooldown reduction. ! Number from 0 to 1 !")] private float _reductionAmount;
        [SerializeField, Tooltip("Choose the Cooldown that it reduces")] private CooldownType _cooldownType;
        [SerializeField] private float _reductionTime;
        private enum CooldownType { Cantrip, Catalyst, Cloak, Ultimate }

        public override void Effect(float damage, AgentController agentController)
        {
            agentController.TakeDamage(damage);
            switch (_cooldownType)
            {
                case CooldownType.Cantrip:
                    {
                        //TempPlayerController.Instance.cantripCDR = 1 - _reductionAmount;
                        //TempPlayerController.Instance.CDRTimer = _reductionTime;
                    }
                    break;

                case CooldownType.Catalyst:
                    {
                        //TempPlayerController.Instance.catalystCDR = 1 - _reductionAmount;
                        //TempPlayerController.Instance.CDRTimer = _reductionTime;
                    }
                    break;

                case CooldownType.Cloak:
                    {
                        //TempPlayerController.Instance.cloakCDR = 1 - _reductionAmount;
                        //TempPlayerController.Instance.CDRTimer = _reductionTime;
                    }
                    break;

                case CooldownType.Ultimate:
                    {
                        //TempPlayerController.Instance.ultimateCDR = 1 - _reductionAmount;
                        //TempPlayerController.Instance.CDRTimer = _reductionTime;
                    }
                    break;
            }
        }
    }
}
