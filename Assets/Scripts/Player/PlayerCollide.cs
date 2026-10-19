using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField] private PlayerDataSo player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Warning: los límites se identifican por el nombre del GameObject, escrito a mano. Si alguien renombra TopLimit o DownLimit en la escena, la paleta deja de ponerse negra y no hay ningún error que lo avise.
        // Ya tenés las layers armadas (Limits, Ball, Players): resolvelo con collision.gameObject.layer, o con un componente marcador y TryGetComponent.
        if (collision.gameObject.name == "TopLimit" || collision.gameObject.name == "DownLimit")
        {
            // Bug: el color se escribe en el ScriptableObject, no en el SpriteRenderer. En el editor eso queda grabado en el .asset entre sesiones, así que la partida siguiente arranca con el color del último choque de la anterior: si lo último que tocaste fue un límite, la paleta arranca negra.
            // Ya pasó: PlayerData P1.asset quedó guardado con color (0.58, 0.49, 0.72) y moveSpeed 6.563186, y el P2 con (0.22, 0.33, 0.20) y 3.299452. Ninguno de esos números lo pusiste vos a mano.
            // Guardá el color en un campo del componente y aplicalo al SpriteRenderer; el SO tiene que ser solo el valor inicial.
            player.color = Color.black;
        }

        MoveBall ball = collision.gameObject.GetComponent<MoveBall>();

        if (ball != null)
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);
            player.color = new Color(r, g, b);
        }
    }
}