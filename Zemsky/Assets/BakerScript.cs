using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class BakerScript : MonoBehaviour
{
    public NavMeshSurface surface;

    void Start()
    {
        Invoke("Bake", 0.1f);
    }

    private void Bake()
    {
        surface.BuildNavMesh();
        print("baked");

    }
}
