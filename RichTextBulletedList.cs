using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1 {
    public class RichTextBulletedList : BulletedList {

        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(sw);
            String rendered = "";

            base.Render(htmlWriter);
            Match m = Regex.Match(sb.ToString(), "<li>.*?</li>");
            while (m.Success) {
                String line = Regex.Replace(m.Groups[0].ToString(), "\\[b\\](.*?)\\[/b\\]", "<strong>$1</strong>");
                line = Regex.Replace(line, "\\[i\\](.*?)\\[/i\\]", "<i>$1</i>");
                line = Regex.Replace(line, "\\[u\\](.*?)\\[/u\\]", "<u>$1</u>");
                rendered += line;
                m = m.NextMatch();
            }

            rendered = Regex.Replace(rendered, "(?<!<)<(?!<)", "<");
            rendered = Regex.Replace(rendered, "(?<!>)>(?!>)", ">");
            rendered = Regex.Replace(rendered, "(?<!\")\"(?!\")", "\"");

            rendered = rendered.Replace("<<", "<")
                .Replace(">>", ">")
                .Replace("\"\"", "\"");

            writer.Write(rendered);
        }
    }
}