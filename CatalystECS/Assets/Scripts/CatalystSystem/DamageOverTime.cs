using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    private AgentController _agentController;
	private float _dotCounter;
    private float _dotAmount;
    private float _dotDamage;
    private int _maxTicks;
    private int _tickCounter;

    public void Initialize(AgentController target, float damage, float damagePercent, float duration, int ticks)
    {
        _agentController = target;
        _dotDamage = damage * damagePercent;
        _dotAmount = duration / ticks;
        _maxTicks = ticks;
        _tickCounter = 0;
        StartCoroutine(DOT());
    }

    private IEnumerator DOT()
    {
        while (gameObject)
        {
            yield return new WaitForSeconds(_dotAmount);
            _agentController.DotDamage(_dotDamage);
            _tickCounter += 1;

            if (_tickCounter >= _maxTicks)
            {
                Destroy(gameObject);
            }
        }
    }
}
