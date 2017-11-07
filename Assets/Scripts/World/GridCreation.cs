using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Module: GridCreation
/// Team: Client
/// Description: creates 3D grid based on data from CityDataManager
/// Author: 
///	 Name: Dongwon(Shawn) Kim    Date: 2017-09-18
/// Modified by:	
///	 Name: Dongwon(Shawn) Kim   Change:	Fix bug 						Date: 2017-09-19
///  Name: Dongwon(Shawn) Kim   Change:	adding data by CityDataManager  Date: 2017-10-18
/// Based on:  
/// 	https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
/// 	http://answers.unity3d.com/questions/718778/trying-to-create-a-grid.html
/// 	https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
/// 	http://answers.unity3d.com/questions/25352/add-texture-to-gameobject-through-code.html
/// 	https://www.youtube.com/watch?v=810UVUWGlWw
/// </summary>
public class GridCreation : MonoBehaviour {

	// 3D prefab of grid
	public Transform cellPrefab;

	// Size for the cell
	public Vector3 size;

// not using now
//	public int gridWidth;
//	public int gridHeight;

	// Reference for the CityDataManager class
	public CityDataManager cityDataManager;

	// Parent grid object to organize the object in Hierarchy
	private GameObject parentGrid;


	// Use this for initialization
	void Start () {
		parentGrid = GameObject.Find ("Grid");
		cityDataManager = this.GetComponent<CityDataManager> ();
		CreateGrid ();
		//ShowGrid (false);
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update(){
	}

	/**
	 * Creates grid and put zone, coordinate
	 **/
	void CreateGrid(){

		// temp location vector for coordinate of each cell
		Vector3 locationVector;

		// temp x,y,z floating value for coordinate of each cell
		float loc_x, loc_y, loc_z;

		// always 0
		loc_y = 0;

		size.x = cityDataManager.Size_x;
		size.z = cityDataManager.Size_z;

//		Debug.Log (cellPrefab.localScale.x +", " + cellPrefab.localScale.z);

		for(int x = 0; x < size.x; x++){
			for(int z = 0; z < size.z; z++){

				// getting random number for zone( its temporally used for prototype)
//				cellPrefab.GetChild (0).GetComponent<TextMesh> ().text = (Random.Range (0, 4)).ToString();
				cellPrefab.GetChild (1).GetComponent<TextMesh> ().text = "(" + x + ", " + z + ")";
				cellPrefab.GetChild (0).GetComponent<TextMesh> ().text = cityDataManager.getIndexOfXZ(x, z).ToString();

				// put the tag plane on the object
				cellPrefab.tag = "plane";
					
				// set color index to GridColor to color the grid
				cellPrefab.GetComponent<GridColor> ().colorIndex = int.Parse(cellPrefab.GetChild (0).GetComponent<TextMesh> ().text);

				// update temp x,z equivalent to next x,z
				loc_x = x + (cellPrefab.localScale.x * x) * 10;
				loc_z = z + (cellPrefab.localScale.z * z) * 10;

				// update location vector
				locationVector = new Vector3 (loc_x, loc_y, loc_z);

				// creates each cell of the grid
			 	Instantiate(cellPrefab, 
							locationVector,
							Quaternion.identity,
							parentGrid.transform);
				
			}
		}
	}

	/// <summary>
	/// Shows the grid.
	/// </summary>
	/// <param name="onOff">If set to <c>true</c> on.</param>
	void ShowGrid(bool onOff){
		// important this will inactivate all grid objects, so the building and other objects will not be rendered.
		parentGrid.SetActive(onOff);
	}

}