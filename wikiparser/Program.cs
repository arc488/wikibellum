using LinqToWiki.Generated;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using wikibellum.Entities;
using WikimediaProcessing;

namespace wikiparser
{
    class Program
    {

        static void Main(string[] args)
        {

            new Starter().StartParse(65, 70);
        }


    }


}

