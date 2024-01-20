using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Plane))]
public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;

    public event Action<int> ChangingScore;

    public void AddScore()
    {
        _score++;
        ChangingScore?.Invoke(_score);
    }

    public void Reset()
    {      
        _score = 0;
        ChangingScore?.Invoke(_score);
    }
}
