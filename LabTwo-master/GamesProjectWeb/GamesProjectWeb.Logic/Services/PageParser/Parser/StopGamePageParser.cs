﻿using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text;

namespace GamesProjectWeb.Logic.Services.PageParser.Parser
{
    public class StopGamePageParser : IGamePageParser
    {
        private Uri uri = new Uri("https://stopgame.ru/news/");

        public string Host
        {
            get
            {
                return uri.Host;
            }
        }

        public string Parse(string html)
        {
            if (ReferenceEquals(html, null))
            {
                throw new ArgumentNullException(nameof(html));
            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.GetElementbyId("articleBody")?.ChildNodes;
            if (ReferenceEquals(nodes, null))
            {
                return null;
            }

            var textNodes = nodes.Where(node => node.Name.Equals("p") || node.Name.StartsWith("h")).ToList();

            StringBuilder stringBuilder = new StringBuilder();
            textNodes.ForEach(node => stringBuilder.Append(node.OuterHtml));

            return stringBuilder.ToString();
        }
    }
}
