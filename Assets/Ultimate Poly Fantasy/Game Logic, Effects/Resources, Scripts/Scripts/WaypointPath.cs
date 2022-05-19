using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UltimatePolyFantasy {
public class WaypointPath : MonoBehaviour {

		public Color rayColor = Color.white;
		public List<Transform> pathPoints = new List<Transform> ();
		Transform[] theArray;

		void OnDrawGizmos()
		{
			Gizmos.color = rayColor;
			theArray = GetComponentsInChildren<Transform> ();
			pathPoints.Clear ();

			foreach (Transform pathPoint in theArray)
			{
				if (pathPoint != this.transform)
				{
					pathPoints.Add (pathPoint);
				}
			}
			for (int i = 0; i < pathPoints.Count; i++)
			{
				Vector3 position = pathPoints [i].position;
				if (i > 0)
				{
					Vector3 previous = pathPoints [i - 1].position;
					Gizmos.DrawLine (previous, position);
					Gizmos.DrawSphere (position, 0.4f);
				}
			}
		}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}
