using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBackBtn : MonoBehaviour
{
    [SerializeField] Button quitBtn;
    [SerializeField] TMP_Text textQuitBtn;
    private int fontSizeBtns = 50;

    private void Awake()
    {
        quitBtn.onClick.AddListener(QuitClicked);
    }

    private void Start()
    {
        textQuitBtn.text = "Quit Game";
        textQuitBtn.fontSize = fontSizeBtns;
    }

    private void OnDestroy()
    {
        quitBtn.onClick.RemoveAllListeners();
    }

    private void QuitClicked()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
