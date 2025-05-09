namespace MaximOS.dbLibs;
using System.Text.Json;
using System.Text.Json.Nodes;

public class JsonDatabase {
    private JsonNode? jroot;
    private string filePath;

    public JsonDatabase(string basePath) {
        filePath = basePath;
        string jsonText = File.ReadAllText(basePath);
        jroot = JsonNode.Parse(jsonText);
        if (jroot == null) jroot = new JsonObject();
    }

    public JsonNode[] GetElementsByKey(string keyName) {
        if (jroot is null) return [];
        List<JsonNode> results = [];
        FindByKeyRecursive(jroot, keyName, results);
        return [.. results];
    }

    private void FindByKeyRecursive(JsonNode? node, string keyName, List<JsonNode> results) {
        if (node is JsonObject obj) {
            foreach (var kvp in obj) {
                if (kvp.Key == keyName && kvp.Value is not null) {
                    results.Add(kvp.Value);
                }
                FindByKeyRecursive(kvp.Value, keyName, results);
            }
        } else if (node is JsonArray arr) {
            foreach (var item in arr) {
                FindByKeyRecursive(item, keyName, results);
            }
        }
    }

    public string[] NodeListToString(JsonNode[] nodeList) {
        List<string> elements = [];
        foreach (var node in nodeList) {
            elements.Add(node?.ToString() ?? "");
        }
        return [.. elements];
    }

    public string[] GetStringArray(string keyName) {
    if (jroot is null) return [];

    if (jroot[keyName] is JsonArray arr) {
        return arr.Select(x => x?.ToString() ?? "").ToArray();
    }

    return [];
}

    public string[] GetStringElementsByKey(string keyName) {
        return NodeListToString(GetElementsByKey(keyName));
    }

    public void SetFirstValueByKey(string keyName, string newValue) {
        if (jroot is null) return;
        if (!SetByKeyRecursive(jroot, keyName, newValue)) {
            // Если не найден, добавим в корень
            if (jroot is JsonObject obj) {
                obj[keyName] = newValue;
            }
        }
    }

    private bool SetByKeyRecursive(JsonNode? node, string keyName, string newValue) {
        if (node is JsonObject obj) {
            foreach (var kvp in obj) {
                if (kvp.Key == keyName) {
                    obj[kvp.Key] = newValue;
                    return true;
                }
                if (SetByKeyRecursive(kvp.Value, keyName, newValue)) return true;
            }
        } else if (node is JsonArray arr) {
            foreach (var item in arr) {
                if (SetByKeyRecursive(item, keyName, newValue)) return true;
            }
        }
        return false;
    }

    public void Save() {
        if (jroot is null) return;
        File.WriteAllText(filePath, jroot.ToJsonString(new JsonSerializerOptions {
            WriteIndented = true
        }));
    }
}
