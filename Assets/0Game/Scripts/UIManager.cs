
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _endUI;
    [SerializeField] private TMP_Text _updateMaxTimeText;
    public void MaxTimeTextUpdate()
    {
        _updateMaxTimeText.text = "Maksimum Süre : \n" + _timer.CountdownMaxValue.ToString();
        _updateMaxTimeText.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void EndingTextUI()
    {
        _endUI.SetActive(true);
        _timer.gameObject.SetActive(false);
    }
}/**/
