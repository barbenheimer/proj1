using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera mainCam;
    public LineRenderer line;
    public DistanceJoint2D joint;
    public LayerMask ropeMask;

    void Start()
    {
        line = GetComponent<LineRenderer>();    
        joint = GetComponent<DistanceJoint2D>();
        line.enabled = false;
        joint.enabled = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition); //screen to mouse
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position, Mathf.Infinity, ropeMask); //raycast filter what objects are grappleable
            if(hit.collider != null)
            {
                //draw rope
                joint.connectedAnchor = mousePos;

                joint.enabled = true;
                line.enabled = true;

                line.SetPosition(0, joint.connectedAnchor);
                line.SetPosition(1, transform.position);
            }
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            line.enabled = false;
        }
        //so the rope doesn't go wonky after firing

        if (joint.enabled)
        {
            line.SetPosition(1, transform.position);
        }

    }
}
//    public Camera mainCamera;
//    public LineRenderer lineRenderer;
//    public DistanceJoint2D distanceJoint;


//    public LayerMask ropeLayer;

//    bool checker = true;

//    Start is called before the first frame update
//    void Start()
//    {
//        distanceJoint = GetComponent<DistanceJoint2D>();
//        distanceJoint.enabled = true;
//    }




//    Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Mouse0))
//        {
//            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
//            Vector2 route = mousePos - (Vector2)transform.position;


//            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos, distance, ropeLayer);

//            if (hit.collider != null)
//            {
//                if (hit.collider.gameObject.layer == 8)
//                {
//                    checker = false;
//                    lineRenderer.SetPosition(0, mousePos);
//                    lineRenderer.SetPosition(1, transform.position);
//                    distanceJoint.connectedAnchor = mousePos;
//                    distanceJoint.enabled = true;
//                    lineRenderer.enabled = true;
//                    Debug.DrawRay(transform.position, route, Color.green);
//                }

//                Debug.DrawRay(transform.position, route, Color.red);
//            }
//        }
//        else if (Input.GetKeyUp(KeyCode.Mouse0) && checker == false)
//        {

//            checker = true;
//            distanceJoint.enabled = false;
//            lineRenderer.enabled = false;
//        }
//        if (distanceJoint.enabled)
//        {
//            lineRenderer.SetPosition(1, transform.position);
//        }
//    }

