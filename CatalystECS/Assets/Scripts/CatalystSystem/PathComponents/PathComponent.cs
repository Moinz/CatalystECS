using CatalystSystem.Interfaces;
using CatalystSystem.EffectComponents;
using CatalystSystem.Projectiles;
using Interfaces;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Description Here
*   </summary>
*/

namespace CatalystSystem.PathComponents
{
    [CreateAssetMenu(fileName = "Path Component", menuName = "Catalyst System/Paths/Basic")]
    public class PathComponent : ScriptableObject, IPathComponent, IValued, IWeighted
    {
        [Header("Damage and Cooldown Ranges")]
        [SerializeField, MinMaxRange(0, 20)] private RangedFloat _damageRangedFloat;
        [SerializeField, MinMaxRange(0, 5)] private RangedFloat _cooldownRangedFloat;

        [Header("Value and Weight")]
        [SerializeField] private int _value;
        [SerializeField] private int _weight;

        public int[] Directions;

        private float _damage;
        private float _cooldown;


        #region Properties

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public float Damage { get { return _damage; } protected set { _damage = value; } }
        public float Cooldown { get { return _cooldown; } protected set { _cooldown = value; } }
        #endregion

        #region Main

        public virtual void Fire(int directionIndex, Vector3 position, Projectile projectile, EffectComponent effectComponent)
        {
            foreach (var item in Directions)
            {
                int tempIndex = ConstantVectors.HandleIndex(directionIndex, item);

                // Get direction based on the handled index
                Vector2 direction = ConstantVectors.Directions[tempIndex];

                // Create the Projectile with the position based on the handled index
                Projectile tempProjectile = Instantiate(projectile, position + (Vector3)direction, Quaternion.identity);

                // Initalize the projectile with the needed information (Currently only a reference to the effectcomponent)
                tempProjectile.Initialize(Damage, effectComponent);

                // Rotate projectile
                direction = tempProjectile.transform.position - position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + (-45);
                tempProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                // Launch the projectile
                tempProjectile.Launch(ConstantVectors.Directions[tempIndex]);
            }
        }

        #endregion

        public virtual void Initialize()
        {
            _damage = Random.Range(_damageRangedFloat.MinValue, _damageRangedFloat.MaxValue);
            _cooldown = Random.Range(_cooldownRangedFloat.MinValue, _cooldownRangedFloat.MaxValue);
            Debug.Log(ToString());
        }

        #region Helper Scripts

        public override string ToString()
        {
            return string.Format("Path Component Basic Initialized. Cooldown = {0}, Damage = {1}!", Cooldown, Damage);
        }

        #endregion
    }
}