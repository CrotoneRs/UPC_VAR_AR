/*
    File Defines Up/Down and Rotation Movement Script
*/

/* Unity Usings */
using UnityEngine;

namespace Assets.Scripts.Chemistry.Elements
{
    public class AtomMoleculeMovement : MonoBehaviour
    {
        public void Update()
        {
            this.transform.localPosition = new Vector3(0, Mathf.PingPong(Time.time * 0.25f, 0.5f) + 0.30f, 0);

            for (int i = 0; i < this.transform.childCount; i++)
            {
                GameObject electron = this.transform.GetChild(i).gameObject;

                /* Use Simplifyed Schrodinger Equation To Get Orbit */
                electron.transform.RotateAround(this.transform.position, this.transform.TransformVector(Vector3.up), 40 * Time.deltaTime);
            }
        }
    }
}
