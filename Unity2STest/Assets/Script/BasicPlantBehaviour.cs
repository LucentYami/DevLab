using UnityEngine;
using System.Collections;

public class BasicPlantBehaviour : MonoBehaviour {


	public int Hydration = 100;
	public int Health = 100;
	public int WateringCanEffectiveNess = 10;
	public bool Growing = true;

	// Use this for initialization
	void Start () {
		StartCoroutine(Dehydrate());
	}
	
	// Update is called once per frame
	void Update () {

		//did I get watered?
		if (ToolSelectionScript.SelectedTool == ToolSelectionScript.ToolType.WateringCan)
		{

			if(Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
	
				if (hit.collider != null && hit.collider.transform == this.transform) {
					this.Hydration += WateringCanEffectiveNess;
				}
			}
		}
	}

	void FixedUpdate() {
		
	}

	public IEnumerator Dehydrate()
	{
		while(true)
		{
			yield return new WaitForSeconds(1);

			Hydration -= 1;

			if(Growing)
			{
				this.transform.localScale += new Vector3(0,0.1f * ((float)Hydration / 100f),0);
			}
		}
	}
}
