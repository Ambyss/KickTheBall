using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    private Vector3 _startPoint;

    private void Start()
    {
        _startPoint = transform.position;
    }
}
