using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorCards
{
    public class Settings : MonoBehaviour
    {
        [Range(2, 5)] public int rowLength = 4;
        [Range(2, 4)]public int columnLength = 2;

        public Color[] colorList = new Color[10];
    }
}