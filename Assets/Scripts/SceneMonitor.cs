/*
    File Defines Reset Appearance On Lost Script
*/

/* Unity Usings */
using System.Collections.Generic;
using UnityEngine;

/* Other Usings */
using Vuforia;

namespace Assets.Scripts
{
    public class SceneMonitor : MonoBehaviour
    {
        private Dictionary<string, List<TrackableBehaviour>> MoleculeDependencies { get; set; }

        public void Start() { this.MoleculeDependencies = new Dictionary<string, List<TrackableBehaviour>>(); }

        public void ProceedLost(TrackableBehaviour listSceneElement)
        {
            if (this.MoleculeDependencies.ContainsKey(listSceneElement.name))
            {
                for (int i = 0; i < this.MoleculeDependencies[listSceneElement.name].Count; i++)
                {
                    this.MoleculeDependencies[listSceneElement.name][i].transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    this.MoleculeDependencies[listSceneElement.name][i].transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                }

                this.MoleculeDependencies.Remove(listSceneElement.name);
            }
            else
            {
                listSceneElement.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                listSceneElement.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            }
        }

        public void AddMolecule(List<DistanceMonitor.ActiveWithEnum> molecules)
        {
            this.MoleculeDependencies.Add(molecules[1].Active.name,
                new List<TrackableBehaviour>() { molecules[0].Active, molecules[2].Active });
        }
    }
}
