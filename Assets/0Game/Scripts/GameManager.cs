using Interact;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Timer _timer;
    [SerializeField] UIManager _uiManager;
    [SerializeField] Transform[] _spawnpoints;
    [SerializeField] Animator[] _lockers;
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }
    #endregion
    private bool _playerMove;
    public bool PlayerMove { get => _playerMove; }
    private float _lockOpenTime;
    private void Update()
    {
        LockOpenTime();
        NewDay();
    }
    public void NewDay()
    {
        if (_timer.Countdown <= 0)
        {
            if (_timer.CountdownMaxValue <= 60f)
                _timer.ResetTimer();
            _playerMove = false;
            _timer.CountDownReset();

            _lockOpenTime = 0;
            UpdateMaxTimeUI();
        }
        else
            _playerMove = true;
    }
    public void LockOpenTime()
    {
        _lockOpenTime += Time.deltaTime;
        if (_timer.CountdownMaxValue >= 60f && _lockOpenTime >= 60)
            StartCoroutine(GameEnding());
    }
    public void IncreaseTime(int time)
    {
        _timer.CountdownMaxValue += time;
        UpdateMaxTimeUI();
    }
    public void PhaseEnd(int value)
    {
        Debug.Log(value);
    }
    public IEnumerator GameEnding()
    {
        foreach (var locker in _lockers)
        {
            locker.SetTrigger("Open");
            yield return new WaitForSeconds(.5f);
        }
    }
    public Vector3 NewSpawnPointHourglass()
    {
        Transform go = _spawnpoints[Random.Range(0, _spawnpoints.Length)];
        Debug.Log(go.name);
        return go.position;
    }
    public void EndingUI() => _uiManager.EndingTextUI();
    public void UpdateMaxTimeUI() => _uiManager.MaxTimeTextUpdate();

}/**/
