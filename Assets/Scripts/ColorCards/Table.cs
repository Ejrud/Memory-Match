using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorCards
{
    public class Table : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Controller _cotroller;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private Settings _settings;


        [Header("Prefabs")]
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private GameObject _rowPrefab;


        private GameObject[] _rows = new GameObject[0];
        private Card[] _cards = new Card[0];


        public void UpdateColors()
        {
            System.Random rnd = new System.Random();
            Color cardColor = _settings.colorList[0];
            int colorIndex = 0;

            // Перемешивание карт
            for (int i = _cards.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                Card tempCard = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = tempCard;
            }

            for (int i = 0; i < _cards.Length; i++)
            {
                if (i % 2 == 0)
                {
                    cardColor = _settings.colorList[colorIndex];
                    colorIndex++;
                }

                _cards[i].SetColor(cardColor);
            }
        }

        // public bool IsCardsHided()
        // {

        // }

        public void CreateCards()
        {
            // Remove old columns
            if (_rows.Length != 0 && _rows[0] != null)
            {
                foreach (GameObject obj in _rows)
                    Destroy(obj);
            }

            // initialize columns cards
            _rows = new GameObject[_settings.rowLength];
            _cards = new Card[_settings.columnLength * _settings.rowLength];
            int counter = 0;

            for (int i = 0; i < _settings.rowLength; i++)
            {
                _rows[i] = Instantiate(_rowPrefab);
                _rows[i].transform.SetParent(_parentTransform.transform);
                _rows[i].transform.localScale = Vector3.one;

                for (int j = 0; j < _settings.columnLength; j++)
                {
                    _cards[counter] = Instantiate(_cardPrefab).GetComponent<Card>();
                    _cards[counter].transform.SetParent(_rows[i].transform);
                    _cards[counter].transform.localScale = Vector3.one;
                    _cards[counter].SetObserver(_cotroller);
                    counter++;
                }
            }

            UpdateColors();
        }
    }
}

