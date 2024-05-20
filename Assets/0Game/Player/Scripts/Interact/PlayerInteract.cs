using System.Linq;
using UnityEngine;

namespace Interact
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private float interactRange = 2f;

        private void Update()
        {
            IteractingAction();
        }
        private void IteractingAction()
        {
            //Menzil kontrol� ile etraftaki colliderler� alg�lad�k.
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out IIntrectable interactableObject)) // colliderlar�n i�inde IIntrectable interfacesi var m� diye kontrol.
                {
                    interactableObject.UIActive(true); // toplanacak objenin ui aktifle�tirme
                    if (InputManager.Instance.PlayerInteractThisFrame()) // inputtan sonra yap�lacak i�lemler
                    {
                        interactableObject.Interact(transform);
                    }
                }
            }
            //Collider[] colliderArrayLong = Physics.OverlapSphere(transform.position, interactRange * 1.5f);
            //foreach (Collider collider in colliderArrayLong) // toplanacak objenin ui pasifle�tirme
            //{
            //    if (!colliderArray.Contains(collider) && collider.TryGetComponent(out IIntrectable interactableObject))
            //    {
            //        interactableObject.UIActive(false);
            //        interactableObject.ResetInteraction();
            //    }
            //}
        }
    }/**/
}