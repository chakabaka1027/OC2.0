using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons : MonoBehaviour {

	public enum Size {Small, Medium, Large};
	public Size size;

	void Start(){
		size = Size.Medium;
	}

	public float iconScaleValue = 2;

	public void UpdateSizeValues(){
		if(iconScaleValue == 1){
			size = Size.Small;
		} else if(iconScaleValue == 2){
			size = Size.Medium;
		} else if(iconScaleValue == 3){
			size = Size.Large;
		}
	}

	public void IncreaseScale(){
		if(size != Size.Large){
			iconScaleValue ++;
			transform.localScale *= 1.75f;
			UpdateSizeValues();
		}
	}

	public void DecreaseScale(){
		if(size != Size.Small){
			iconScaleValue --;
			transform.localScale /= 1.75f;
			UpdateSizeValues();
		}
	}
}
