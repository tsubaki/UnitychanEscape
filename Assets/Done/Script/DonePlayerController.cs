using UnityEngine;
using System.Collections;

namespace unitychan.escape.done
{
	public class DonePlayerController : MonoBehaviour
	{
		[SerializeField]
		Animator animator;

		[SerializeField]
		DonePlayerInput input;

		// 毎フレーム呼ばれるコールバック.
		void Update ()
		{
			// 移動中か判別し、移動中ならキャラクターの回転とアニメーションの切替を行う.
			bool isRunning = input.direction != Vector3.zero;
			animator.SetBool ("Running", isRunning);
			if (isRunning) {
				transform.rotation = Quaternion.LookRotation (input.direction, transform.up);
			}
		}

		// 「Trigger」のコライダー接触時に呼ばれるコールバック
		void OnTriggerEnter (Collider collider)
		{
			if (collider.CompareTag ("Enemy")) {
				animator.SetTrigger ("Dead");
				DoneGameController.Instance.state = DoneGameController.GameState.GameOver;
			}
			
			if (collider.CompareTag ("Goal")) {
				animator.SetTrigger ("Clear");
				DoneGameController.Instance.state = DoneGameController.GameState.GameClear;
			}
		}
	}
}