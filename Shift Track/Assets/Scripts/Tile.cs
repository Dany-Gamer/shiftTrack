using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    GameManager gameManager;
    private bool isDragging;
    private float snapSensitivity = 132f;


    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x, transform.position.y);

        }

    }

    public void OnMouseUp()
    {
        isDragging = false;
        for (int i = 0; i < gameManager.snapPoints.Count; i++)
        {

            if (Vector3.Distance(gameManager.snapPoints[i].transform.position, gameObject.transform.position) < snapSensitivity)
            {

                Tile tileToSwap = gameManager.GetTileFromSnapPoint(gameManager.snapPoints[i]);
                GameObject originalSnapPoint = gameManager.GetSnapPointFromTile(this);

                gameManager.SetTileToSnapPoint(originalSnapPoint, tileToSwap);
                gameManager.SetTileToSnapPoint(gameManager.snapPoints[i], this);

                transform.position = new Vector2(gameManager.snapPoints[i].transform.position.x, transform.position.y);
                tileToSwap.transform.position = new Vector2(originalSnapPoint.transform.position.x, tileToSwap.transform.position.y);

            }

        }

    }

}