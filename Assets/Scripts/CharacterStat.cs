using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat: MonoBehaviour
{
    public float Min;
    public float Max;

    private float _current;
    private float _currentPercent;

    public CharacterStat(float min, float max, float current)
    {
        Max = max;
        Min = min;
        Current = current;
    }

    public float Current {
        set
        {
            var tmp = Mathf.Clamp(value,Min,Max);
            var valueChange = Mathf.Abs(tmp - _current);
            foreach (var change in OnDeltaValueLargerThan)
            {
                if (valueChange > change.Key)
                {
                    change.Value.Invoke(this,null);
                }
            }
            _current = tmp;
            _currentPercent = (_current - Min) / (Max - Min);
            foreach (var percent in OnDecreaseToPercent)
            {
                if (_currentPercent < percent.Key)
                {
                    percent.Value.Invoke(this,null);
                }
            }
        }

        get => _current;
    }

    public List<KeyValuePair<float,EventHandler>> OnDecreaseToPercent;
    public List<KeyValuePair<float,EventHandler>> OnDeltaValueLargerThan;

    public void PeriodicChangePercent(float duration, float ratePerSecond, float deltaPercent)
    {
        if (deltaPercent < 0)
        {
            throw new Exception("CharacterStat | Percent value should be larger than 0");
        }

        StartCoroutine(PercentChangeE(duration, ratePerSecond, deltaPercent));
    }

    public void PeriodicChangeValue(float duration, float ratePerSecond, float deltaValue)
    {
        StartCoroutine(ValueChangeE(duration, ratePerSecond, deltaValue));
    }
    
    IEnumerator PercentChangeE(float duration, float ratePerSecond, float deltaPercent)
    {
        float timer = 0f;
        float interval = 1 / ratePerSecond;
        while (timer < duration)
        {
            Debug.Log("CharacterStat | PercentChangeE | Percent changed");
            Current *= (1 + deltaPercent);
            yield return new WaitForSeconds(interval);
            timer += interval;
        }
    }
    
    IEnumerator ValueChangeE(float duration, float ratePerSecond, float deltaValue)
    {
        float timer = 0f;
        float interval = 1 / ratePerSecond;
        while (timer < duration)
        {
            Debug.Log("CharacterStat | ValueChangeE | Value changed");
            Current += deltaValue;
            yield return new WaitForSeconds(interval);
            timer += interval;
        }
    }
}
