using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentController), typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private AgentController _agentController;
    private int _directionIndex;

    private float _movementSpeed;

    public int DirectionIndex { get { return _directionIndex; } }
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _agentController = GetComponent<AgentController>();
        _directionIndex = 1;
    }

    private void Update()
    {
        _movementSpeed = _agentController.MovementSpeed;
    }
    public void UpdateDirection(int direction)
    {
        if (direction != 0)
        {
            _directionIndex = ConstantVectors.HandleIndex(direction);
            Move();
        }

        if (direction == 0)
            Stop();
    }

    private void Move()
    {
        _rigidbody2D.velocity = (ConstantVectors.Directions[_directionIndex] * _movementSpeed);
    }

    public void Stop()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    public void Push(Vector2 direction, float force)
    {
        var tempDirection = direction * force;
        _rigidbody2D.AddForce(tempDirection, ForceMode2D.Impulse);
    }
}
