using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private TypeOfUpgrade typeOfUpgrade;
    [SerializeField] private Clicker clicker;
    [Space]
    public int upgradeModifier = 1;
    [SerializeField] private int upgradeCost = 100;
    [SerializeField] private int upgradeCostScale = 2;
    [Space]
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Text priceText;
    [Space] 
    [SerializeField] private Text[] extraTexts;
    [SerializeField] private Image upgradeIcon;
    [SerializeField] private Sprite[] iconSprites;

    private float timer = 0;

    
    
    
    

    private void Start()
    {
        upgradeModifier = clicker.saveController.GetUpgradeModifier(typeOfUpgrade, upgradeModifier);
        
        if (upgradeModifier != 0 && typeOfUpgrade != TypeOfUpgrade.UpgradeClicks)
            upgradeCost *= upgradeModifier * upgradeCostScale;
        else if (typeOfUpgrade == TypeOfUpgrade.UpgradeClicks && upgradeModifier != 1)
            upgradeCost *= (upgradeModifier - 1) * upgradeCostScale;
        
        UpdateButtonText();
    }

    
    
    
    

    public void UpgradeClicks()
    {
        if (CheckPrice())
        {
            upgradeModifier++;
            clicker.clickModifier = upgradeModifier;
            
            ChangeTotalClicks();
        }
    }

    public void AutoFarmClicks()
    {
        if (CheckPrice())
        {
            upgradeModifier++;
            
            ChangeTotalClicks();
        }
    }

    private void AutoFarmTimer()
    {
        if (timer >= 1)
        {
            timer = 0;
            
            clicker.ClickButton(upgradeModifier);
            ChangeIconUpgrade();
        }
    }
    
    private void AutoClicksTimer()
    {
        if (timer >= 1 / (float)upgradeModifier)
        {
            timer = 0;
            
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(clicker.clickButton.gameObject, pointer, ExecuteEvents.pointerDownHandler);
            ExecuteEvents.Execute(clicker.clickButton.gameObject, pointer, ExecuteEvents.pointerUpHandler);

            clicker.ClickButton();
            ChangeIconUpgrade();
        }
    }

    private void ChangeIconUpgrade()
    {
        upgradeIcon.gameObject.SetActive(true);
        upgradeIcon.sprite = iconSprites[upgradeModifier - 1];
    }
    
    
    
    
    
    private void Update()
    {
        UpdateInteract();
        
        timer += Time.deltaTime;

        if (upgradeModifier >= 1)
        {
            if (typeOfUpgrade == TypeOfUpgrade.AutoFarm)
                AutoFarmTimer();
            if (typeOfUpgrade == TypeOfUpgrade.AutoClick)
                AutoClicksTimer();
        }
    }
    


    private void UpdateInteract()
    {
        if (CheckPrice())
        {
            upgradeButton.interactable = true;

            foreach (Text text in extraTexts)
                text.color = newAlphaColor(text.color, upgradeButton.colors.normalColor.a);
        }
        else
        {
            upgradeButton.interactable = false;
            
            foreach (Text text in extraTexts)
                text.color = newAlphaColor(text.color, upgradeButton.colors.disabledColor.a);
        }
    }

    
    
    
    
    
    private void ChangeTotalClicks()
    {
        clicker.totalClicks -= upgradeCost;
        clicker.UpdateClickText();

        upgradeCost *= upgradeCostScale;
        UpdateButtonText();
        
        clicker.saveController.Save();
    }

    private void UpdateButtonText()
    {
        priceText.text = upgradeCost.ToString();
    }
    
    private bool CheckPrice()
    {
        if (upgradeCost <= clicker.totalClicks) return true;
        else return false;
    
        // скорочена альтернатива: return upgradeCost <= clicker.totalClicks ? true : false;
    }


    private Color newAlphaColor(Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }
    
 
    
    
    
    
    public enum TypeOfUpgrade
    {
        UpgradeClicks,
        AutoFarm,
        AutoClick
    }
}