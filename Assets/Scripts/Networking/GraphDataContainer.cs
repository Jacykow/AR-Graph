using Newtonsoft.Json;

public class GraphDataContainer
{
    [JsonProperty(TypeNameHandling = TypeNameHandling.All)]
    public IGraphVisualizationData visualizationData;
}