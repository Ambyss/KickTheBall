using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Ball;
    private LineRenderer _lineRenderer;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TestThis();
            
    }

    private void TestThis()
    {
        GameObject _ball = Instantiate(Ball, transform.position, Quaternion.identity);
        _ball.GetComponent<Rigidbody>().AddForce(new Vector3(-10, 0, 10), ForceMode.VelocityChange);

        Physics.autoSimulation = false;

        Vector3[] points = new Vector3[100];
        
        for (int i = 0; i < 100; i++)
        {
            Physics.Simulate(0.3f);
            points[i] = _ball.transform.position;
        }
        _lineRenderer.SetPositions(points);
        
        Physics.autoSimulation = true;
        Destroy(_ball);
    }
}
