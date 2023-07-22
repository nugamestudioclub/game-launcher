using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Games {
	public static IEnumerable<GameMetadata> FindGames(string directory) {
		foreach( var folder in Directory.GetDirectories(directory) ) {
			var file = Path.Combine(folder, "launch.json");
			if( File.Exists(file) ) {
				var json = File.ReadAllText(file);
				var gameMetadata = JsonUtility.FromJson<GameMetadata>(json);
				gameMetadata.gamePath = Path.Combine(folder, gameMetadata.gamePath);
				gameMetadata.imagePath = Path.Combine(folder, gameMetadata.imagePath);
				yield return gameMetadata;
			}
		}
	}
}