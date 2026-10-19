using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Data/Game/GameSettings")]

public class GameSettingsSo : ScriptableObject
{
    [Header("Partida")]
    // Warning: los dos campos son public y los escriben los sliders de settings, igual que los del PlayerDataSo. Con [SerializeField] private más un getter seguís viéndolos en el inspector y dejan de estar abiertos a todo el proyecto.
    // Ojo además con que GameSettings.asset no tiene guardada la clave `timer`: hoy funciona porque toma el 20 del inicializador del campo, pero si cambiás ese default el asset se va a mover solo.
    public int pointsToWin = 3;

    [Header("Temporizador")]
    public float timer = 20;
}
