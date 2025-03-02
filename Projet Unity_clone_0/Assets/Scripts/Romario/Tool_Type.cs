using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Tool_Type : MonoBehaviour
{
    [SerializeField]
    private Text header_field;
    [SerializeField]
    private Text content_field;
    [SerializeField]
    private LayoutElement _layoutElement;
    [SerializeField]
    private int Max_Character;

    public void SetTexte(string content , string header="")
    {
        if (header == "")
        {
            header_field.GameObject().SetActive(false);
        }
        else
        {
            header_field.GameObject().SetActive(true);
            header_field.text = header;
        }

        content_field.text = content;
        
        int Header_length = header_field.text.Length;
        int contenu_length = content_field.text.Length;
        _layoutElement.enabled = (Header_length > Max_Character || contenu_length > Max_Character) ? true : false;
    }


 
}
