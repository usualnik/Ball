using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Controls.MobileInputButtonType buttonType;

    public void OnPointerDown(PointerEventData eventData)
    {
        Controls.Instance.SetMobileInput(buttonType, true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Controls.Instance.SetMobileInput(buttonType, false);
    }
}