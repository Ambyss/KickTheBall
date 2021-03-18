using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crushEffect;
    public void CrushEffect()
    {
        Instantiate(_crushEffect, transform.position, Quaternion.identity);
    }
}
