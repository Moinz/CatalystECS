using System.Collections;
using CatalystSystem.EffectComponents;
using CatalystSystem.PathComponents;
using CatalystSystem.Projectiles;
using CatalystSystem.UltimateComponents;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Implementation of the Spellbook
*   </summary>
*/

namespace CatalystSystem
{
    public class SpellBook : MonoBehaviour
    {
        [Header("Main Components")]
        [SerializeField] private PathComponent _pathComponent;
        [SerializeField] private UltimateComponent _ultimateComponent;
        [SerializeField] private EffectComponent _effectComponent;
        [SerializeField] private Projectile _projectile;

        public int Points;
        [PreviewSprite] public Sprite Icon;

        private void Start()
        {
            GenerateSpellbook();
        }

        void GenerateSpellbook()
        {
            _pathComponent = SeedManager.Instance.GetPathComponent(Points);
            Points -= _pathComponent.Value;
            _pathComponent.Initialize();

            _projectile = SeedManager.Instance.GetProjectileComponent(Points);
            Points -= _projectile.Value;
            Icon = _projectile.Icon;

            _ultimateComponent = SeedManager.Instance.GetUltimateComponent(Points);
            Points -= _ultimateComponent.Value;

            _effectComponent = SeedManager.Instance.GetEffectComponent(Points);
            Points -= _ultimateComponent.Value;
        }

        public void CastSpell()
        {
            StartCoroutine("DelayedSpell");
        }

        public void CastUltimate()
        {
            _ultimateComponent.Ultimate(Input.mousePosition);
        }

        private IEnumerator DelayedSpell()
        {
            yield return new WaitForSeconds(0.75f);
            //_pathComponent.Fire(PlayerMovement.PlayerDirectionIndex, transform.position, _projectile, _effectComponent);
        }
    }
}