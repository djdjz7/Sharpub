using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpub.Constants
{
    internal static class Constants
    {
        public const string ChapterTemplate =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:epub=""http://www.idpf.org/2007/ops"" xml:lang=""zh"" lang=""zh"">
<head>
  <meta charset=""UTF-8"" />
  <title>{0}</title>
  <link rel=""stylesheet"" type=""text/css"" href=""style.css"" />
</head>
<body>
<h1>{0}</h1>
{1}
</body>
</html>";
    }
}
