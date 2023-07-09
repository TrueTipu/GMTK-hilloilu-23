using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay : Singleton<TextDisplay>
{
    [SerializeField] UnityEngine.UI.Image img;
    [SerializeField] List<TextField> textFields;
    [SerializeField] TMPro.TextMeshProUGUI text;

    TextField currentField;

    public void Show(string name)
    {
        TextField _text = textFields.Find( t => t.Name == name);

        AudioManager.Instance.PlayRandom(new string[] { "Mumina1", "Mumina2", "Mumina3", "Mumina5" });

        img.gameObject.SetActive(true);
        text.text = _text.ToString();
        currentField = _text;
    }
    private void Update()
    {
        if(currentField != null)
        {
            if(currentField.Button == KeyCode.Alpha5)
            {
                Invoke(nameof(DeActiv), 5);
                currentField.Button = KeyCode.Escape;
            }
            else if (Input.GetKeyDown(currentField.Button))
            {
                DeActiv();
            }
        }
    }
    void DeActiv()
    {
        currentField = null;
        img.gameObject.SetActive(false);
    }
}
[System.Serializable]
class TextField
{
    [SerializeField] public string Name;

    [SerializeField] public KeyCode Button;


    [Multiline]
    [SerializeField] string teksti;

    public override string ToString()
    {
        return teksti;
    }


}