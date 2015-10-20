using UnityEngine;
using System.Collections;
using unitychan.escape.done;
using UnityEngine.UI;

namespace unitychan.escape.done
{

	public class DoneGameController : MonoBehaviour
	{
		public static DoneGameController Instance {
			get;
			private set;
		}

		void Awake ()
		{
			if (Instance == null) {
				Instance = this;
			}
		}

		public enum GameState
		{
			Playing = 0,
			GameOver = 1,
			GameClear = 2,
		}
		public GameState state;

		[SerializeField]
		GameObject player;

		[SerializeField]
		GameObject gameOver, gameClear, startUI;

		[SerializeField]
		Text timeLabel;

		private static float time;


		void Start ()
		{
			StartCoroutine (Flow ());
		}

		IEnumerator Flow ()
		{
			DonePlayerInput playerInput = player.GetComponent<DonePlayerInput> ();
			state = GameState.Playing;

			yield return StartCoroutine (StartFlow ());

			while (state == GameState.Playing) {
				time += Time.deltaTime;
				timeLabel.text = time.ToString ("00.00");
				yield return null;
			}

			PlayerEnable (false);

			if (state == GameState.GameOver) {
				yield return StartCoroutine (GameOverFlow ());
			}
			if (state == GameState.GameClear) {
				yield return StartCoroutine (StageClearFlow ());	
			}
		}

		void PlayerEnable (bool isEnable)
		{
			player.GetComponent<DonePlayerInput> ().enabled = isEnable;
		}

		IEnumerator StartFlow ()
		{
			timeLabel.text = time.ToString ("00.00");

			startUI.SetActive (true);
			PlayerEnable (false);

			Animator animator = startUI.GetComponent<Animator> ();
			Text text = startUI.GetComponent<Text> ();

			for (int i = 0; i < 3; i++) {
				text.text = (3 - i).ToString ();
				animator.Play ("CountDown", 0, 0);

				yield return new WaitForSeconds (1);
			}

			text.text = "GO";
			PlayerEnable (true);

			yield return new WaitForSeconds (1);

			startUI.SetActive (false);
		}

		IEnumerator GameOverFlow ()
		{
			yield return new WaitForSeconds (1f);

			gameOver.SetActive (true);

			yield return new WaitForSeconds (1f);

			Application.LoadLevel (Application.loadedLevel);
		}

		IEnumerator StageClearFlow ()
		{
			yield return new WaitForSeconds (1f);

			gameClear.SetActive (true);

			yield return new WaitForSeconds (2);
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}

}
