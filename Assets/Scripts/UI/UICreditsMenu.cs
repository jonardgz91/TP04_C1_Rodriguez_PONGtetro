using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICreditsMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] TMP_Text txtCredits;
    [SerializeField] Button backBtn;
    [SerializeField] TMP_Text txtBackBtn;

    private void Awake()
    {
        backBtn.onClick.AddListener(BackBtnClicked);
    }
    private void Start()
    {
        txtCredits.text = "CREDITOS\n\n" +
                          "Game Design & Programming: Jonathan Rodriguez\n" +
                          "Art: Fue realizado con Claude.\n" +
                          "\n" +
                          "No apoyo el uso de Inteligencia Artificial para el desarrollo de videojuegos, solo se realizo con fines educativos.\n";

        // Suggestion: el texto del botón dice "Atas" en vez de "Atrás", y el título "CREDITOS" va con acento.
        // Es el primer texto que ve el que abre los créditos.
        txtBackBtn.text = "Atas";
    }

    private void OnDestroy()
    {
        backBtn.onClick.RemoveAllListeners();
    }

    private void BackBtnClicked()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
