using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    public static string Parse(string markdown)
    {
        var result = new StringBuilder();
        var list = false;

        foreach (var line in markdown.Split('\n'))
        {
            result.Append(ParseLine(line, list, out list));
        }

        if (list)
        {
            result.Append("</ul>");
        }

        return result.ToString();
    }

    #region Private helper methods

    private static string ParseLine(string markdown, bool list, out bool inListAfter)
    {
        return ParseHeader(markdown, list, out inListAfter)
            ?? ParseLineItem(markdown, list, out inListAfter)
            ?? ParseParagraph(markdown, list, out inListAfter)
            ?? throw new ArgumentException("Invalid markdown");
    }

    private static string ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        var count = 0;
        foreach (var c in markdown)
        {
            if (c != '#')
            {
                break;
            }
            count++;
        }

        if (count == 0)
        {
            inListAfter = list;
            return null;
        }

        inListAfter = false;
        var headerHtml = WrapInTag(markdown.Substring(count + 1), $"h{count}");
        return list ? $"</ul>{headerHtml}" : headerHtml;
    }

    private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            inListAfter = true;
            var innerHtml = WrapInTag(ParseText(markdown.Substring(2), true), "li");
            return list ? innerHtml : $"<ul>{innerHtml}";
        }

        inListAfter = list;
        return null;
    }

    private static string ParseParagraph(string markdown, bool list, out bool inListAfter)
    {
        inListAfter = false;
        var pHtml = ParseText(markdown, list);
        return list ? $"</ul>{pHtml}" : pHtml;
    }

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = ParseItalics(ParseBold((markdown)));
        return list ? parsedText : WrapInTag(parsedText, "p");
    }

    private static string ParseBold(string markdown) => ReplaceDelimiterWithTag(markdown, "__", "strong");

    private static string ParseItalics(string markdown) => ReplaceDelimiterWithTag(markdown, "_", "em");

    private static string ReplaceDelimiterWithTag(string markdown, string delimiter, string tag)
    {
        var pattern = $"{delimiter}(.+){delimiter}";
        var replacement = WrapInTag("$1", tag);
        return Regex.Replace(markdown, pattern, replacement);
    }

    private static string WrapInTag(string text, string tag) => $"<{tag}>{text}</{tag}>";

    #endregion
}