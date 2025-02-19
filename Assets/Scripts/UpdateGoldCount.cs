using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateGoldCount : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    private TextMeshProUGUI totalSpots;

    void Start()
    {
        totalSpots = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("UpdateGoldDisplay", 1f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void UpdateGoldDisplay()
    {
        Debug.Log("yip");
        // get number of spots from spawner
        //int totalSpots = ;
        // Update the collectible count display
        int occupiedSpots = 0;
        if (spawner != null) {
            spawner.spotList.ForEach(sp =>
            {
                if (sp.blockCount > 0)
                {
                    occupiedSpots++;
                }
            });
            totalSpots.text = $"Occupied spots: {occupiedSpots} / {spawner.spotList.Count}";
        }
        else
        {
            totalSpots.text = "Occupied spots: 0";
        }

    }
}
