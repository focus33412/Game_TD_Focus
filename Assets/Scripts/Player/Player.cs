using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kinnly
{
    public class Player : MonoBehaviour
    {
        // Синглтон экземпляр класса Player
        public static Player Instance { get; private set; }

        [Header("Core")]
        [SerializeField] private float moveSpeedPlayer = 5f;
        [SerializeField] private float minMoveSpeed = 0.01f;

        // Компоненты
        private Rigidbody2D rb;
        private PlayerVisual playerVisual;

        // Состояние игрока
        [HideInInspector] public Vector2 direction;
        [HideInInspector] public bool isUsingTools;
        [HideInInspector] public bool isMoving;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            rb = GetComponent<Rigidbody2D>();
            playerVisual = GetComponent<PlayerVisual>();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (isUsingTools)
            {
                rb.linearVelocity = Vector2.zero;
                return;
            }

            float xMovement = Input.GetAxisRaw("Horizontal");
            float yMovement = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(xMovement, yMovement).normalized * moveSpeedPlayer;
            rb.linearVelocity = movement;

            if (playerVisual != null && playerVisual.animator != null)
            {
                if (xMovement != 0f || yMovement != 0f)
                {
                    direction = new Vector2(xMovement, yMovement);
                    playerVisual.animator.SetFloat("Horizontal", xMovement);
                    playerVisual.animator.SetFloat("Vertical", yMovement);
                    playerVisual.animator.SetBool("Run", true);
                    isMoving = true;
                }
                else
                {
                    playerVisual.animator.SetBool("Run", false);
                    isMoving = false;
                }
            }
            else
            {
                isMoving = Mathf.Abs(movement.x) > minMoveSpeed || Mathf.Abs(movement.y) > minMoveSpeed;
            }
        }

        public void SetDirection(Vector2 _direction)
        {
            if (playerVisual != null && playerVisual.animator != null)
            {
                direction.x = Mathf.Round(_direction.x);
                direction.y = Mathf.Round(_direction.y);
                playerVisual.animator.SetFloat("Horizontal", direction.x);
                playerVisual.animator.SetFloat("Vertical", direction.y);
            }
        }

        public float GetHorizontalInput()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public float GetVerticalInput()
        {
            return Input.GetAxisRaw("Vertical");
        }

        public float GetSpeed()
        {
            float xMovement = Input.GetAxisRaw("Horizontal");
            float yMovement = Input.GetAxisRaw("Vertical");
            return Mathf.Sqrt(xMovement * xMovement + yMovement * yMovement);
        }

        public Animator GetAnimator()
        {
            return playerVisual != null ? playerVisual.animator : null;
        }
    }
}