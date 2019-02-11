using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBarController : MonoBehaviour
{
    public Image loading;

    // Start is called before the first frame update
    void Start()
    {
        loading.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        loading.fillAmount += 0.02f;
    }
}
