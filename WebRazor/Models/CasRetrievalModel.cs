using Newtonsoft.Json;

namespace WebRazor.Models
{
    public class CasRetrievalModel
    {
        public string appId { get; set; } = "CAACS";
        public string region { get; set; } = "NEWRECORD";

        public SummaryPage summaryPage { get; set; } = new SummaryPage();
        public List<SearchParam> searchParams { get; set; } = new List<SearchParam>();
    }

    public class SummaryPage
    {
        public int pageSize { get; set; } = 1;
        public int pageNumber { get; set; } = 1;
        public int offset { get; set; } = 0;
        public int pageCount { get; set; } = 0;
        public string sortFieldName { get; set; } = "DOCKET";
        public string sortDirection { get; set; } = "DESC";
        public bool showRestrictedItems { get; set; } = true;
    }

    public class SearchParam
    {
        public string fieldName { get; set; } = "";
        [JsonProperty("operator")]
        public string oper { get; set; } = "";
        public List<string> values { get; set; } = new List<string>();
    }
}
