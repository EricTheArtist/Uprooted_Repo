using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableObject : MonoBehaviour
{
    public bool Placed { get; private set; }
    public Vector3Int Size { get; private set; }

    private Vector3[] Vertices;
    public Transform[] Corners;
    // Start is called before the first frame update
    //public BoxCollider b;

    private void GetColliderVertexPositionsLocal()
    {
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
        Vertices = new Vector3[4];
        Vertices[0] = Corners[0].localPosition; //b.center + new Vector3(-b.size.x, -b.size.z) * 0.5f;
        Vertices[1] = Corners[1].localPosition;//b.center + new Vector3(b.size.x, -b.size.z) * 0.5f;
        Vertices[2] = Corners[2].localPosition;//b.center + new Vector3(b.size.x, b.size.z) * 0.5f;
        Vertices[3] = Corners[3].localPosition;//b.center + new Vector3(-b.size.x, b.size.z) * 0.5f;

        Debug.DrawRay(Vertices[0], Vertices[1], Color.red, 100, false);
        Debug.DrawRay(Vertices[1], Vertices[2], Color.red, 100, false);
        Debug.DrawRay(Vertices[2], Vertices[3], Color.red, 100, false);
        Debug.DrawRay(Vertices[3], Vertices[0], Color.red, 100, false);
        Debug.DrawRay(b.center, b.center+ new Vector3(0,10,0), Color.blue, 100, false);
    }

    private void CalculateSizeInCells()
    {
        Vector3Int[] vertices = new Vector3Int[Vertices.Length];

        for(int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldPos = transform.TransformPoint(Vertices[i]);
            vertices[i] = BuildingSystem.current.gridLayout.WorldToCell(worldPos);
        }

        Size = new Vector3Int(Mathf.Abs((vertices[0] - vertices[1]).x), 
            Mathf.Abs((vertices[0] - vertices[1]).y), 1);
    }

    public Vector3 GetStartPosition()
    {
        GetColliderVertexPositionsLocal();
        CalculateSizeInCells();
        return transform.TransformPoint(Vertices[0]);
    }
    void Start()
    {
        GetColliderVertexPositionsLocal();
        CalculateSizeInCells();
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        Size = new Vector3Int(Size.y, Size.x, 1);

        Vector3[] vertices = new Vector3[Vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = Vertices[(i + 1) % Vertices.Length];
        }
        Vertices = vertices;
    }

    public virtual void Place()
    {
        ObjectDrag drag = gameObject.GetComponent<ObjectDrag>();
        Destroy(drag);
        transform.parent = null; // detach from player
        Placed = true;
        Collider Col = gameObject.GetComponent<Collider>();
        Col.isTrigger = false;

        // invoke events of placement (Build timer etc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
