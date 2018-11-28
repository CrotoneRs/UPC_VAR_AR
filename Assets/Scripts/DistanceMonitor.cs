/* Unity Usings */
using UnityEngine;

/* Other Usings */
using Vuforia;

/* System Usings */
using System.Linq;
using System.Collections.Generic;

/* App Usings */
using Assets.Scripts.Chemistry;

namespace Assets.Scripts
{
    public class DistanceMonitor : MonoBehaviour
    {
        public void Update()
        {
            /* Get the Vuforia's StateManager */
            StateManager vuforiaStateManager = TrackerManager.Instance.GetStateManager();

            /* Query the StateManager to Retrieve the List of Currently 'ACTIVE' Markers */
            List<TrackableBehaviour> activeTrackables = vuforiaStateManager.GetActiveTrackableBehaviours().ToList();

            foreach (var i in activeTrackables)
                Debug.Log(i.name);

            /* Get Chemistry Matches Instance */
            List<ChemistryMatches.ChemistryMatch> chemistryMatchesList = ChemistryMatches.Instance.ChemistryMatchesInstance;

            for (int i = 0; i < chemistryMatchesList.Count; i++)
            {
                for (int k = 0; k < chemistryMatchesList[i].Elements.Count; k++)
                {

                }
            }
        }
    }
}
