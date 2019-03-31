using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour {
    private Renderer rend;
    private Color color;

    public string sceneName;
    float C;

    void Start()
    {
        rend = GetComponent<Renderer>();
        // ここに初期化を入れました
        rend.material.color = new Color(1f, 1f, 1f, 0.0f);
        C = 0;
    }

    void Update()
    {
        C = C + Time.deltaTime * 1f;
        rend.material.color = new Color(1f, 1f, 1f, C);

        // 浮動小数点数の時は後ろにfをつけます
        if (C>= 1.0f )
        {
            rend.material.color = new Color(1f, 1f, 1f, 1f);
            SceneManager.LoadScene(sceneName);
        }
    }
}
