using UnityEngine;
using System.Collections;

public class GoToGameScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	
			print("click");

			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			


			if(hit.collider != null && hit.collider.transform == this.transform)
			{
				Application.LoadLevel("TestScene");
            }
        }
	}
}
