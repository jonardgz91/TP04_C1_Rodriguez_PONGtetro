using UnityEngine;

public class Players : MonoBehaviour
{
    [SerializeField] private PlayerDataSo player;
    // Warning: rbPlayers y moveSpeed son public. rbPlayers además se pide con GetComponent en el Awake, así que el [SerializeField] no hace falta.
    // Dejalos private.
    [SerializeField] public Rigidbody2D rbPlayers;
    public float moveSpeed = 2f;
    private SpriteRenderer spriteRenderer;
    private Vector3 playerStartPosition;
    [SerializeField] private float minX = -8.5f;
    [SerializeField] private float maxX = 0f;
    [SerializeField] private float minY = -4.5f;
    [SerializeField] private float maxY = 4.5f;

    private void Awake()
    {
        rbPlayers = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerStartPosition = transform.position;
    }

    private void Start()
    {
        SetVerticalSize(player.verticalSize);
        moveSpeed = player.moveSpeed;
        spriteRenderer.color = player.color;

    }
    private void Update()
    {
        // Warning: el Update vuelve a leer el tamaño, la velocidad y el color del ScriptableObject en cada frame, y encima reasigna la escala del transform.
        // Leelos en el Start y volvé a leerlos cuando el panel de settings se cierra, o que el slider avise con un evento. Hoy son tres lecturas y una escritura de escala por frame, por jugador.
        SetVerticalSize(player.verticalSize);
        moveSpeed = player.moveSpeed;
        spriteRenderer.color = player.color;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(player.moveUp))
        {
            // Bug: la velocidad se acumula (linearVelocity += ...) y el Rigidbody2D de los dos jugadores tiene m_LinearDamping en 0, así que nada la frena. Al soltar la tecla la paleta sigue viajando hasta chocar contra un clamp, y cuanto más tiempo mantenés la tecla más rápido queda.
            // Asigná la velocidad en vez de sumarla: rbPlayers.linearVelocity = new Vector2(x, y) * moveSpeed, calculando primero la dirección de las cuatro teclas y normalizándola.
            rbPlayers.linearVelocity += (new Vector2(0, moveSpeed * Time.fixedDeltaTime));
        }

        if (Input.GetKey(player.moveDown))
        {
            rbPlayers.linearVelocity += (new Vector2(0, -moveSpeed * Time.fixedDeltaTime));
        }

        if (Input.GetKey(player.moveRight))
        {
            rbPlayers.linearVelocity += (new Vector2(moveSpeed * Time.fixedDeltaTime, 0));
        }

        if (Input.GetKey(player.moveLeft))
        {
            rbPlayers.linearVelocity += (new Vector2(-moveSpeed * Time.fixedDeltaTime, 0));
        }

        Vector2 pos = rbPlayers.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        rbPlayers.position = pos;
    }

    public void SetVerticalSize(float verticalSize) 
    {
        Vector3 scale = transform.localScale;
        scale.y = verticalSize;
        transform.localScale = scale;
    }

    public void ResetPosition()
    {
        transform.position = playerStartPosition;
        rbPlayers.linearVelocity = Vector2.zero;
    }
}