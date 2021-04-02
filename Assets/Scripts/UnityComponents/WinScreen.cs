using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicToe
{
    public class WinScreen : Screen
    {
        [SerializeField] private Text _text = null;
        [SerializeField] private Button _restartButton = null;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartClick);
        }

        public void SetWinner(SignType type)
        {
            switch (type)
            {
                case SignType.Cross:
                    _text.text = "And Winner is Cross";
                    break;
                case SignType.Zero:
                    _text.text = "And Winner is Zero";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}