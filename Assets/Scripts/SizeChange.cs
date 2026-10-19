using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Suggestion: SizeChange y SpeedChange son la misma clase con el campo del SO cambiado: mismo Awake, mismo Start, mismo OnDestroy y los mismos dos métodos.
// Una sola clase con un enum serializado (Size o Speed) te deja un archivo en vez de dos.
public class SizeChange : MonoBehaviour
{
    [SerializeField] private PlayerDataSo player1;
    [SerializeField] private PlayerDataSo player2;
    [SerializeField] private TMP_Text textChangeSize;
    [SerializeField] private Slider player1Size;
    [SerializeField] private TMP_Text textPlayer1Size;
    [SerializeField] private TMP_Text textSizeOfPlayer1;
    [SerializeField] private Slider player2Size;
    [SerializeField] private TMP_Text textPlayer2Size;
    [SerializeField] private TMP_Text textSizeOfPlayer2;
    private int fontSizeBtns = 30;
    
    private void Awake()
    {
        player1Size.onValueChanged.AddListener(OnPlayer1SizeChange);
        player2Size.onValueChanged.AddListener(OnPlayer2SizeChange);
    }

    private void OnEnable()
    {
        player1Size.value = player1.verticalSize;
        player2Size.value = player2.verticalSize;
    }

    private void Start()
    {
        // Warning: los textos de la UI se escriben desde código en el Start, en este script y en SpeedChange, BtnQuit, UICreditsMenu y BtnColorChange.
        // Esos textos van en el inspector del TMP_Text: si están en el código hay que recompilar para cambiar una palabra, y no se pueden traducir.
        textChangeSize.text = "CAMBIA EL TAMAÑO DEL JUGADOR 1";
        textChangeSize.alignment = TextAlignmentOptions.Center;
        textChangeSize.fontSize = fontSizeBtns;

        textPlayer1Size.text = "Tamaño del jugador 1";
        textPlayer1Size.alignment = TextAlignmentOptions.Center;

        textPlayer2Size.text = "Tamaño del jugador 2";
        textPlayer2Size.alignment = TextAlignmentOptions.Center;

        player1Size.value = player1.verticalSize;
        textSizeOfPlayer1.text = player1.verticalSize.ToString("F1");

        player2Size.value = player2.verticalSize;
        textSizeOfPlayer2.text = player2.verticalSize.ToString("F1");
    }

    private void OnDestroy()
    {
        // Warning: RemoveAllListeners borra también lo que alguien haya cableado desde el inspector, no solo lo que registraste en el Awake. Está repetido en SpeedChange, BtnQuit, UICreditsMenu y los otros scripts de botón.
        // Como registrás con AddListener(OnPlayer1SizeChange), dá de baja con RemoveListener(OnPlayer1SizeChange).
        player1Size.onValueChanged.RemoveAllListeners();
        player2Size.onValueChanged.RemoveAllListeners();
    }

    private void OnPlayer1SizeChange(float value)
    {
        player1.verticalSize = value;
        textSizeOfPlayer1.text = value.ToString("F1");
    }

    private void OnPlayer2SizeChange(float value)
    {
        player2.verticalSize = value;
        textSizeOfPlayer2.text = value.ToString("F1");
    }
}