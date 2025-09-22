using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;

    private float speed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
    private bool canShoot = true;

    private PlayerInputActions _playerInputActions;
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void OnEnable()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Shooting.performed += OnFire;
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Shooting.performed -= OnFire;
        _playerInputActions.Player.Disable();
    }


    void CalculateMovement()
    {
        Vector2 _playerInput = _playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(_playerInput.x, _playerInput.y, 0);
        _controller.Move(move * speed * Time.deltaTime);
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        if (canShoot)
        {
            Instantiate(laserPrefab, transform.position + Vector3.up, Quaternion.identity);
            canShoot = false;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Meteor"))
        {
            Debug.Log("Player hit a meteor!");
            Destroy(hit.gameObject);
            Destroy(gameObject); // optional, destroy player
        }
    }

}
