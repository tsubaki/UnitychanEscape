using UnityEngine;
using System.Collections;

public class DeactivateWithTime : MonoBehaviour {

	[SerializeField, Range(1, 30)]
	float time= 2;

	void OnEnable ()
	{
		StartCoroutine(Deactivate());
	}

	IEnumerator Deactivate()
	{
		yield return new WaitForSeconds(time);
		gameObject.SetActive(false);
	}
}
