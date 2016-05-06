using UnityEngine;
using System.Collections;

public class PlatformTransform : MonoBehaviour {
    private Camera cam;
    private Plane[] planes;
    Transform ThisTransform;

    void Start () {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
    }
	
	void Update () {
       /* if (GeometryUtility.TestPlanesAABB(planes, gameObject.GetComponent<Collider2D>().bounds))
        {
            ThisTransform = GetComponent<Transform>();
            ThisTransform.position -= new Vector3(0f, 0.05f / 4f, 0f);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }
}
