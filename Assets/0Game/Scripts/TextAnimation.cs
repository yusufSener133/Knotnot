using System.Collections;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    [Header("Assignments")]
    [SerializeField] private TMP_Text _storyLineText;
    [Header("Variables")]
    [SerializeField] private string _storyLines;
    [SerializeField, Range(0, 1)] private float _textSpeed = 0.1f;
    private void Awake()
    {
        _storyLineText = GetComponent<TMP_Text>();
    }
    private void OnEnable()
    {
        _storyLines = _storyLineText.text;
        _storyLineText.text = "";
    }
    private IEnumerator Start()
    {
        foreach (var item in _storyLines)
        {
            _storyLineText.text += item.ToString();
            yield return new WaitForSeconds(_textSpeed);
        }
    }
}/**/
