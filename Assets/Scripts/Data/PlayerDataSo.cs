// Error: `using UnityEditor.ShaderGraph.Internal;` en un ScriptableObject de runtime. El namespace UnityEditor no existe fuera del editor, así que el proyecto anda con Play pero el Build no compila.
// El archivo no usa nada de ese namespace: lo agregó el autocompletado. Borrá la línea. Es el mismo problema que arrastrás desde el TP02.
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]

public class PlayerDataSo : ScriptableObject
{
    [Header("Valores iniciales")]
    [Range(1, 10)] public float moveSpeed = 5f;
    [Range(1, 7)] public float verticalSize = 2f;

    [Header("Movimiento")]
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveRight;
    public KeyCode moveLeft;

    [Header("Color")]
    public Color color = Color.white;
}
