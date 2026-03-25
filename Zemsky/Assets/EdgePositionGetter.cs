using UnityEngine;
using Edge;

public class EdgePositionGetter : MonoBehaviour
{
    public Transform middlePositionTransform;

    public float xDistanceToEdge, yDistanceToEdge;

    //public Transform moveableObject;
    //public float offset;

    //public EdgeType edgeAxis;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        MoveObjToNewPosition(edgeAxis, offset);
    //    }
    //}

    private void Start()
    {
        middlePositionTransform = GameObject.FindGameObjectWithTag("Center").transform;
    }

    public Vector2 GetPositionOnEdgeLine(EdgeType edgeAxis, float offsetFromCenter)
    {
        float possibleOffset = edgeAxis == EdgeType.y ? yDistanceToEdge : xDistanceToEdge;
        float offsetRange = Mathf.Clamp(offsetFromCenter, -possibleOffset, possibleOffset);

        Vector2 offset = edgeAxis == EdgeType.y ? new Vector2(0, offsetRange) : new Vector2(offsetRange, 0);

        Vector2 distanceToEdgeLine = edgeAxis == EdgeType.y ? new Vector2(xDistanceToEdge, 0) : new Vector2(0, yDistanceToEdge);
        Vector2 positionOnLine = (Vector2)middlePositionTransform.position + distanceToEdgeLine + offset;

        return positionOnLine;
    }

    //public void MoveObjToNewPosition(EdgeType edgeAxis, float offsetFromCenter)
    //{
    //    moveableObject.position = GetPositionOnEdgeLine(edgeAxis, offsetFromCenter);
    //}
}

namespace Edge
{
    public enum EdgeType
    {
        y,
        x
    }
}