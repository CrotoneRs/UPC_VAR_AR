/*
    File Defines Reset Appearance On Lost Script
*/

/* Unity Usings */
using UnityEngine;

/* Other Usings */
using Vuforia;

namespace Assets.Scripts
{
    public class SceneMonitor : MonoBehaviour
    {
        public void ProceedLost(TrackableBehaviour listSceneElement)
        {
            listSceneElement.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            listSceneElement.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
    }
}
