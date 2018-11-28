/*
    File Defines Base AtomScript For Recognition In Chemistry Metches
*/

using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Chemistry.Elements
{
    public class AtomScript: MonoBehaviour 
    {
        public static Dictionary<string, int> numElectrons = new Dictionary<string, int>(){
                                                {"CarbonAtom",6},
                                                {"HydrogenAtom",1},
                                                {"nytrogenAtom",7},
                                                {"OxygenAtom",8},
                                                {"PhosphorusAtom", 15},
                                                {"SiliconAtom",14},
                                                {"SodiumAtom",11},
                                                {"SulfurAtom",16}
        };

        public void Start(){

            string atom = this.name;
            int elNumber = numElectrons[atom];
            float radius = this.transform.lossyScale.x / 2;
            float distX = (radius * 2) + 1;
            float distZ = (radius * 2) + 1;
            for (int i = 0; i < elNumber; i++)
            {
                GameObject electron = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                electron.transform.parent = this.transform;
                float angle = (i / (elNumber / 2f)) * Mathf.PI; // Calculate the angle at which the element will be placed.
                                                                // For a semicircle, we would use (i / numNodes) * Math.PI.
                float x = ((radius + (distX / 2)) * Mathf.Cos(angle));// Calculate the x position of the element.
                float z = ((radius + (distX / 2)) * Mathf.Sin(angle)); // Calculate the z position of the element.

                electron.transform.localPosition = new Vector3(x,0,z);
                electron.transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);
                
            }
        }

        public void Update()
        {
            
        }


    }
}
