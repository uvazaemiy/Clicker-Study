using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    private const string SAVE_CLICKS = "TotalClicks";
    private const string SAVE_CLICK_MOIFIER = "ClickModifier";
    
    [SerializeField] private SaveController saveController;
    [SerializeField] private Text clickText;

    public int totalClicks;
    public int clickModifier = 1;
    [Space]
    public Button clickButton;

    
    
    
    
    void Start()
    {
        totalClicks = saveController.GetTotalClicks(SAVE_CLICKS);
        clickModifier = saveController.GetClickModifier(SAVE_CLICK_MOIFIER);
        
        UpdateClickText();
    }

    
    
    
    
    public void ClickButton()
    {
        totalClicks += clickModifier;
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
}