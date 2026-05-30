using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelController : MonoBehaviour
{
    public void ChangeLevel()
    {
        SceneManager.LoadScene("Bonus Level");
    }
}