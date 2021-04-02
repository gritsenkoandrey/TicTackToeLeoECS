using UnityEngine;

namespace TicToe
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        public int levelWidth = 3;
        public int levelHeight = 3;
        public int chainLength = 3;

        public CellView cellView;
        public Vector2 offset;
        public SignView crossView;
        public SignView zeroView;
    }
}