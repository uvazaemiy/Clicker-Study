using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public SaveController saveController;
    [SerializeField] private Text clickText;

    public int totalClicks;
    public int clickModifier = 1;
    [Space]
    public Button clickButton;

    
    
    
    
    void Start()
    {
        totalClicks = saveController.GetTotalClicks(saveController.AllSavesName[3], totalClicks);
        clickModifier = saveController.GetClickModifier(saveController.AllSavesName[4], clickModifier);
        
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