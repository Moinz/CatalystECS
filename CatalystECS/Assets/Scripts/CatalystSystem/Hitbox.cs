using System.Collections;
using System.Collections.Generic;
using CatalystSystem.EffectComponents;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private float _damage;
    private EffectComponent _effectComponent;
    private EffectComponent _effectComponentTwo;
    private bool _expendedOne = false;
    private bool _expendedTwo = false;

    public bool Expended { get { return _expendedOne; }}
    private float _despawnTimer;
    public void Initialize(float size, float damage, EffectComponent effectComponent)
    {
        var tempVector = new Vector3(size, size, size);
        transform.localScale = tempVector;
        _damage = damage;
        _effectComponent = effectComponent;
        _despawnTimer = 1f;
    }
    public void Initialize(float size, float damage, EffectComponent effectComponent, EffectComponent effectComponentTwo)
    {
        var tempVector = new Vector3(size, size, size);
        transform.localScale = tempVector;
        _damage = damage;
        _effectComponent = effectComponent;
        _effectComponentTwo = effectComponentTwo;
        _despawnTimer = 1f;
    }

    private void Update()
    {
        _despawnTimer -= Time.deltaTime;

        if (_despawnTimer <= 0)
        {
            DestroySelf();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Collision");
            if (_effectComponent != null && !_expendedOne)
            {
                _effectComponent.Effect(_damage, other.gameObject.GetComponent<AgentController>());
                _expendedOne = true;
            }
            else
            {
                other.gameObject.GetComponent<AgentController>().TakeDamage(_damage);
            }
            if (_effectComponentTwo != null && !_expendedTwo)
            {
                _effectComponentTwo.Effect(_damage, other.gameObject.GetComponent<AgentController>());
                _expendedTwo = true;
            }
            DestroySelf();
        }

        if (other.CompareTag("Destructible"))
        {
            _expendedOne = true;
            DestroySelf();
        }
    }

    void DestroySelf()
    {
        Debug.Log("Destroyed Hitbox");
        Destroy(gameObject);
    }
}
