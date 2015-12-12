using UnityEngine;
using System.Collections;

public class RelationShip : MonoBehaviour {
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;
    public float lineSpeed = 6;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 2;
    public GameObject parent;
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetWidth(0.45F, 0.45F);
        lineRenderer.SetPosition(0, this.transform.position);
        if(this.transform.parent!=null)
        parent = this.transform.parent.gameObject;
        dist = Vector3.Distance(this.transform.position, parent.transform.position);
    }
    void Update()
    {
        if (counter < dist)
        {
            counter += .1f / lineSpeed;
            float x = Mathf.Lerp(0, dist, counter);
            Vector3 pointA = this.transform.position;
            Vector3 pointB = parent.transform.position;
            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;
            lineRenderer.SetPosition(1, pointAlongLine);
        }
    }
}
