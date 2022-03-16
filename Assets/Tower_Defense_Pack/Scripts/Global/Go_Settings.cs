using UnityEngine;
using System.Collections;

/// <summary>
/// Create crossfade effect when loading Example Scene
/// </summary>
public class Go_Settings : MonoBehaviour {
	public Sprite StartClicked;
	private Sprite auxClicked;

	// Use this for initialization
	void Start () {
		auxClicked = GetComponent<SpriteRenderer>().sprite;
	}

	void OnMouseDown() {GetComponent<SpriteRenderer>().sprite = StartClicked;}
	void OnMouseUp(){
		GetComponent<SpriteRenderer>().sprite = auxClicked;
		Exit();
	}

	public void Exit(){Invoke("CrossfadeDelayed",0.5f);}

	private void CrossfadeDelayed(){
		GameObject.Find("Crossfade").GetComponent<Animator>().SetBool("out",true);
		Invoke("ExitDelayed",2f);
	}

	private void ExitDelayed(){
		if(this.gameObject.name=="Settings"){
			Application.LoadLevel("Settings");
		}
	}
}
