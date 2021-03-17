using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    private Transform _arrowTransform;
    [SerializeField] private GameObject _ball;
    private Transform _ballTransform;
    private Vector3 _orientation;
    [SerializeField] [Range(0, 500)] private int _ballSpeed;
    private Color _standartColor;
    private Color _transparentColor;
    private LevelController _levelController;
    public bool IsBallThrowed;
    
    private void Start()
    {
        _arrowTransform = _arrow.GetComponent<Transform>();
        _ballTransform = _ball.GetComponent<Transform>();
        _levelController = GameObject.FindWithTag("LvlController").GetComponent<LevelController>();
        IsBallThrowed = false;
        
        _standartColor = _arrow.GetComponentInChildren<SpriteRenderer>().color;
        _transparentColor = new Color(1, 1, 1, 0);
        _arrow.GetComponentInChildren<SpriteRenderer>().color = _transparentColor;
    }

    public void SetArrowTransform()
    {
        if (!IsBallThrowed)
        {
            _arrow.GetComponentInChildren<SpriteRenderer>().color = _standartColor;
            _orientation = (transform.position - _ballTransform.position);
            _arrowTransform.rotation = Quaternion.LookRotation(_orientation);
            _arrowTransform.localScale = _orientation.magnitude * Vector3.one * .3f;
        }
    }

    public void ThrowBall()
    {
        IsBallThrowed = true;
        _ball.GetComponent<Rigidbody>().AddForce(_orientation * _ballSpeed);
        _arrow.GetComponentInChildren<SpriteRenderer>().color = _transparentColor;
        _levelController.ThrowBall();
    }
}
