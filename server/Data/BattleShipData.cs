using Newtonsoft.Json;

namespace ndc.Data;

public class BattleShipData{
    private string path { get; set; }
    private object data { get; set; }

    public BattleShipData(string path){
      this.path = path;
    }

    public void load(){
        string json = File.ReadAllText(path);
        this.data = JsonConvert.DeserializeObject(json);
    }

    
}