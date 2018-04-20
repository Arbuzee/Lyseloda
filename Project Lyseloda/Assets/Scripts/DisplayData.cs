using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayData : MonoBehaviour {

    public Text totalCollected;

    public Text[] collected;

    private LevelData[] levelData;

    void Start () {
        levelData = GetComponent<SaveData>().levelData;

        CollectableData();

        totalCollected.text = PlayerPrefs.GetInt("TotalCollected", 0).ToString();

    }

    public void UpdateValues()
    {
        CollectableData();
    }

    private void CollectableData()
    {
        for (int i = 0; i < levelData.Length; i++)
        {
            if (collected[i] != null && levelData[i] != null)
            {
                collected[i].text = levelData[i].collected.ToString();
                collected[i].text += "/";
                collected[i].text += levelData[i].collectable.ToString();
            }
            
        }

    }

}
