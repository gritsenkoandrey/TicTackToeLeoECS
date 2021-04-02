using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicToe
{
    public class GameHUD : MonoBehaviour
    {
        [SerializeField] private Text _text = null;

        public void SetTurn(SignType type)
        {
            switch (type)
            {
                case SignType.Cross:
                    _text.text = "Turn Cross";
                    break;
                case SignType.Zero:
                    _text.text = "Turn Zero";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}