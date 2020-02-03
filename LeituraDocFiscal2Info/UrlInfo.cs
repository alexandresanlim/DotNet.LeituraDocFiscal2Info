﻿using LeituraDocFiscal2Info.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace LeituraDocFiscal2Info
{
    public static class UrlInfo
    {
        public static DocInfo Read(this string url)
        {
            using (var client = new WebClient())
            {
                string result = client.DownloadString(url);

                return new DocInfo
                {
                    Company = new Regex(@"<div id=""u20"" class=""txtTopo"">(.*?)</div>").Match(result).Groups[1].Value,
                    Total = new Regex(@"<span class=""totalNumb txtMax"">(.*?)</span>").Match(result).Groups[1].Value,
                    AccessKey = new Regex(@"<span class=""chave"">(.*?)</span>").Match(result).Groups[1].Value.Replace(" ", "")
                };
            }
        }
    }
}
