﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private RaycastHit _hit;
    private Ray _ray;
    private Ray _movingRay;
    private Camera _camera;
    private bool _isPlayerCatched;
    private LayerMask _fieldMask;
    private Vector3 _newPosition;
    private ForceController _forceController;
    
    private void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        _isPlayerCatched = false;
        _fieldMask = LayerMask.GetMask("Field");
        _forceController = GetComponent<ForceController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ThrowRay();
        if (Input.GetMouseButtonUp(0))
            _isPlayerCatched = false;
        
        if (_isPlayerCatched)
            MovePlayer();
    }

    private void ThrowRay()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.transform.CompareTag("Player")) 
                Catch();
        }
    }
    
    private void Catch()
    {
        _isPlayerCatched = true;
    }

    private void MovePlayer()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_ray, out _hit, 1000, _fieldMask);
        _newPosition = new Vector3(_hit.point.x, transform.position.y, _hit.point.z);
        if (_hit.transform.CompareTag("PlayerField"))
            transform.position = _newPosition;
        _forceController.SetArrowTransform();
    }
}
