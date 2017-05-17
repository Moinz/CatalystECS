using System.Collections;
using CatalystSystem.EffectComponents;
using CatalystSystem.Interfaces;
using UnityEngine;
using Interfaces;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Base Projectile Script
*   </summary>
*/
namespace CatalystSystem.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Projectile : MonoBehaviour, IProjectile, IWeighted, IValued
    {
        [Header("Value and Weight")]
        [SerializeField] private int _weight;
        [SerializeField] private int _value;

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

        private bool _expended = false;
        private float _damage;
        protected Rigidbody2D rb2D;
        protected EffectComponent _effectComponent;

        [Header("Projectile Variables")]
        public float nativeForce;
        [PreviewSprite] public Sprite Icon;
        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        public virtual void Initialize(float damage, EffectComponent effectComponent)
        {
            _effectComponent = effectComponent;
            _damage = damage;
        }

        public virtual void Launch(Vector2 direction)
        {
            rb2D.AddForce(direction * nativeForce, ForceMode2D.Impulse);
            StartCoroutine(DespawnTimer(3f));
        }

        public void Rotate(int index)
        {
            if (index <= 2)
            {
                transform.localScale = new Vector3(1, 1, 1);
                return;
            }
            if (index <= 4)
            {
                transform.localScale = new Vector3(1, -1, 1);
                return;
            }
            if (index <= 6)
            {
                transform.localScale = new Vector3(-1, -1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        public virtual IEnumerator DespawnTimer (float seconds)
        {
            yield return new WaitForSeconds(seconds);

            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            if (!_expended && _effectComponent != null)
            {
                _effectComponent.Effect(_damage, other.gameObject.GetComponent<AgentController>());
                _expended = true;
                Destroy(gameObject);
            }
            else
            {
                other.gameObject.GetComponent<AgentController>().TakeDamage(_damage);
                _expended = true;
                Destroy(gameObject);
            }
        }
    }
}
