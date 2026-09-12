using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnMainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text textMainMenuBtn;
    [SerializeField] private Button btnMainMenu;

    private void Awake()
    {
        btnMainMenu.onClick.AddListener(btnMainMenuClicked);
    }

    private void Start()
    {
        btnMainMenu.gameObject.SetActive(false);
        textMainMenuBtn.text = "Main Menu";
    }

    private void btnMainMenuClicked()
    {
        SceneManager.LoadScene("UI.General");
        Time.timeScale = 1;
    }
}