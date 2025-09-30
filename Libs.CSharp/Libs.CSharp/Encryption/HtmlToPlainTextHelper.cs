using System.Text.RegularExpressions;
using System.Web;

namespace Libs.CSharp.Encryption
{
    public class HtmlToPlainTextHelper
    {
        public static string Convert(string html)
        {
            if (string.IsNullOrWhiteSpace(html)) return string.Empty;
            // Thay <br> và <p> thành xuống dòng
            string text = Regex.Replace(html, @"<(br|BR)\s*/?>", "\n");
            text = Regex.Replace(text, @"</p\s*>", "\n");
            text = Regex.Replace(text, @"<p\s*>", "");
            // Loại bỏ toàn bộ thẻ HTML còn lại
            text = Regex.Replace(text, "<.*?>", string.Empty);
            // Decode các ký tự HTML (&gt; -> >, &lt; -> <, ...)
            text = HttpUtility.HtmlDecode(text);
            return text.Trim();
        }
    }
}
