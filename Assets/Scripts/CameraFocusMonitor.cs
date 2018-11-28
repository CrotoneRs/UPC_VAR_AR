/* Unity Usings */
using UnityEngine;

/* Other Usings */
using Vuforia;

namespace Assets.Scripts
{
    public class CameraFocusMonitor : MonoBehaviour
    {
        public void Start()
        {
            VuforiaARController vuforiaController = VuforiaARController.Instance;

            vuforiaController.RegisterVuforiaStartedCallback(OnVuforiaStarted);
            vuforiaController.RegisterOnPauseCallback(OnPaused);
        }

        private void OnVuforiaStarted()
        {
            /* TODO: Play With This Setting */
            CameraDevice.Instance.SetFocusMode(
                CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        }

        private void OnPaused(bool isPaused)
        {
            if (!isPaused)
            {
                /* Set again autofocus mode when app is resumed */
                CameraDevice.Instance.SetFocusMode(
                   CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
            }
        }
    }
}
