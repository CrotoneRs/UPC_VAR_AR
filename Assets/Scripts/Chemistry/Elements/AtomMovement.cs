/*
    File Defines Up/Down and Rotation Movement Script
*/

/* Unity Usings */
using UnityEngine;

namespace Assets.Scripts.Chemistry.Elements
{
    public class AtomMovement : MonoBehaviour
    {

        float[] probField;
        public void Update()
        {
            this.transform.localPosition = new Vector3(0, Mathf.PingPong(Time.time * 0.25f, 0.5f) + 0.30f, 0);

            int numElectrons = this.transform.childCount;
            probField = new float[numElectrons];
            for (int i = 0; i < numElectrons; i++)
            {
                
                probField[i] = Random.Range(0, numElectrons-1);
                if (numElectrons == 1) probField[0] = 1;
            }
            
            
                for (int i = 0; i < numElectrons; i++)
            {
                GameObject electron = this.transform.GetChild(i).gameObject;

                /* Use Simplifyed Schrodinger Equation To Get Orbit */
                float possiblePosition = probField[Random.Range(0, numElectrons - 1)] * Mathf.Exp(-125 * Time.deltaTime);
                electron.transform.RotateAround(this.transform.position, this.transform.TransformVector(new Vector3(possiblePosition , possiblePosition , possiblePosition )), 125 * Time.deltaTime);
            }
        }
    }
}
