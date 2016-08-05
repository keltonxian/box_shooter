using UnityEngine;
using System.Collections;

public class PopupTargetMover : MonoBehaviour {

	// define the possible states through an enumeration
	public enum motionDirections { Up, Float, UpFast };

	// store the state
	public motionDirections motionState = motionDirections.Up;

	// motion parameters
	public float motionMagnitude = 0.1f;

	// Update is called once per frame
	void Update () {

		// do the appropriate motion based on the motionState
		switch(motionState) {
		case motionDirections.Up:
			// rotate around the up axix of the gameObject
			gameObject.transform.Translate(Vector3.up * motionMagnitude);
			break;
		case motionDirections.Float:
			// move up and down over time
			gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude/2);
			break;
		case motionDirections.UpFast:
			// move up and down over time
			gameObject.transform.Translate(Vector3.up * motionMagnitude * 2);
			break;
		}
	}
}
