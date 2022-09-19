using TMPro;
using UnityEngine;
using VRLogConsole.Scripts.Properties.Base;

namespace VRLogConsole.Scripts.Properties.FollowCamera
{
    public class CameraProperties : PropertiesBehaviour
    {
        public Camera cameraToFollow;
        public Canvas canvas;
        public Transform consoleTransform;
        public TextMeshProUGUI positionText;

        private void Update()
        {
            if (GameObject.Find("CenterEyeAnchor"))
            {
                this.cameraToFollow = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
            }
        }
    }
}
