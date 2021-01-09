using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class BackendData
{
    public int id;
    public string data;

    public BackendData(int id, string data)
    {
        this.id = id;
        this.data = data;
    }
}