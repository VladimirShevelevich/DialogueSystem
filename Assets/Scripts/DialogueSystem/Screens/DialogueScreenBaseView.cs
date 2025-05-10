using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public abstract class DialogueScreenBaseView : MonoBehaviour
    {
        protected void Show()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(1, 0.5f);
        }

        protected void Hide()
        {
            transform.DOScale(0, 0.3f).OnComplete(() =>
            {
                OnHidden();
            });
        }

        protected abstract void OnHidden();
    }
}