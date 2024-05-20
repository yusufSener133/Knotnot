
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text _countdownText;
    private AudioSource _audioSource;
    [SerializeField] private float _countdownMaxValue = 30f;
    public float CountdownMaxValue { get => _countdownMaxValue; set => _countdownMaxValue = value; }

    private float _countdown;
    public float Countdown
    {
        get
        {
            return _countdown;
        }
    }

    private void Awake()
    {
        _countdown = _countdownMaxValue;
        _countdownText = GetComponent<TMP_Text>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (_countdown >= 0)
        {
            _countdown -= Time.deltaTime;
            _countdownText.text = _countdown.ToString("F2");
            if (_countdown <= 7)
            {
                _audioSource.volume = Mathf.Lerp(_audioSource.volume, 1, 0.001f);
            }
        }
    }
    public void CountDownReset()
    {
        _countdown = _countdownMaxValue;
        _audioSource.volume = 0.1f;
    }
    public void ResetTimer() => CountdownMaxValue = 30f;
}/**/
