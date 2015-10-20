using UnityEngine;
using System.Collections;

namespace unitychan.escape.done
{
	public class DonePlayerInput : MonoBehaviour
	{
		// CharacterController への参照をInspectorで設定出来るようにする
		[SerializeField]
		CharacterController characterController = null;

		public Vector3 direction{ get; private set; }

		// 毎フレーム呼ばれるコールバック.
		void Update ()
		{
			// キー入力を取得する.
			float x = Input.GetAxis ("Horizontal");
			float z = Input.GetAxis ("Vertical");

			direction = new Vector3 (x, 0, z);

			// キャラクターコントローラーを使用して移動する.
			characterController.SimpleMove (direction.normalized * 3);
		}
	}
}