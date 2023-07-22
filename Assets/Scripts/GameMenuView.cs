using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuView : MonoBehaviour {
	[SerializeField]
	private Button _button;

	[SerializeField]
	private TMP_Text _text;

	private string _gamePath;

	public void Load(GameMetadata gameMetadata) {
		LoadTitle(gameMetadata.title);
		LoadImage(gameMetadata.imagePath);
		LoadGame(gameMetadata.gamePath);
	}

	private void LoadGame(string gamePath) {
		_gamePath = gamePath;
	}

	private void LoadImage(string imagePath) {
		var bytes = System.IO.File.ReadAllBytes(imagePath);
		var texture = new Texture2D(2, 2);
		texture.LoadImage(bytes);
		_button.image.sprite = Sprite.Create(
			texture,
			new Rect(0.0f, 0.0f, texture.width, texture.height),
			new Vector2(0.5f, 0.5f), 100.0f
		);
	}

	private void LoadTitle(string title) {
		_text.text = title;
	}

	public void RunGame() {
		if( _gamePath == null )
			return;
		var process = new Process();
		process.StartInfo.FileName = _gamePath;
		process.StartInfo.UseShellExecute = true;
		process.Start();
	}
}