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
            //Menzil kontrolü ile etraftaki colliderlerý algýladýk.
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out IIntrectable interactableObject)) // colliderlarýn içinde IIntrectable interfacesi var mý diye kontrol.
                {
                    interactableObject.UIActive(true); // toplanacak objenin ui aktifleþtirme
                    if (InputManager.Instance.PlayerInteractThisFrame()) // inputtan sonra yapýlacak iþlemler
                    {
                        interactableObject.Interact(transform);
                    }
                }
            }
            //Collider[] colliderArrayLong = Physics.OverlapSphere(transform.position, interactRange * 1.5f);
            //foreach (Collider collider in colliderArrayLong) // toplanacak objenin ui pasifleþtirme
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