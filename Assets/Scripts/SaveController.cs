using UnityEngine;

public class SaveController : MonoBehaviour
{
    [SerializeField] private Clicker clicker;

    
    
    
    
    
    private void OnApplicationQuit()
    {
        Save("TotalClicks", clicker.totalClicks, "ClickModifier", clicker.clickModifier);
    }

    private void OnApplicationPause()
    {
        Save("TotalClicks", clicker.totalClicks, "ClickModifier", clicker.clickModifier);
        Save("TotalClicks", clicker.totalClicks, "ClickModifier", clicker.clickModifier);
    }

    
    
    
    
    
    
    public void ApplicationSave()
    {
        Save("TotalClicks", clicker.totalClicks, "ClickModifier", clicker.clickModifier);
    }

    public void Save(string value_name, int value, string value_name_2, int value_2)
    {
        PlayerPrefs.SetInt(value_name, value);
        PlayerPrefs.SetInt(value_name_2, value_2);
    }

    public int GetTotalClicks(string value_name)
    {
        return PlayerPrefs.GetInt(value_name, 0);
    }
    
    public int GetClickModifier(string value_name)
    {
        return PlayerPrefs.GetInt(value_name, 0);
    }
}
