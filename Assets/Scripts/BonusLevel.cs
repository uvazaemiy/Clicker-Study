using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BonusLevel : MonoBehaviour
{
    private const string BONUS_LEVEL_SAVE = "BONUS_LEVEL_SAVE";
    private const string SAVE_CLICK_NOW = "SaveClickNow";

    [SerializeField] private Text _clickText;
    [SerializeField] private Text _timeText;

    private int _totalClick = 0;
    private float _tickTimer = 30f;
    private int _clickNow = 1;

    
    
    
    
    void Start()
    {
        _clickNow = PlayerPrefs.GetInt(SAVE_CLICK_NOW, 1);
        UpdateText();
    }

    private void Update()
    {
        if(_tickTimer > 0)
        {
            _tickTimer -= Time.deltaTime;
            UpdateTimeText();
        }
        else
        {
            PlayerPrefs.SetInt(BONUS_LEVEL_SAVE, _totalClick);
            SceneManager.LoadScene("Main Scene");
        }
    }

    
    
    
    
    private void UpdateTimeText()
    {
        if (_tickTimer < 0) _tickTimer = 0;

        float minutes = Mathf.FloorToInt(_tickTimer / 60);
        float seconds = Mathf.FloorToInt(_tickTimer % 60);

        _timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void ButtonClick()
    {
        int randomClick = Random.Range(_clickNow, _clickNow + 15 );
        _totalClick += randomClick;
        UpdateText();
    }

    private void UpdateText()
    {
        _clickText.text = _totalClick.ToString();
    }
}