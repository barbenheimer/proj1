//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;

//public class RopeSystem : MonoBehaviour
//{
//    public GameObject ropeHingeAnchor;
//    public DistanceJoint2D ropeJoint;
//    public Player Player;
//    private bool ropeAttached;
//    private Vector2 playerPos;
//    private Rigidbody2D ropeAnchorRb;
//    private SpriteRenderer ropeAnchorSprite;


//    public LineRenderer ropeRenderer;
//    public LayerMask ropeMask;
//    private float ropeDistance = 20f;
//    private List<Vector2> ropePos = new List<Vector2>();

//    private bool distanceSet;
//    void Awake()
//    {
//        ropeJoint.enabled = false;
//        playerPos = transform.position;
//        ropeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
//        ropeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
//    }
//    void Update()
//    {
//        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
//        var facingDirection = worldMousePosition - transform.position;
//        var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
//        if(aimAngle < 0f)
//        {
//            aimAngle = Mathf.PI * 2 + aimAngle;
//        }


//        var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;

//        playerPos = transform.position;


//        if (!ropeAttached)
//        {
            
//        }
//        else
//        {
            
//        }
//    }


//    private void HandleInput(Vector2 aimDirection)
//    {
//        if (Input.GetMouseButton(0))
//        {
//            if (ropeAttached) return;
//            ropeRenderer.enabled = true;    

//            var hit = Physics2D.Raycast(playerPos, aimDirection, ropeDistance, ropeMask);

//            if (hit.collider != null)
//            {
//                ropeAttached = true;
//                if (!ropePos.Contains(hit.point))
//                {
//                    transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
//                    ropePos.Add(hit.point);
//                    ropeJoint.distance = Vector2.Distance(playerPos, hit.point);
//                    ropeJoint.enabled = true;
//                    ropeAnchorSprite.enabled = true;
//                }
//            }
//            else
//            {
//                ropeRenderer.enabled = false;
//                ropeAttached = false; 
//                ropeJoint.enabled = false;
//            }
//        }
//        if (Input.GetMouseButton(1))
//        {
//            ResetRope();
//        }
//    }


//    private void ResetRope()
//    {
//        ropeJoint.enabled = false;
//        ropeAttached = false;
//        ropeAnchorSprite.enabled = false;
//        ropeRenderer.positionCount = 2;
//        ropeRenderer.SetPosition(0, transform.position);
//        ropeRenderer.SetPosition(1, transform.position);
//        ropePos.Clear();
//    }


//    private void UpdateRopePos()
//    {
//        if(!ropeAttached)
//        {
//            return;
//        }
//        ropeRenderer.positionCount = ropePos.Count + 1;

//        for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
//        {
//            if (i != ropeRenderer.positionCount - 1)
//            {
//                ropeRenderer.SetPosition(i, ropePos[i]);
//                if(i == ropePos.Count - 1 || ropePos.Count == 1) 
//                {
//                    var ropePos = ropePos[ropePos.Count - 1];
//                    if (ropePos.Count == 1)
//                    {
//                        ropeAnchorRb.transform.position = ropePos;
//                        if (!distantSet)
//                        {
//                            ropeJoint.distance = Vector2.Distance(transform.position, ropePos);
//                            distanceSet = true;
//                        }
//                    }
//                    else
//                    {
//                        ropeAnchorRb.transform.position = ropePos;
//                        if (!distanceSet)
//                        {
//                            ropeJoint.distance = Vector2.Distance(transform.position, ropePos);
//                            distanceSet = true;
//                        }
//                    }
//                }
//                else if(i -1 == ropePos.IndexOf(ropePos.Last()))
//                {
//                    var ropePos = ropePos.Last();
//                    ropeAnchorRb.transform.position = ropePos;
//                    if (!distanceSet)
//                    {
//                        ropeJoint.distance = Vector2.Distance(transform.position, ropePos);
//                        distanceSet = true;
//                    }
//                }
//            }
//            else
//            {
//                ropeRenderer.SetPosition(i, transform.position);
//            }
//        }
//    }
//}
