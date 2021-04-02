using UnityEngine;

namespace TicToe
{
    public class Screen : MonoBehaviour
    {
        public void Show(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}