using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveCube : MonoBehaviour
{

	CubeColor cc;

	void Start(){
		cc = GameObject.Find("ChangeColors").GetComponent<CubeColor>();
		if (!cc) {
			Debug.LogError ("Cannot find game object in scene 'ChangeColors'");
		}
	}

    // Update is called once per frame
    private void Update()
    {
		if (gameObject.GetComponent<CubeColor> ().selectedCube != -1) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				int currentCube = gameObject.GetComponent<CubeColor> ().selectedCube;
				GameObject cube = cc.listOfCubeData[currentCube].cube;
				cube.transform.Translate (new Vector3 (0, 1, 0));
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				int currentCube = gameObject.GetComponent<CubeColor> ().selectedCube;
				GameObject cube = cc.listOfCubeData[currentCube].cube;
				cube.transform.Translate (new Vector3 (0, -1, 0));
			}
		}
	}
}