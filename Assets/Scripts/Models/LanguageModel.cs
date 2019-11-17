using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageModel : BoxClickerElement
{
    
    [SerializeField] private  Dictionary<string, bool> languagesList = new Dictionary<string, bool>();

    public Dictionary<string, bool> GetLanguagesList() { return languagesList; }

    Dictionary<string, string> messages = new Dictionary<string, string>();

    public void Initialization()
    {
        messages.Add("english_gun_01", "Gun 01"); messages.Add("russian_gun_01", "Лазер 01");

        Dictionary<string, bool> loadlanguagesList = SaveManager.use.LoadLanguages();
        if (loadlanguagesList != null)
        {
            languagesList = loadlanguagesList;
        }
        else
        {
            languagesList.Add("english", true);
            languagesList.Add("russian", false);
        }
    }

    public string GetMessage(string name)
    {
        string id = GetCurrentLanguage() + name;

        if (messages.ContainsKey(id))
        {
            return messages[id];
        }
        return "";
    }

    public string GetCurrentLanguage()
    {
        foreach (var lang in languagesList)
        {
            if(lang.Value == true) return lang.Key;
        }
        return "";
    }
    
    public void SetCurrentLanguage(string language)
    {
        Dictionary<string, bool> newLanguagesList = new Dictionary<string, bool>(languagesList);

        foreach (var lang in newLanguagesList)
        {
            languagesList[lang.Key] = false;
            if (lang.Key == language)
            {
                languagesList[lang.Key] = true;
                print(lang.Key);
            }
        }
        SaveManager.use.SaveLanguages();
    }
}
