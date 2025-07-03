using System.Text.Json.Nodes;

namespace GenotypeApp.Application_logic
{
    internal interface IJsonConfigurable
    {
        JsonObject ToJson();
        string SetName { get; }
    }
}
