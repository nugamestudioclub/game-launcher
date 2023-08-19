using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameMenuView;



    void Awake()
    {
        var gameDirectory = Path.Combine(Directory.GetCurrentDirectory(), "games");
        var games = Games.FindGames(gameDirectory).ToList();
        SetScrollStretch(games.Count);
        foreach (var gameMetadata in games)
        {
            var gameMenuView = Instantiate(_gameMenuView, transform).GetComponent<GameMenuView>();
            gameMenuView.Load(gameMetadata);
        }
    }

    private void SetScrollStretch(int numGames)
    {
        var grid = GetComponent<GridLayoutGroup>();
        int colCount = grid.constraintCount;
        int rowCount = (numGames - 1) / colCount + 1;
        int cellSize = (int)grid.cellSize.y;
        int spacing = (int)grid.spacing.y;
        int totalStretch = rowCount * (cellSize + spacing);
        var rectTransform = GetComponent<RectTransform>();
        print($"col count: {colCount}");
        print($"row count: {rowCount}");
        print($"cell size: {cellSize}");
        print($"spacing: {spacing}");
        print($"total stretch: {totalStretch}");
        rectTransform.offsetMin = new Vector2(0, -totalStretch/2);
    }
}