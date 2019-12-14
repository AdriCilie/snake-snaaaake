using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private LevelGrid levelGrid;

    public void Setup(LevelGrid levelGrid) {
        this.levelGrid = levelGrid;
    }

    private void Awake() {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = .5f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
    }

    private void Update() {
        HandleInput();
        HandleGridMovement();
    }

    private void HandleInput() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (gridMoveDirection.y != -1) {
                gridMoveDirection = new Vector2Int(0, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (gridMoveDirection.y != 1) {
                gridMoveDirection = new Vector2Int(0, -1);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (gridMoveDirection.x != -1) {
                gridMoveDirection = new Vector2Int(1, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (gridMoveDirection.x != 1) {
                gridMoveDirection = new Vector2Int(-1, 0);
            }
        }
    }

    private void HandleGridMovement() {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax) {
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);
            
            levelGrid.SnakeMoved(gridPosition);
        }
    }

    private float GetAngleFromVector(Vector2Int directon) {
        float n = Mathf.Atan2(directon.y, directon.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    public Vector2Int GetGridPosition() {
        return gridPosition;
    }
}
