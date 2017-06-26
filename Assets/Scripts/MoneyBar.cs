using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour {

    int money = 100;

	public void IncreaseMoney(GameObject block) {
        if (block.transform.name == "Block Small(Clone)") {
            money += 5;
            gameObject.GetComponent<Image>().fillAmount = money / 100;
        } else if (block.transform.name == "Block Medium(Clone)") {
            money += 10;
            gameObject.GetComponent<Image>().fillAmount = money / 100;
        } else if (block.transform.name == "Block Large(Clone)") {
            money += 20;
            gameObject.GetComponent<Image>().fillAmount = money / 100;
        }

    }

    public void DecreaseMoney(GameObject block) {
        if (block.transform.name == "Block Small(Clone)") {
            money -= 5;
            gameObject.GetComponent<Image>().fillAmount = money / 100;
        } else if (block.transform.name == "Block Medium(Clone)") {
            money -= 10;
            gameObject.GetComponent<Image>().fillAmount = money / 100;
        } else if (block.transform.name == "Block Large(Clone)") {
            money -= 20;
            gameObject.GetComponent<Image>().fillAmount = money / 100;
        }

    }

}
