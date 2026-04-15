using UnityEngine;
using Edge;

public class EdgePositionGetter : MonoBehaviour
{
    public Transform middlePositionTransform;

    public float xDistanceToEdge, yDistanceToEdge;

    private void Start()
    {
        middlePositionTransform = GameObject.FindGameObjectWithTag("Center").transform;
    }

    public Vector2 GetPositionOnEdgeLine(EdgeType edgeAxis, float offsetFromCenter, Polarity polarity = Polarity.positive)
    {
        float possibleOffset = edgeAxis == EdgeType.x ? yDistanceToEdge : xDistanceToEdge;
        float offsetRange = Mathf.Clamp(offsetFromCenter, -possibleOffset, possibleOffset);

        Vector2 offset = edgeAxis == EdgeType.x ? new Vector2(0, offsetRange) : new Vector2(offsetRange, 0);

        Vector2 distanceToEdgeLine = edgeAxis == EdgeType.x ? new Vector2(xDistanceToEdge, 0) : new Vector2(0, yDistanceToEdge);

        Vector2 positionOnLine = Vector2.zero;
        if (polarity == Polarity.positive)
        {
            positionOnLine = (Vector2)middlePositionTransform.position + distanceToEdgeLine + offset;
        }
        else
        {
            positionOnLine = (Vector2)middlePositionTransform.position - distanceToEdgeLine + offset;
        }

        return positionOnLine;
    }
}

namespace Edge
{
    public enum EdgeType
    {
        x,
        y
    }

    public enum Polarity
    { 
        positive,
        negative
    }


}