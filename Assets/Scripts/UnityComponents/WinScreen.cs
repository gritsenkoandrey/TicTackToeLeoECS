using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicToe
{
    public class WinScreen : Screen
    {
        public Text text;

        public void SetWinner(SignType type)
        {
            switch (type)
            {
                case SignType.Cross:
                    text.text = "Winner is... Cross";
                    break;
                case SignType.Zero:
                    text.text = "Winner is... Zero";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}