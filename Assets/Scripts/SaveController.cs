using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    [SerializeField] private Clicker clicker;
    public string[] AllSavesName;
    [Space] 
    [SerializeField] private UpgradeButton[] allUpgradeButtons; //1 - Клікер, 2 - Автоферма, 3 - Автвоклікер
    
    private List<int> AllIntSaves = new List<int>();
    private bool deleteAll;

    
    
    

    private void OnApplicationQuit()
    {
        if (!deleteAll)
            Save();
    }
    
    
    
    
    

    public void Save()
    {
        foreach (UpgradeButton button in allUpgradeButtons)
            AllIntSaves.Add(button.upgradeModifier);
        AllIntSaves.Add(clicker.totalClicks);
        AllIntSaves.Add(clicker.clickModifier);
        
        for (int i = 0; i < AllSavesName.Length; i++)
            PlayerPrefs.SetInt(AllSavesName[i], AllIntSaves[i]);
        
        AllIntSaves.Clear();
    }

    
    
    
    
    
    public int GetTotalClicks(string value_name, int default_value)
    {
        return PlayerPrefs.GetInt(value_name, default_value);
    }
    
    public int GetClickModifier(string value_name, int default_value)
    {
        return PlayerPrefs.GetInt(value_name, default_value);
    }

    public int GetUpgradeModifier(UpgradeButton.TypeOfUpgrade typeOfUpgrade, int default_value)
    {
            switch (typeOfUpgrade)
            {
                case UpgradeButton.TypeOfUpgrade.UpgradeClicks:
                    return PlayerPrefs.GetInt(AllSavesName[0], default_value);
                case UpgradeButton.TypeOfUpgrade.AutoFarm:
                    return PlayerPrefs.GetInt(AllSavesName[1], default_value);
                case UpgradeButton.TypeOfUpgrade.AutoClick:
                    return PlayerPrefs.GetInt(AllSavesName[2], default_value);
            }
        
        return default_value;
    }

    public void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
        deleteAll = true;
        
        Debug.Log("All saves deleted!");
    }
}
