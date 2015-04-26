using UnityEngine;
using System.Collections;

public class FieldBehaviour : MonoBehaviour {

	const int plotHorizontals = 3;
	const int plotVerticals = 3;
	public int MaxPlants = 50;
	public GameObject SeedType;
	public GameObject PlotTemplate;
	
	GameObject[,] SoilPlots = new GameObject[plotHorizontals,plotVerticals];

	// Use this for initialization
	void Start () {

		float startX = -0.325f;
		float startY = 0.35f;

		float currentX = startX;
		float incrementX = 1f / plotHorizontals;
		float incrementY = -1f / plotVerticals;

		for (float x=0; x < plotHorizontals; x++) {

			float currentY = startY;

			for (float y=0; y < plotVerticals; y++) {
				var plot = (GameObject)Instantiate(PlotTemplate, new Vector3(0,0,0), Quaternion.identity);
				var denom = 1.0f / (float)plotHorizontals * x;

				Vector3 setVector = new Vector3(startX,currentY,0f);

				SoilPlots[(int)x,(int)y] = plot;

				plot.transform.parent = transform;
				plot.transform.localPosition = setVector;

				currentY += incrementY;
			}

			startX += incrementX;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			
			if(hit.collider != null && hit.collider.transform == this.transform)
			{
				if(ToolSelectionScript.SelectedTool == ToolSelectionScript.ToolType.Seed) {
					var plant = Instantiate(SeedType,hit.point, Quaternion.identity);
				}
			}
		}
	}
}
