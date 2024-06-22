using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Player
{
    public class PlayerCamera : IPlayerSystem
    {
        private Vector3 CameraOriginalPosition { get; set; }


        private readonly Vector3 cameraOffsetPos = new Vector3(0, 5, -8);


        private readonly Vector3 cameraOffsetRot = new Vector3(15, 0, 0);


        private UnityEngine.Camera CameraRef { get; set; }


        public void OnEnable(GameObject playerObj)
        {
            var camera = UnityEngine.Camera.main;
            Assert.IsNotNull(camera, "UnityEngine.Camera.main is null");
            CameraOriginalPosition = camera.transform.position;
            camera.transform.position = cameraOffsetPos;
            camera.transform.rotation = Quaternion.Euler(cameraOffsetRot.x, cameraOffsetRot.y, cameraOffsetRot.z);
            camera.transform.SetParent(playerObj.transform, true);
            CameraRef = camera;
        }


        public void OnDisable(GameObject playerObj)
        {
            var camera = CameraRef;
            if (camera != null)
            {
                camera.transform.SetParent(null);
                camera.transform.position = CameraOriginalPosition;
            }
        }
    }
}