using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class InventorySaveManager : MonoBehaviour, IDataPersistence
{
    public BasicInventory myInventory;

    public void LoadData(GameData data)
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "/inventory.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/inventory.txt", FileMode.Open);
            
            string json = (string)bf.Deserialize(file);

            myInventory = JsonConvert.DeserializeObject<BasicInventory>(json);

            file.Close();
        }
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log(Application.persistentDataPath);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/inventory.txt");

        var json = JsonConvert.SerializeObject(myInventory);
        formatter.Serialize(file, json);

        file.Close();
    }
}
