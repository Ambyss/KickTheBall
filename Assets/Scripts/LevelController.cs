using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private int _currentLvl;
    [SerializeField] private GameObject[] _targets;
    private int _visibleTargets;
    [SerializeField] private GameObject _ball;
    private Vector3 _ballStartPosition;
    [SerializeField] private GameObject _enemy;
    private Vector3 _enemyStartPosition;
    private IEnumerator _lvlDuration;
    [SerializeField] private GameObject _LvlText;

    private void Start()
    {
        _currentLvl = 1;
        _visibleTargets = _targets.Length;
        _ballStartPosition = _ball.GetComponent<Transform>().position;
        _enemyStartPosition = _enemy.GetComponent<Transform>().position;
        _lvlDuration = LvlDuration();
        _LvlText.GetComponent<TextMesh>().text = _currentLvl.ToString();
    }

    private void NextLvl()
    {
        StopCoroutine("LvlDuration");
        _currentLvl++;
        _LvlText.GetComponent<TextMesh>().text = _currentLvl.ToString();
        _visibleTargets = 3;
        for (int i = 0; i < _visibleTargets; i++)
        {
            _targets[i].GetComponent<Target>().SetActive();
        }
        _enemy.GetComponent<Transform>().position = _enemyStartPosition;
        _enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _enemy.GetComponent<EnemyController>().SetSpeed(_currentLvl);
        UpdateBallPosition();
    }

    private void UpdateBallPosition()
    {
        _ball.GetComponent<Transform>().position = _ballStartPosition;
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameObject.FindWithTag("Player").GetComponent<ForceController>().IsBallThrowed = false;
    }
    
    public void UpdateLvl()
    {
        CatchBall();
        _enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        UpdateBallPosition();
    }

    public void HitTarget()
    {
        CatchBall();
        _visibleTargets--;
        if (_visibleTargets == 0)
            NextLvl();
        else
            UpdateLvl();
    }

    public void ThrowBall()
    {
        StartCoroutine("LvlDuration");
        _enemy.GetComponent<EnemyController>().IsCatchingBall = true;
    }

    public void CatchBall()
    {
        StopCoroutine("LvlDuration");
        _enemy.GetComponent<EnemyController>().IsCatchingBall = false;
    }
    
    IEnumerator LvlDuration()
    {
        yield return new WaitForSeconds(3);
        UpdateLvl();
    }
}
