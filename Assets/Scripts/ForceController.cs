using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    private Transform _arrowTransform;
    [SerializeField] private GameObject _ball;
    private Transform _ballTransform;

    private void Start()
    {
        _arrowTransform = _arrow.GetComponent<Transform>();
        _ballTransform = _ball.GetComponent<Transform>();
    }

    public void SetArrowTransform()
    {
        
    }
}
