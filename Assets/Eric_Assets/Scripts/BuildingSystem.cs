using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;
    public GridLayout gridLayout;
    public GameObject Player;
    public Workbench Work_Bench;
    public GameObject UI_ConfirmHousePos;

    private Grid grid;
    [SerializeField] private Tilemap MainTilemap;
    [SerializeField] private TileBase whiteTile;
    

    public GameObject prefab1;

    private PlacableObject objectToPlace;

    #region Unity methods
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }
    public void BuildNewHouse()
    {
        InitializeWithObject(prefab1);
    }
    private void Update()
    {   /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            InitializeWithObject(prefab1);
        }
        */
        if (!objectToPlace)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            objectToPlace.Rotate();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (CanBePlaced(objectToPlace))
            {
                
                Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                TakeArea(start, objectToPlace.Size);
                UI_ConfirmHousePos.SetActive(false);
                objectToPlace.Place();
            }
            else
            {
                //Destroy(objectToPlace.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Destroy(objectToPlace.gameObject);
        }
    }
    #endregion

    #region Utils
    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }

    #endregion

    #region Building Placement

    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(Player.transform.position); // gets nearest gri position to the player

        GameObject obj = Instantiate(prefab, position, Quaternion.identity); // spawns house at given positio
        Work_Bench.house_parent = obj.transform.Find("House_Models").gameObject; // sets the public variable for the house parent in the workbench
        obj.transform.parent = Player.transform; // sets the parent of the house as the player
        objectToPlace = obj.GetComponent<PlacableObject>(); // gets regrence to placeable object script that is attached to the house prefab
        obj.AddComponent<ObjectDrag>(); // adds the object drag script to the house prefab
        UI_ConfirmHousePos.SetActive(true);
    }

    private bool CanBePlaced(PlacableObject placableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
        area.size = placableObject.Size;
        area.size = new Vector3Int(area.size.x + 1, area.size.y + 1, area.size.z);

        TileBase[] baseArray = GetTilesBlock(area, MainTilemap);

        foreach (var b in baseArray)
        {
            if(b == whiteTile)
            {
                return false;
            }

        }

        return true;
    }

    public void TakeArea(Vector3Int start, Vector3Int size)
    {
        MainTilemap.BoxFill(start, whiteTile, start.x, start.y, start.x + size.x, start.y + size.x);
    }


    #endregion
    // Update is called once per frame
    private void Start()
    {
        UI_ConfirmHousePos.SetActive(false);
    }

}
