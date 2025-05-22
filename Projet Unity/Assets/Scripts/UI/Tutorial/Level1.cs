using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject Panel;
    
    public TextMeshProUGUI instructions;

    public int compteur;
    public bool First_Isover = false;
    
    public bool last_Isover = false;

    public int instrcution_index;
    public string[] liste_tuto;

    public DummySound dummy;

    public string next_instruction
    {
        get
        {
            if (instrcution_index < liste_tuto.Length - 1)
            {
                instrcution_index++;
                return liste_tuto[instrcution_index];
            }
            return "Il semblerait que je n'ai plus rien à t'expliquer";
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        liste_tuto = new[]
        {
            "Pour avancer, appuie sur la touche Z",
            "Super, maintenant recule avec S",
            "Ensuite à droite avec D",
            "Et enfin à gauche avec Q",
            "Devant toi, cette chose... c'est un ennemi, débarasses toi en avec CLIC GAUCHE, CLIC DROIT, A ou T!",
            "Bon, on dirait que j'ai plus besoin de t'apprendre quoique ce soit, traverse la grande porte, et bon courage..."
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (!First_Isover)
        {
            compteur++;
            if (compteur % 900 == 0)
            {
                First_Isover = true;
                instructions.text = liste_tuto[0];
                instrcution_index = 0;
                compteur = 0;
            }
        }

        if (instrcution_index == 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                instructions.text = next_instruction;
            }
        }

        if (instrcution_index == 1)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                instructions.text = next_instruction;
            }
        }
        if (instrcution_index == 2)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                instructions.text = next_instruction;
            }
        }
        if (instrcution_index == 3)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                instructions.text = next_instruction;
            }
        }
        if (instrcution_index == 4)
        {
            if (dummy.death)
            {
                instructions.text = next_instruction;
            }
        }

        if (instrcution_index == 5)
        {
            if (!last_Isover)
            {
                compteur++;
                if (compteur % 900 == 0)
                {
                    last_Isover = true;
                    Panel.SetActive(false);
                }
            }
        }
        
    }
    
    
    
}
