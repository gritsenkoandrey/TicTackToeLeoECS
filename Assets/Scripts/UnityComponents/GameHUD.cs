using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicToe
{
    public class GameHUD : MonoBehaviour
    {
        public Text text;

        public void SetTurn(SignType type)
        {
            switch (type)
            {
                case SignType.Cross:
                    text.text = "Turn Cross";
                    break;
                case SignType.Zero:
                    text.text = "Turn Zero";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}