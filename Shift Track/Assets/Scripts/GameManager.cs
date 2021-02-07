using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
 {
    [Header("Segments")]
    [SerializeField] List<GameObject> segmentPrefabs = new List<GameObject>();
    List<GameObject> segments = new List<GameObject>();
    int numberOfSegments = 5;
    float s = -527;

    [Header("SnapPoints")]
    public List<GameObject> snapPoints;


    [Header("Dictionary")]
    private Dictionary<GameObject, Tile> snapPointDictionary;


    void Awake()
    {
        RandomizeList();
        DictDec();
        GenerateSegments();
    }

    private void DictDec()
    {
        snapPointDictionary = new Dictionary<GameObject, Tile>();
        foreach (GameObject point in snapPoints)
        {
            snapPointDictionary.Add(point, null);
        }
    }

    public void SetTileToSnapPoint(GameObject points, Tile tile)
    {
        if (snapPointDictionary.ContainsKey(points))
        {
            snapPointDictionary[points] = tile;
        }
        else Debug.Log("Could not assign tile to snapPoint");


    }
    public Tile GetTileFromSnapPoint(GameObject points)
    {
        return snapPointDictionary[points];
    }

    public GameObject GetSnapPointFromTile(Tile tile)
    {
        foreach (GameObject points in snapPointDictionary.Keys)
        {
            if (snapPointDictionary[points] == tile) return points;
        }

        Debug.Log("Could not find a snap point associated with this tile");
        return null;
    }

    private void RandomizeList()
    {
        for (int i = 0; i < segmentPrefabs.Count; i++)
        {
            int rand = Random.Range(0, segmentPrefabs.Count);
            GameObject temp = segmentPrefabs[rand];
            segmentPrefabs[rand] = segmentPrefabs[i];
            segmentPrefabs[i] = temp;
        }

    }

    private void GenerateSegments()
    {
        for (int i = 0; i < numberOfSegments; i++)
        {
            var segment = Instantiate(segmentPrefabs[i], new Vector2((s), -14f), Quaternion.identity);
            snapPoints[i].transform.position = segment.transform.position;
            SetTileToSnapPoint(snapPoints[i], segment.GetComponentInChildren<Tile>());
            segment.transform.SetParent(this.transform);
            segments.Add(segment);
            s += 263f;
        }
    }

    public bool CheckPath()
    {
        for(int i=0; i<=snapPoints.Count; i++)
        {
            if (i == 0) //Start block
            {
                Tile currentTile = snapPointDictionary[snapPoints[i]];
                if (currentTile.entrance != Tile.PathLocation.MIDDLE)
                {
                    Debug.Log("This is not a valid solution, the first tile does not connect to the starting block.");
                    return false;
                }
            }
            else if (i == 5) //Finish block
            {
                Tile previousTile = snapPointDictionary[snapPoints[i-1]];
                if (previousTile.exit != Tile.PathLocation.MIDDLE)
                {
                    Debug.Log("This is not a valid solution, the last tile does not connect to the finish block.");
                    return false;
                }
            }
            else //All the other blocks
            {
                Tile currentTile = snapPointDictionary[snapPoints[i]];
                Tile previousTile = snapPointDictionary[snapPoints[i - 1]];
                if (currentTile.entrance != previousTile.exit)
                {
                    Debug.Log("This is not a valid solution, tiles " + (i) + " and " + (i + 1) + " don't match.");
                    return false;
                }
            }
        }

        //If we have made it here without returning false then we know we have a valid solution
        Debug.Log("Winner Winner!");
        return true;
    }

}