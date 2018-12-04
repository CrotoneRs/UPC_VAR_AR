/*
    File Defines Reset Appearance On Lost Script
*/

/* Unity Usings */
using System.Collections.Generic;

/* Unity Usings */
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
                    GameObject gameObject = this.MoleculeDependencies[listSceneElement.name][i].transform.Find("GameObject").gameObject;

                    for (int k = 0; k < gameObject.transform.childCount; k++)
                        gameObject.transform.GetChild(k).gameObject.SetActive(false);

                    gameObject.transform.Find("Atom").gameObject.SetActive(true);
                    
                    string subAtomName = this.MoleculeDependencies[listSceneElement.name][i].name.Split('_')[0];
                    gameObject.transform.Find("Atom").gameObject.transform.Find(subAtomName + "Atom").position = Vector3.zero;
                }

                this.MoleculeDependencies.Remove(listSceneElement.name);
            }

            GameObject gameObjectMain = listSceneElement.transform.Find("GameObject").gameObject;

            for (int k = 0; k < gameObjectMain.transform.childCount; k++)
                gameObjectMain.transform.GetChild(k).gameObject.SetActive(false);

            gameObjectMain.transform.Find("Atom").gameObject.SetActive(true);

            string subAtomNameMain = listSceneElement.name.Split('_')[0];
            gameObjectMain.transform.Find("Atom").gameObject.transform.Find(subAtomNameMain + "Atom").position = Vector3.zero;
        }

        public void AddMolecule(List<DistanceMonitor.ActiveWithEnum> molecules)
        {
            this.MoleculeDependencies.Add(molecules[1].Active.name,
                new List<TrackableBehaviour>() { molecules[0].Active, molecules[2].Active });
        }
    }
}
