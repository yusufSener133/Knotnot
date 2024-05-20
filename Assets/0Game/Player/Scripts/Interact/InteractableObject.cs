using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace Interact
{
    public class InteractableObject : MonoBehaviour, IIntrectable
    {
        [SerializeField] private GameObject _UI;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _interactionTime = 3f;
        [Header("Phase")]
        [SerializeField] private string _phaseText;
        [SerializeField] private int _addingTime;
        private bool _isInteracting = false;
        private float _currentInteractTime = 0f;

        private void Start()
        {
            _UI.gameObject.SetActive(false);
            _slider.gameObject.SetActive(false);
            _text.text = _phaseText;
            ResetPosition();
        }
        private void Update()
        {
            if (_isInteracting)
            {
                SliderHandler();
                if (_currentInteractTime >= _interactionTime)
                    InteractionCompleteHandler();
            }
        }
        private void SliderHandler()
        {
            _currentInteractTime += Time.deltaTime;
            _slider.value = _currentInteractTime / _interactionTime;
        }
        private void InteractionCompleteHandler()
        {
            Debug.Log("InteractionComplete");
            _isInteracting = false;
            _slider.value = 1f;
            ResetPosition();
            GameManager.Instance.IncreaseTime(_addingTime);
        }
        public void ResetInteraction()
        {
            _isInteracting = false;
            _currentInteractTime = 0f;
            _slider.value = 0f;
        }
        public void Interact(Transform senderTransform) // interacta ne yapacak
        {
            _slider.gameObject.SetActive(true);
            _isInteracting = true;
            Debug.Log("interact!!!" + name);
        }
        public void UIActive(bool activity)
        {
            _UI.SetActive(activity);
        }
        public Transform GetTransform() => transform;
        private void ResetPosition()
        {
            gameObject.transform.position = GameManager.Instance.NewSpawnPointHourglass();
            _UI.gameObject.SetActive(false);
            ResetInteraction();
        }
    }/**/
}