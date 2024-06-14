using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Core;
using UnityEngine;

namespace Game.Map
{
    public class Map : MonoBehaviour, IGameplayObject
    {
        public int pathLength = 50;


        [SerializeField]
        private List<MapElement> mapElementsVariantsPrefabs = new List<MapElement>();


        public async UniTask Init()
        {
            Vector3 lastSpawnPosition = Vector3.zero;
            for (int i = 0; i < pathLength; i++)
            {
                MapElement newRandomMapElement = GetRandomMapElement();
                MapElement newElement = Instantiate(newRandomMapElement, transform, true); // TODO add rotation based on map piece, if it has turns

                Vector3 enter = newElement.attachPointEnter.localPosition;
                Vector3 exit = newElement.attachPointExit.localPosition;

                Vector3 enterOffset = lastSpawnPosition - enter;

                Vector3 start = lastSpawnPosition + enterOffset;
                Vector3 end = lastSpawnPosition + exit;

                newElement.transform.localPosition = start;
                lastSpawnPosition = end;


#if UNITY_EDITOR
                Debug.DrawLine(start + Vector3.up, end + Vector3.up, Color.red);
#endif
            }
        }


        private MapElement GetRandomMapElement()
        {
            // TODO add random path generation
            return mapElementsVariantsPrefabs[0];
        }
    }
}