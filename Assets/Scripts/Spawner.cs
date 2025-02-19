using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    public SpotController spotController;
    public BlockController block;
    
    [SerializeField] private int gridWidth = 16;
    [SerializeField] private int gridHeight = 9;
    private float xStep;
    private float yStep;
    private float xMin = -8.2f;
    private float xMax = 8.2f;
    private float yMin = -4.4f;
    private float yMax = 4.4f;

    private List<Vector2Int> availableSpots; // List of coordinates of empty spots
    public List<SpotController> spotList;
    void Start()
    {
        // Calculate the step size for grid coordinates
        xStep = (xMax - xMin) / (gridWidth - 1);
        yStep = (yMax - yMin) / (gridHeight - 1);

        // Init grid with 
        availableSpots = new List<Vector2Int>();
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                availableSpots.Add(new Vector2Int(i, j)); // Add all coordinates to the list
            }
        }

        spotList = new List<SpotController>(); // Initialize the spot list
        SpawnSpot();
        SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {

        if (availableSpots.Count != 0 && AreAllSpotsOccupied())
        {
            SpawnSpot();
            SpawnBlock();
        } 
        else
        {
           // Debug.Log("No available spots!");
        }

    }

    public void SpawnSpot()
    {
        // Select a random coordinate from the available spots
        var randomIndex = Random.Range(0, availableSpots.Count);
        var selectedSpot = availableSpots[randomIndex];

        // Remove the selected spot from the available spots list to ensure it's not selected again
        availableSpots.RemoveAt(randomIndex);

        // Calculate world position based on grid index
        float xPos = xMin + selectedSpot.x * xStep;
        float yPos = yMin + selectedSpot.y * yStep;

        SpotController sController = Instantiate(spotController, new Vector3(xPos, yPos, 0), Quaternion.identity);

        // Add the SpotController instance to the list
        spotList.Add(sController);

    }

    public void SpawnBlock()
    {
        // Select a random coordinate from the available spots
        var randomIndex = Random.Range(0, availableSpots.Count);
        var selectedSpot = availableSpots[randomIndex];

        // Calculate world position based on grid index
        float xPos = xMin + selectedSpot.x * xStep;
        float yPos = yMin + selectedSpot.y * yStep;

        Instantiate(block, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    // Check if all spots are occupied
    private bool AreAllSpotsOccupied()
    {
        // Check each spot in the spotList to see if it's occupied
        foreach (var spot in spotList)
        {
            if (spot.blockCount <=0) 
            {
                return false; // A spot is not occupied, return false
            }
        }
        return true; // All spots are occupied
    }


}
