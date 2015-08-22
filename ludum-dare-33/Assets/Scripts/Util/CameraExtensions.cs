using UnityEngine;

namespace Util
{
    public static class CameraExtensions
    {
        public static Bounds OrthographicBounds(this Camera camera)
        {
            float screenAspect = (float)Screen.width / (float)Screen.height;
            var position = new Vector3(camera.transform.position.x, camera.transform.position.y, 0);
            float cameraHeight = camera.orthographicSize * 2;
            Bounds bounds = new Bounds(
                position,
                new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
            return bounds;
        }
    }
}
