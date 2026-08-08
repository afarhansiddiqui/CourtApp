using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class RootObject : Dictionary<string, Dictionary<string, List<Record>>>
{
}

public class Record
{
    [JsonPropertyName("key")]
    public int Key { get; set; }

    [JsonPropertyName("guid")]
    public Guid Guid { get; set; }

    [JsonPropertyName("tablePrefix")]
    public string TablePrefix { get; set; }

    [JsonPropertyName("parentId")]
    public int ParentId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("fields")]
    public List<NodeField> Fields { get; set; } = new();

}

public class NodeField
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}