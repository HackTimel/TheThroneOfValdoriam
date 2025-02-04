using System;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
/*
public static class SaveScript
{

    public static void SaveMenuSound(MusicManager music)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Music.tov/";
        FileStream stream = new FileStream(path, FileMode.Create);

        MenuData data = new MenuData(music);
        Console.WriteLine(data);
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static MenuData LoadMenuSound()
    {
        string path = Application.persistentDataPath + "/Music.tov/";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            MenuData data = formatter.Deserialize(stream) as MenuData;
            stream.Close();
            Console.WriteLine("loaded succesfully");
            return data;
        }

        throw new Exception("No file found"); 


    }
    
}
*/