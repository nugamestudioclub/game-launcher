using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	[SerializeField]
	private GameObject _gameMenuView;

	void Awake() {
        var gameDirectory = Path.Combine(Directory.GetCurrentDirectory(), "games");
		foreach( var gameMetadata in Games.FindGames(gameDirectory) ) {
			var gameMenuView = Instantiate(_gameMenuView, transform).GetComponent<GameMenuView>();
			gameMenuView.Load(gameMetadata);
		}
	}
}