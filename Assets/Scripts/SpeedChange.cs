using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedChange : MonoBehaviour
{
    // Suggestion: moveSpeed está declarado, es public y no lo lee ni lo escribe nadie en todo el proyecto.
    // Borralo.
    public float moveSpeed = 100f;
    [SerializeField] private PlayerDataSo player1;
    [SerializeField] private PlayerDataSo player2;
    [SerializeField] private TMP_Text textChangeSpeed;
    [SerializeField] private Slider player1Speed;
    [SerializeField] private TMP_Text textPlayer1Speed;
    [SerializeField] private TMP_Text textPlayer1OverSlider;
    [SerializeField] private Slider player2Speed;
    [SerializeField] private TMP_Text textPlayer2Speed;
    [SerializeField] private TMP_Text textPlayer2OverSlider;
    private int fontSizeBtns = 30;

    private void Awake()
    {
        player1Speed.onValueChanged.AddListener(OnPlayer1SpeedChange);
        player2Speed.onValueChanged.AddListener(OnPlayer2SpeedChange);
    }
    private void Start()
    {
        textChangeSpeed.text = "CAMBIA LA VELOCIDAD DE LOS JUGADORES";
        textChangeSpeed.alignment = TextAlignmentOptions.Center;
        textChangeSpeed.fontSize = fontSizeBtns;

        textPlayer1OverSlider.text = "Velocidad del Jugador 1";
        textPlayer1OverSlider.alignment = TextAlignmentOptions.Center;
        player1Speed.value = player1.moveSpeed;
        textPlayer1Speed.text = player1.moveSpeed.ToString("F1");

        textPlayer2OverSlider.text = "Velocidad del Jugador 2";
        textPlayer2OverSlider.alignment = TextAlignmentOptions.Center;
        player2Speed.value = player2.moveSpeed;
        textPlayer2Speed.text = player2.moveSpeed.ToString("F1");
    }

    private void OnDestroy()
    {
        player1Speed.onValueChanged.RemoveAllListeners();
        player2Speed.onValueChanged.RemoveAllListeners();
    }

    private void OnPlayer1SpeedChange(float value)
    {
        player1.moveSpeed = value;
        textPlayer1Speed.text = value.ToString("F1");
    }

    private void OnPlayer2SpeedChange(float value)
    {
        player2.moveSpeed = value;
        textPlayer2Speed.text = value.ToString("F1");
    }
}
