using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Demo19_RichTextBoxAutoSize
{
    internal class AutoSizeRichTextBox : RichTextBox
    {
        public AutoSizeRichTextBox()
        {
            Height = Double.NaN;//set to nan to enable auto-height
            Loaded += ((sender, args) => AdjustSizeByConent());
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            AdjustSizeByConent();
        }



        public void AdjustSizeByConent()
        {
            var formattedText = GetFormattedText(Document);
            // ReSharper disable ConvertToConstant.Local
            var remainW = 20;
            // ReSharper restore ConvertToConstant.Local

            Width = Math.Min(MaxWidth, Math.Max(MinWidth, formattedText.WidthIncludingTrailingWhitespace + remainW));

        }

        private static FormattedText GetFormattedText(FlowDocument doc)
        {
            var output = new FormattedText(
                GetText(doc),
                CultureInfo.CurrentCulture,
                doc.FlowDirection,
                new Typeface(doc.FontFamily, doc.FontStyle, doc.FontWeight, doc.FontStretch),
                doc.FontSize,
                doc.Foreground);

            int offset = 0;

            foreach (TextElement textElement in GetRunsAndParagraphs(doc))
            {
                var run = textElement as Run;

                if (run != null)
                {
                    int count = run.Text.Length;

                    output.SetFontFamily(run.FontFamily, offset, count);
                    output.SetFontSize(run.FontSize, offset, count);
                    output.SetFontStretch(run.FontStretch, offset, count);
                    output.SetFontStyle(run.FontStyle, offset, count);
                    output.SetFontWeight(run.FontWeight, offset, count);
                    output.SetForegroundBrush(run.Foreground, offset, count);
                    output.SetTextDecorations(run.TextDecorations, offset, count);

                    offset += count;
                }
                else
                {
                    offset += Environment.NewLine.Length;
                }
            }




            return output;
        }

        private static IEnumerable<TextElement> GetRunsAndParagraphs(FlowDocument doc)
        {
            for (TextPointer position = doc.ContentStart;
                position != null && position.CompareTo(doc.ContentEnd) <= 0;
                position = position.GetNextContextPosition(LogicalDirection.Forward))
            {
                if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.ElementEnd)
                {
                    var run = position.Parent as Run;

                    if (run != null)
                    {
                        yield return run;
                    }
                    else
                    {
                        var para = position.Parent as Paragraph;

                        if (para != null)
                        {
                            yield return para;
                        }
                        else
                        {
                            var lineBreak = position.Parent as LineBreak;

                            if (lineBreak != null)
                            {
                                yield return lineBreak;
                            }
                        }
                    }
                }
            }
        }

        private static string GetText(FlowDocument doc)
        {
            var sb = new StringBuilder();

            foreach (TextElement text in GetRunsAndParagraphs(doc))
            {
                var run = text as Run;
                sb.Append(run == null ? Environment.NewLine : run.Text);
            }

            return sb.ToString();
        }

    }
}
