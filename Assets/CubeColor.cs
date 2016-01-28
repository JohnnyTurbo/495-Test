using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeColor : MonoBehaviour
{

    public int selectedCube = -1;
	public List<CubeData> listOfCubeData;
	int numberOfCubes;

	void Start(){

		GameObject[] cubesInScene;
		cubesInScene = GameObject.FindGameObjectsWithTag ("Cube");
		numberOfCubes = cubesInScene.Length;
		Debug.Log (numberOfCubes);
		listOfCubeData = new List<CubeData> ();
		CubeData newCube;

		for (int i = 0; i < numberOfCubes; i++) {
			newCube = new CubeData(cubesInScene[i]);
			listOfCubeData.Add (newCube);
		}

		ColorData cols = new ColorData();

		int iter = 0;
		foreach (CubeData cd in listOfCubeData) {
			cd.cube.GetComponent<Renderer>().material.color = cols.GetAColorToUse(iter % 5);
			iter++;
		}
	}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown ("Jump")) {
			Debug.Log (selectedCube);
			SetScaleOfCubes ();
		}
    }

    private void SetScaleOfCubes()
    {
		Debug.Log ("Sel Cub: " + selectedCube);
		if (selectedCube > -1) {
			listOfCubeData [selectedCube].cube.gameObject.transform.localScale = new Vector3 (1, 1, 1);
		}
		selectedCube++;
		if (selectedCube == numberOfCubes) {
			selectedCube = 0;
		}
		listOfCubeData [selectedCube].cube.gameObject.transform.localScale = new Vector3 (1, 2, 1);
	}
}

public class ColorData
{
    public Color GetAColorToUse(int indexOfTheColorToGet) {
        List<Color> colorList = new List<Color>();
		colorList.Add(new Color(1, 0, 0));
		colorList.Add(new Color(.7f, .7f, 0));
		colorList.Add(new Color(0, 1, 0));
		colorList.Add(new Color(0, .3f, 1));
		colorList.Add(new Color(0, 1, 1));
		return colorList[indexOfTheColorToGet];
    }
}

public class CubeData
{
    // When we find a cube, we should put its data in here for tidier access

	public GameObject cube;

	public CubeData(GameObject newCube){
		cube = newCube;
	}

}
