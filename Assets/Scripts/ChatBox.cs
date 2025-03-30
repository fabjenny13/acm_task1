using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour
{
    public Image bgImage;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    private void Awake()
    {
        bgImage = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();

    }

    public void Setup(string text)
    {
        this.text.text = text;
        this.text.ForceMeshUpdate();
        Vector2 textSize = this.text.GetRenderedValues(false);

        Vector2 padding = new Vector2(2f, 2f);


        bgImage.GetComponent<RectTransform>().sizeDelta += textSize + padding;
    }
}

