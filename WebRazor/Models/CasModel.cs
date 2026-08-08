using System.ComponentModel.DataAnnotations;

namespace WebRazor.Models
{
    public class CasModel
    {
        public string appId { get; set; } = "CAACS";
        public string region { get; set; } = "NEWRECORD";
        public string uuid { get; set; } = "00000000-0000-0000-0000-000000000000";
        public List<Node> nodes { get; set; }
    }

    public class Node
    {
        public string uuid { get; set; } = "00000000-0000-0000-0000-000000000000";
        public List<Field> fields { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
