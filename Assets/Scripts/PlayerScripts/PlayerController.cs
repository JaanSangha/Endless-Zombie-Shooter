using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isFiring;
    public bool isReloading;
    public bool isJumping;
    public bool isRunning;
    public bool isAiming;

    public InventoryComponent inventory;

    public bool isInventoryOn = false;
    public bool isPauseOn = false;
    public GameUIController gameUIController;
    public WeaponHolder weaponHolder;
    public HealthComponent healthComponent;
    public MovementComponent movementComponent;
    public GameObject pauseScreen;
    private void Awake()
    {
        if (inventory == null)
        {
            inventory = GetComponent<InventoryComponent>();
        }
        //if (gameUIController == null)
        //{
        //    gameUIController = GetComponent<GameUIController>();
        //}
        if (weaponHolder == null)
        {
            weaponHolder = GetComponent<WeaponHolder>();
        }
        if(healthComponent == null)
        {
            healthComponent = GetComponent<HealthComponent>();
        }
        if(movementComponent == null)
        {
            movementComponent = GetComponent<MovementComponent>();
        }
        if (gameUIController == null)
        {
            gameUIController = FindObjectOfType<GameUIController>();
        }
    }

    public void OnInventory(InputValue value)
    {
        isInventoryOn = !isInventoryOn;
        gameUIController.ToggleInventory(isInventoryOn);
        AppEvents.InvokeMouseCursorEnable(isInventoryOn);

    }

    public void OnPause(InputValue value)
    {
        if(isPauseOn)
        {
            Time.timeScale = 1;
            isPauseOn = false;
            pauseScreen.SetActive(false);
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 0;
            isPauseOn = true;
            pauseScreen.SetActive(true);
            Cursor.visible = true;
        }
    }

}
