using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    private const string SAVE_CLICKS = "TotalClicks";

    [SerializeField] private Text clickText;

    public int totalClicks;
    public int clickmodifier = 1;
    [Space]
    public Button clickButton;

    
    
    
    
    void Start()
    {
        Load();
        UpdateClickText();
    }

    
    
    
    
    public void ClickButton()
    {
        totalClicks += clickmodifier;
        UpdateClickText();
    }

    public void ClickButton(int extraMoifier)
    {
        totalClicks += extraMoifier;
        UpdateClickText();
    }

    public void UpdateClickText()
    {
        clickText.text = $"Clicks: {totalClicks}";
    }

    
    
    
    
    private void OnApplicationQuit() => Save();

    private void OnApplicationPause() => Save();

    private void Save()
    {
        PlayerPrefs.SetInt(SAVE_CLICKS, totalClicks);
    }

    private void Load()
    {
        totalClicks = PlayerPrefs.GetInt(SAVE_CLICKS, 0);
    }
}