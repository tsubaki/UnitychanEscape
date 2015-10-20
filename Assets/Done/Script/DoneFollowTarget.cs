using UnityEngine;
using System.Collections;

namespace unitychan.escape.done
{
	public class DoneFollowTarget : MonoBehaviour
	{
		public Transform target;
		private Vector3 offset = new Vector3(0f, 7.5f, 0f);
		
		private void Start()
		{
			offset = transform.position - target.position;
		}

		private void LateUpdate()
		{
			transform.position = target.position + offset;
		}	
	}
}