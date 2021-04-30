using UnityEngine;

namespace Managers
{
    public class CanvasCameraController : MonoBehaviour
    {
        private UnityEngine.Canvas canvas;

        private void Awake()
        {
            canvas = GetComponent<UnityEngine.Canvas>();
            // If camera which is used for rendering is different from main camera, Reference should be changed.
            var renderCamera = Camera.main;
            if (renderCamera)
                canvas.worldCamera = renderCamera;
        }
    }
}
