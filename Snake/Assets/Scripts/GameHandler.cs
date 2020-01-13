using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    private static GameHandler instance;
    [SerializeField] private Snake snake;
    private LevelGrid levelGrid;
    private static int score;

    private void Awake() {
        instance = this;
    }

    public void Start() {
        levelGrid = new LevelGrid(20, 20);
        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
    }

    public static int GetScore() {
        return score;
    }

    public static void AddScore() {
        score += 100;
    }
}
