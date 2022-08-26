using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI treasureCountText;
    private int treasureCount;

    private void Awake() {
        treasureCount = 0;
        treasureCountText.text = treasureCount.ToString();
    }

    public void UpdateTreasure(int amount) {
        treasureCount += amount;
        treasureCountText.text = treasureCount.ToString();
    }
}