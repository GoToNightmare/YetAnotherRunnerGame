using System;
using UnityEngine;

namespace Game.Map
{
    public class MapElement : MonoBehaviour
    {
        [Serializable]
        public struct MapPaths
        {
            public Path left;
            public Path middle;
            public Path right;
        }


        /// <summary>
        /// TODO add rotation
        /// </summary>
        [SerializeField]
        public Transform attachPointEnter;


        /// <summary>
        /// TODO add rotation
        /// </summary>
        [SerializeField]
        public Transform attachPointExit;


        [SerializeField]
        public MapPaths allNodes;
    }
}