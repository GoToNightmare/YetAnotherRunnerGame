using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Assertions;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.Map
{
    public class Map : MonoBehaviour, IGameplayObject
    {
        [SerializeField]
        private int pathLength = 10;


        /// <summary>
        /// `MapElement` prefabs
        /// </summary>
        [SerializeField]
        private List<AssetReference> mapElementsAddressables = new List<AssetReference>();


        private readonly List<Vector3> allNodesLeft = new List<Vector3>();
        private readonly List<Vector3> allNodesMiddle = new List<Vector3>();
        private readonly List<Vector3> allNodesRight = new List<Vector3>();


        private readonly List<GameObject> instantiatedObjects = new List<GameObject>();


        public async UniTask Init()
        {
            Assert.IsFalse(pathLength <= 0, "Path should be > 0");


            Vector3 lastSpawnPosition = Vector3.zero;
            for (int i = 0; i < pathLength; i++)
            {
                var newRandomMapElement = GetRandomMapElement();
                AsyncOperationHandle<GameObject> newMapElement = newRandomMapElement.InstantiateAsync(transform, true);
                await newMapElement;

                var resultObj = newMapElement.Result;
                if (resultObj == null)
                {
                    throw new NullReferenceException($"Result object is null.\nIndex: {i}\n");
                }

                instantiatedObjects.Add(resultObj);
                if (!resultObj.TryGetComponent(out MapElement newElement))
                {
                    throw new Exception($"Incorrect prefab, suppose to have `MapElement` type.\nIndex: {i}\n");
                }

                // TODO add rotation based on map piece, if it has turns
                Vector3 enter = newElement.attachPointEnter.localPosition;
                Vector3 exit = newElement.attachPointExit.localPosition;

                Vector3 enterOffset = lastSpawnPosition - enter;

                Vector3 start = lastSpawnPosition + enterOffset;
                Vector3 end = lastSpawnPosition + exit;

                newElement.transform.localPosition = start;
                lastSpawnPosition = end;


                var nodes = newElement.allNodes;
                var leftNodesList = nodes.left.nodesList;
                var middleNodesList = nodes.middle.nodesList;
                var rightNodesList = nodes.right.nodesList;


                AddNodes(leftNodesList, allNodesLeft);
                AddNodes(middleNodesList, allNodesMiddle);
                AddNodes(rightNodesList, allNodesRight);
            }


#if UNITY_EDITOR
            DrawDebugLine();
#endif
        }


        private void DrawDebugLine()
        {
            var debugNodes = allNodesMiddle;
            var total = debugNodes.Count;

            for (int j = 0; j < total; j++)
            {
                float pct = (float)j / total;
                var colorLerp = Color.Lerp(Color.green, Color.red, pct);

                var thisNodePos = debugNodes[j];
                var nextNodePos = thisNodePos;

                var nextIndex = j + 1;
                if (nextIndex >= total)
                {
                    // Last element
                }
                else
                {
                    nextNodePos = debugNodes[nextIndex];
                }

                Debug.DrawLine(thisNodePos, nextNodePos, colorLerp, 100);
            }
        }


        private void AddNodes(List<Transform> nodesList, List<Vector3> nodePositions)
        {
            for (int j = 0; j < nodesList.Count; j++)
            {
                var element = nodesList[j];
                nodePositions.Add(element.position);
            }
        }


        private AssetReference GetRandomMapElement()
        {
            return mapElementsAddressables.TakeRandomElementInRangeOfCollection();
        }


        public async UniTask CustomEnable()
        {
        }


        public async UniTask CustomDisable()
        {
            var spawnedObjects = instantiatedObjects;
            foreach (var obj in spawnedObjects)
            {
                Addressables.ReleaseInstance(obj);
            }

            spawnedObjects.Clear();
        }


        public void Reset()
        {
        }
    }
}