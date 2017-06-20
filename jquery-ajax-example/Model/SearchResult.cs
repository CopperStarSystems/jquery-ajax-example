//  --------------------------------------------------------------------------------------
// jquery-ajax-example.SearchResult.cs
// 2017/06/14
//  --------------------------------------------------------------------------------------

namespace jquery_ajax_example.Model
{
    public class SearchResult
    {
        public SearchResult(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}