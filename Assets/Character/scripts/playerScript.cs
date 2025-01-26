    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class playerScript : MonoBehaviour
    {
        private Animator _animator;
        private Dictionary<KeyCode, bool> _key = new Dictionary<KeyCode, bool>();
        public static Vector3 RoadIntersection = Vector3.zero;
        public static bool InTurningZone = false;
        public static float[] lanePositionInitial = { -2.0f, 2.0f };
        public float[] lanePosition = { 2.0f, 2.0f };
        private int currentLane = 0;

        private void FixedUpdate()
        {

        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        void Start()
        {
            _key.Add(KeyCode.RightArrow, false);
            _key.Add(KeyCode.LeftArrow, false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _animator.SetTrigger("jump");
            }

            if (Input.GetKeyDown((KeyCode.S)) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                _animator.SetTrigger("slide");
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _key[KeyCode.LeftArrow] = true;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _key[KeyCode.RightArrow] = true;
            }

            if (_key[KeyCode.LeftArrow] && InTurningZone)
            {
                Rotate(-90.0f);
                SnapToLane();
                _key[KeyCode.LeftArrow] = false;
            }

            if (_key[KeyCode.RightArrow] && InTurningZone)
            {
                Rotate(90.0f);
                SnapToLane();
                _key[KeyCode.RightArrow] = false;
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _key[KeyCode.LeftArrow] = false;
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                _key[KeyCode.RightArrow] = false;
            }
        }

        void Rotate(float angle)
        {
            Quaternion rotation = transform.rotation;
            rotation *= Quaternion.Euler(0, angle, 0);
            transform.rotation = rotation;

            Vector3 euler = transform.eulerAngles;
            euler.y = Mathf.Round(euler.y / 90.0f) * 90.0f;
            transform.eulerAngles = euler;
        }

        void SnapToLane()
        {

        }

        private void RotatePlayer(float target)
        {
            float initialAngle = transform.eulerAngles.z;
            float elapsedTime = 0.0f;
            float duration = 0.5f;
            while (elapsedTime < duration)
            {
                float angle = Mathf.Lerp(initialAngle, target, elapsedTime / duration);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
                {

                }
            }
        }
    }