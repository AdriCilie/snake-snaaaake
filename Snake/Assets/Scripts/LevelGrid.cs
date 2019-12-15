using UnityEngine;

public class LevelGrid {

    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    private int width;
    private int height;
    private Snake snake;
    
    public LevelGrid(int width, int height) {
        this.width = width;
        this.height = height;
    }

    public void Setup(Snake snake) {
        this.snake = snake;
        SpawnFood();
    }

    private void SpawnFood() {
        do {
            foodGridPosition = new Vector2Int(Random.Range(1, width - 1), Random.Range(1, height - 1));
        } while (snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition) != -1);
        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition) {
        if (snakeGridPosition == foodGridPosition) {
            Object.Destroy(foodGameObject);
            SpawnFood();

            return true;
        }

        return false;
    }
}
