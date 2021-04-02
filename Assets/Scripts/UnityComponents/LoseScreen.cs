using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicToe
{
    public class LoseScreen : Screen
    {
        [SerializeField] private Button _restartButton = null;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartClick);
        }

        private void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}