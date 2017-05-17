using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField]private float _health;
    public float MovementSpeed;

    [Header("Prefabs")]
    public GameObject ProjectilePrefab;

    private float _movementSpeedNormal;

    private float _slowCounter;
    private int _movementIndex;

    private AgentMovement _agentMovement;

    private void Start()
    {
        _movementSpeedNormal = MovementSpeed;
        _agentMovement = GetComponent<AgentMovement>();
    }

    void Update()
    {
        _slowCounter -= Time.deltaTime;
        if (_slowCounter <= 0 && MovementSpeed != _movementSpeedNormal)
        {
            MovementSpeed = _movementSpeedNormal;
        }
        _movementIndex = _agentMovement.DirectionIndex;

        if (_health <= 0)
        {
        }
    }

    #region Incoming Effects
    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    public void TakeDamage(float damage, float range)
    {
        var collisions = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (var col in collisions)
        {
            if (col.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<AgentController>().TakeDamage(damage, Color.cyan);
            }
        }
    }

    public void TakeDamage(float damage, Color color)
    {
        _health -= damage;
    }

    public void DotDamage(float damage)
    {
        _health -= damage;
    }

    public void SlowMovement(float amount, float duration)
    {
        if (_slowCounter <= 0)
        {
            _slowCounter = duration;
            MovementSpeed -= amount;
        }
        else
        {
            _slowCounter = duration;
            MovementSpeed = _movementSpeedNormal - amount;
        }
    }

    public void SlowMovement(float amount)
    {
        MovementSpeed -= amount;
        _movementSpeedNormal = MovementSpeed;
    }


    #endregion

    #region Outgoing Effects

    public void Shoot(Vector2 direction, float damage)
    {
    }
    #endregion
}
