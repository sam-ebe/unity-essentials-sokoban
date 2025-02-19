using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private TextMeshProUGUI spotCountText;
    [SerializeField] private TextMeshProUGUI goldCountText;
    [SerializeField] private TextMeshProUGUI goldRateText;
    private int goldCount = 0;
    private int goldRate = 0;

    void Start()
    {
        InvokeRepeating("UpdateGoldDisplay", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateGoldDisplay()
    {
        Debug.Log("yip");

        int occupiedSpots = 0;
        if (spawner != null)
        {
            // get number of occupied spots from spawner
            spawner.spotList.ForEach(sp =>
            {
                if (sp.blockCount > 0)
                {
                    occupiedSpots++;
                }
            });
            spotCountText.text = $"Occupied spots: {occupiedSpots} / {spawner.spotList.Count}";

            // update current gold rate
            goldRate = occupiedSpots; // TODO : add bonuses
            goldRateText.text = $"{goldRate}";

            // update current gold count
            goldCount = goldCount + goldRate;
            goldCountText.text = $"{goldCount}";
        }
        else
        {
            spotCountText.text = "Occupied spots: 0";
        }


    }
}
