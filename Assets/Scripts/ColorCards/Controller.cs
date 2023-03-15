using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorCards
{
    [RequireComponent(typeof(Settings))]
    [RequireComponent(typeof(Table))]

    public class Controller : MonoBehaviour
    {
        [SerializeField] private Table _table;
        [SerializeField] private Settings _settings;

        private Card[] _selectedCards = new Card[2];
        private int _selectIndex = 0;
        private bool _isDelay;

        [ContextMenu("CreateCards")]
        public void CreateCards()
        {
            _table.CreateCards();
        }

        public bool IsDelay()
        {
            return _isDelay;
        }

        public void SelectCard(Card card)
        {
            _selectedCards[_selectIndex] = card;
            _selectIndex++;

            if (_selectIndex <= 1)
                return; 

            _isDelay = true;
            _selectIndex = 0;
            StartCoroutine(IsSameColor());
        }

        private IEnumerator IsSameColor()
        {
            yield return new WaitForSeconds(1f);

            if (_selectedCards[0].GetColor() == _selectedCards[1].GetColor())
            {
                _selectedCards[0].gameObject.SetActive(false);
                _selectedCards[1].gameObject.SetActive(false);
                _selectedCards = new Card[2];
            }
            else
            {
                foreach (Card card in _selectedCards)
                {
                    card.HideColor();
                }
            }

            _isDelay = false;

            yield return null;
        } 
    }
}