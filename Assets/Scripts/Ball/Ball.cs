using TMPro;
using UnityEngine;

// Error: el archivo se llama Ball.cs y la clase MoveBall. Unity busca dentro de cada .cs una clase con el mismo nombre que el archivo; cuando no la encuentra, el componente no se puede agregar y los que ya están puestos pueden aparecer como Missing Script.
// En el TP03 te marqué cinco archivos así y siguen quedando cuatro: este, BtnBack.cs (clase BackBtn), BtnQuit.cs (clase UIBackBtn) y BtnStartGame.cs (clase StartGameBtn). Renombralos desde el Project de Unity.
public class MoveBall : MonoBehaviour
{
    [SerializeField] private Players player1;
    [SerializeField] private Players player2;
    [SerializeField] private PlayersScore playersScore;
    [SerializeField] private GameSettingsSo gameSettings;
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private float rightLimit = 9f;
    [SerializeField] private float leftLimit = -9f;
    [SerializeField] private float topLimit = 5f;
    [SerializeField] private float bottomLimit = -5f;
    [SerializeField] public TMP_Text textContinue;
    [SerializeField] public TMP_Text textTimer;
    // Error: no hay nada en este script que aumente la velocidad de la pelota. ballSpeed se usa solo en el AddForce del saque y ballSpeedMax solo para acotar en el FixedUpdate: entre los dos no hay ninguna línea que sume.
    // La consigna pide que la velocidad aumente con el tiempo o con los impactos. Alcanza con un OnCollisionEnter2D que haga ballSpeed = Mathf.Min(ballSpeed + incremento, ballSpeedMax) y reaplique la velocidad sobre la dirección normalizada.
    private float ballSpeed = 5f;
    private float ballSpeedMax = 12f;
    private float dirX = -1f;
    private float dirY = 1f;
    private float sameDirY;
    private bool waitContinue = false;
    private float timeLeft;

    private void Start()
    {
        ballMovement();
    }

    private void Update()
    {
        if (waitContinue)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !playersScore.matchOver)
            {
                waitContinue = false;
                textContinue.gameObject.SetActive(false);
                Time.timeScale = 1;
                ballMovement();
            }
            return;
        }

        timeLeft -= Time.deltaTime;
        textTimer.text = Mathf.Clamp(timeLeft, 0, gameSettings.timer).ToString("F2");

        if (timeLeft <= 0)
        {
            if (transform.position.x < 0)
            {
                playersScore.AddPointPlayer2();
            }
            else
            {
                playersScore.AddPointPlayer1();
            }

            ResetBall();
            return;
        }

        if (transform.position.x > rightLimit)
        {
            playersScore.AddPointPlayer1();
            ResetBall();
        }
        else if (transform.position.x < leftLimit)
        {
            playersScore.AddPointPlayer2();
            ResetBall();
        }

        if (transform.position.y > topLimit || transform.position.y < bottomLimit)
        {
            transform.position = Vector3.zero;
            ball.linearVelocity = Vector2.zero;
            ballMovement();
        }
    }

    private void FixedUpdate()
    {
        Vector2 speed = ball.linearVelocity;

        if (speed.x > ballSpeedMax) speed.x = ballSpeedMax;
        if (speed.x < -ballSpeedMax) speed.x = -ballSpeedMax;
        if (speed.y > ballSpeedMax) speed.y = ballSpeedMax;
        if (speed.y < -ballSpeedMax) speed.y = -ballSpeedMax;

        ball.linearVelocity = speed;
    }

    private void ballMovement()
    {
        Vector2 direction = new Vector2(dirX, dirY);
        ball.AddForce(direction * ballSpeed, ForceMode2D.Impulse);
        timeLeft = gameSettings.timer;
    }

    public void ResetBall()
    {
        ball.linearVelocity = Vector2.zero;
        // Warning: el objeto tiene Rigidbody2D y acá se escribe transform.position, que lo teletransporta salteando la detección de colisiones. Lo mismo en la línea 75.
        // Usá ball.position = Vector2.zero, que es la versión física del mismo reseteo.
        transform.position = Vector3.zero;
        dirX = -dirX;
        dirY = -dirY;
        waitContinue = true;
        Time.timeScale = 0;
        player1.ResetPosition();
        player2.ResetPosition();
    }
}