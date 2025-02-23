using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
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
    


    // Update is called once per frame
    void Update()
    {
        int Header_length = header_field.text.Length;
        int contenu_length = content_field.text.Length;
        _layoutElement.enabled = (Header_length > Max_Character || contenu_length > Max_Character) ? true : false;
        

    }
}
