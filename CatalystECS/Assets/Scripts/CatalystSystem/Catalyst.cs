using System.Collections;
using CatalystSystem.CurseComponents;
using CatalystSystem.EffectComponents;
using CatalystSystem.MeleeComponents;
using CrimsonCouncil.Moin.Catalyst;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	The Catalyst is the main component for the player
*   </summary>
*/

namespace CatalystSystem
{
    public class Catalyst : MonoBehaviour 
    {
        [Header("Main Components")]
        [SerializeField] private MeleeComponent _meleeComponent;
        [SerializeField] private EffectComponent _effectComponent;

        public float AttackSpeed;
        public float AttackDamage;
        [Tooltip("Points for Catalyst Generation")]public int Points;
        [PreviewSprite]public Sprite Icon;
        public int FrameIndex;
        public CatalystAttackType AttackType;
        private void Start ()
        {
            GenerateCatalyst();
        }

        private void GenerateCatalyst()
        {
            _meleeComponent = SeedManager.Instance.GetMeleeComponent(Points);
            if (_meleeComponent != null)
                Points -= _meleeComponent.Value;

            _effectComponent = SeedManager.Instance.GetEffectComponent(Points);
            if (_effectComponent != null)
                Points -= _effectComponent.Value;

            if (_meleeComponent != null)
            {
                _meleeComponent.Initialize();
                AttackSpeed = _meleeComponent.AttackSpeed;
                AttackDamage = _meleeComponent.Damage;
                Icon = _meleeComponent.Icon;
                FrameIndex = _meleeComponent.FrameNumber;
                _meleeComponent.Initialize(Points);
                AttackDamage = _meleeComponent.Damage;
                AttackType = _meleeComponent.AttackType;
                Points = 0;
            }
        }

        public void Attack ()
        {
            StartCoroutine("DelayedAttack");
        }

        private IEnumerator DelayedAttack()
        {
            var temp = 0f;
            if (AttackType == CatalystAttackType.Slash)
                temp = .4f;
            if (AttackType == CatalystAttackType.Stab)
                temp = .25f;

            yield return new WaitForSeconds(temp);
            //_meleeComponent.Attack(PlayerMovement.PlayerDirectionIndex, transform.position, _effectComponent);
        }
    }
}