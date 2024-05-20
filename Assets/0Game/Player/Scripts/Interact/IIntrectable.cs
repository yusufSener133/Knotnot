//using Item;
using UnityEngine;
namespace Interact
{
    public interface IIntrectable
    {
        void Interact(Transform senderTransform);
        void UIActive(bool activity);
        void ResetInteraction();
        Transform GetTransform();
    }/**/
}