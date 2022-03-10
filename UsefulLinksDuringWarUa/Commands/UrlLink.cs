namespace UsefulLinksDuringWarUa.Commands
{
    public class UrlLink
    {
        private string Url { get; set; }
        private string Text { get; set; }

        public UrlLink(string url, string text)
        {
            Url = url;
            Text = text;
        }

        public string BuildHtmlString()
        {
            return $"<pre>*</pre><a href='{Url}'>&#160 {Text}</a>";
        }
    }
}