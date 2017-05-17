using System;
using CatalystSystem.EffectComponents;
using CatalystSystem.Interfaces;
using CatalystSystem;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CatalystSystem.MeleeComponents
{
    [CreateAssetMenu(fileName = "Basic Weapon", menuName = "Catalyst System/Melee/Basic")]
    public class MeleeComponent : ScriptableObject, IMeleeComponent, IWeighted, IValued
    {
        [Header("Attack Speed and Damage Ranges")]
        [SerializeField, MinMaxRange(0, 3)] RangedFloat _attackSpeedRange;
        [SerializeField, MinMaxRange(0, 10)] RangedFloat _attackDamageRange;

        [Header("Value and Weight")]
        [SerializeField] private int _weight;
        [SerializeField] private int _value;

        [Header("Hitbox")]
        [SerializeField] protected Hitbox HitboxPrefab;

        [Header("Sprites and Frame Information")]
        [SerializeField] private int _frameNumber;
        [SerializeField, PreviewSprite] private Sprite _icon;
        [SerializeField] private CatalystAttackType _attackType;

        private float _attackSpeed;
        private float _damage;

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public float AttackSpeed
        {
            get { return _attackSpeed; }
            protected set { _attackSpeed = value; }
        }

        public float Damage
        {
            get { return _damage; }
            protected set { _damage = value; }
        }

        public Sprite Icon { get { return _icon; } }
        public CatalystAttackType AttackType { get { return _attackType; } }
        public int FrameNumber { get { return _frameNumber; } }

        public virtual void Attack(int index, Vector3 position, EffectComponent effectComponent)
        {
            // Make sure the index is valid
            var tempIndex = ConstantVectors.HandleIndex(index);

            // Get direction and spawn the Hitbox
            Vector3 dir = position + (Vector3)ConstantVectors.Directions[tempIndex];
            Hitbox hitbox = Instantiate(HitboxPrefab, dir, Quaternion.identity);

            // Rotate the hitbox to face the player
            dir = hitbox.transform.position - position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 45;
            hitbox.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Initialize the Hitbox
            hitbox.Initialize(.5f, _damage, effectComponent);
        }

        public virtual void Initialize()
        {
            AttackSpeed = Random.Range(_attackSpeedRange.MinValue, _attackSpeedRange.MaxValue);
            Damage = Random.Range(_attackDamageRange.MinValue, _attackDamageRange.MaxValue);
        }

        public override string ToString()
        {
            return string.Format("Basic Melee Component Initialized. Attack Speed = {0}, Damage = {1}!", AttackSpeed, Damage);
        }

        public virtual void Initialize(int points)
        {
            for (int i = 0; i <= points; i++)
            {
                Damage += .05f;
            }
        }
    }
}