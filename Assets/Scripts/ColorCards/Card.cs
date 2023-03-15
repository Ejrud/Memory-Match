using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace ColorCards
{
    public class Card : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Color _riddledСolor;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Image _image;
        private Controller _controller;
        private bool _isHide;

        public void SetObserver(Controller controller)
        {
            _controller = controller;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_controller.IsDelay())
                return;

            _image.color = _riddledСolor;
            _controller.SelectCard(this);
        }

        public void SetColor(Color color)
        {
            _riddledСolor = color;
            HideColor();
        }

        public Color GetColor()
        {
            return _riddledСolor;
        }

        public void HideColor()
        {
            _image.color = _defaultColor;
            _isHide = true;
        }

        public bool IsHided()
        {
            return _isHide;
        }
    }
}