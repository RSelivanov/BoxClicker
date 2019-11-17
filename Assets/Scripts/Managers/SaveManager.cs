using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : BoxClickerElement
{
    public static SaveManager use = null;

    void Awake()
    {
        use = this;
    }

    //-----------------------

    public void SavePoints()
    {
        string path = Application.persistentDataPath + "/pointsdata.bc";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        Dictionary<string, PointData> pointList = app.model.pointModel.GetPointList();

        formatter.Serialize(stream, pointList);
        stream.Close();
    }

    public Dictionary<string, PointData> LoadPoints()
    {
        string path = Application.persistentDataPath + "/pointsdata.bc";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Dictionary<string, PointData> pointList = formatter.Deserialize(stream) as Dictionary<string, PointData>;
            stream.Close();

            return pointList;
        }
        else
        {
            return null;
        }
    }

    public void RemovePoints()
    {
        string path = Application.persistentDataPath + "/pointsdata.bc";
        File.Delete(path);
    }

    public void SaveSkills()
    {
        string path = Application.persistentDataPath + "/skillsdata.bc";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        List<SkillData> skillList = app.model.skillModel.GetSkillList();

        formatter.Serialize(stream, skillList);
        stream.Close();
    }

    public List<SkillData> LoadSkills()
    {
        string path = Application.persistentDataPath + "/skillsdata.bc";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<SkillData> skillList = formatter.Deserialize(stream) as List<SkillData>;
            stream.Close();

            return skillList;
        }
        else
        {
            return null;
        }
    }

    public void RemoveSkills()
    {
        string path = Application.persistentDataPath + "/skillsdata.bc";
        File.Delete(path);
    }

    public void SaveAchievements()
    {
        string path = Application.persistentDataPath + "/achievementsdata.bc";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        List<AchievementData> achievementList = app.model.achievementModel.GetAchievementList();

        formatter.Serialize(stream, achievementList);
        stream.Close();
    }

    public List<AchievementData> LoadAchievements()
    {
        string path = Application.persistentDataPath + "/achievementsdata.bc";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<AchievementData> achievementList = formatter.Deserialize(stream) as List<AchievementData>;
            stream.Close();

            return achievementList;
        }
        else
        {
            return null;
        }
    }

    public void RemoveAchievements()
    {
        string path = Application.persistentDataPath + "/achievementsdata.bc";
        File.Delete(path);
    }



    public void SaveCoins(long coins)
    {
        PlayerPrefs.SetString("coins", coins.ToString());
    }

    public long? LoadCoins()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            return Convert.ToInt64(PlayerPrefs.GetString("coins"));
        }
        return null;
    }

    public void RemoveCoins()
    {
        PlayerPrefs.DeleteKey("coins");
    }



    public void SaveMusicSettings(bool music)
    {
        PlayerPrefs.SetInt("music", Convert.ToInt32(music));
    }

    public bool? LoadMusicSettings()
    {
        if (PlayerPrefs.HasKey("music"))
        {
            return Convert.ToBoolean(PlayerPrefs.GetInt("music"));
        }
        return null;
    }

    public void RemoveMusicSettings()
    {
        PlayerPrefs.DeleteKey("music");
    }



    public void SaveSoundSettings(bool music)
    {
        PlayerPrefs.SetInt("sound", Convert.ToInt32(music));
    }

    public bool? LoadSoundSettings()
    {
        if (PlayerPrefs.HasKey("sound"))
        {
            return Convert.ToBoolean(PlayerPrefs.GetInt("sound"));
        }
        return null;
    }

    public void RemoveSoundSettings()
    {
        PlayerPrefs.DeleteKey("sound");
    }


    public void SaveTime(int time)
    {
        PlayerPrefs.SetInt("time", time);
    }

    public int? LoadTime()
    {
        if (PlayerPrefs.HasKey("time"))
        {
            return PlayerPrefs.GetInt("time");
        }
        return null;
    }

    public void RemoveTime()
    {
        PlayerPrefs.DeleteKey("time");
    }
    
    public void SaveLanguages()
    {
        string path = Application.persistentDataPath + "/languagesdata.bc";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        Dictionary<string, bool> languagesList = app.model.languageModel.GetLanguagesList();

        formatter.Serialize(stream, languagesList);
        stream.Close();
    }

    public Dictionary<string, bool> LoadLanguages()
    {
        string path = Application.persistentDataPath + "/languagesdata.bc";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Dictionary<string, bool> languagesList = formatter.Deserialize(stream) as Dictionary<string, bool>;
            stream.Close();

            return languagesList;
        }
        else
        {
            return null;
        }
    }

    public void RemoveLanguages()
    {
        string path = Application.persistentDataPath + "/languagesdata.bc";
        File.Delete(path);
    }
    
}
