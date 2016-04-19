using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;


public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		if (Social.localUser.authenticated) {
			if (GUILayout.Button ("Add Scrore To Board",GUILayout.MinWidth(300), GUILayout.MinHeight(60))) {
				Social.ReportScore (100, GGSConfig.leaderboard_testrank, (bool success) =>
				{
					Debug.Log ("ReportScore " + success);
				});
			}

			if (GUILayout.Button ("Show Board",GUILayout.MinWidth(300), GUILayout.MinHeight(60))) {
				GooglePlayGames.PlayGamesPlatform.Instance.ShowLeaderboardUI (GGSConfig.leaderboard_testrank);
			}
			if (GUILayout.Button ("Logout",GUILayout.MinWidth(300), GUILayout.MinHeight(60))) {
				PlayGamesPlatform.Instance.SignOut ();
			}
		} else {
			if (GUILayout.Button ("Login",GUILayout.MinWidth(300), GUILayout.MinHeight(60))) {
				Social.localUser.Authenticate ((bool success) =>
				{
					Debug.Log ("Authenticate " + success);
				});
			}
		}
	}
}
