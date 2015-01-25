using UnityEngine;
using System.Collections;
using Assets;

public class drawSpheres : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Vector3 size = new Vector3(atomiData.atomii[0].raza*2,atomiData.atomii[0].raza*2,atomiData.atomii[0].raza*2);

        GameObject testSfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        testSfera.renderer.material.color = atomiData.atomii[0].culoare;
        testSfera.transform.localPosition = atomiData.atomii[0].pozitia;
        testSfera.transform.localScale    = size;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
