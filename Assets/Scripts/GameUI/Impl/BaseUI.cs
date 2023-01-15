using UnityEngine;
using UnityEngine.UI;

namespace GameUI.Impl
{
    public abstract class BaseUI : MonoBehaviour
    {
        [SerializeField] protected Canvas _canvas;
        [SerializeField] protected GraphicRaycaster _raycaster;

        protected bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                _canvas.enabled = value;
                _raycaster.enabled = value;
            }
        }

        public abstract void Show();
        public abstract void Hide();
    }
}