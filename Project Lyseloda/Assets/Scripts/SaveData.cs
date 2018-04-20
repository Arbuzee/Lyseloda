using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

    public LevelData[] levelData;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void AddTotalCollected(int collected)
    {
        PlayerPrefs.SetInt("TotalCollected", collected);

    }

    public void UpdateDisplayValues()
    {
        GetComponent<DisplayData>().UpdateValues();

    }












    public void ResetAllData()
    {
        PlayerPrefs.DeleteKey("TotalCollected");

    }

}
