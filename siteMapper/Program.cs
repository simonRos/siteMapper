using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace siteMapper
{
    //objects
    class Page : IEquatable<Page>
    {
        public Website Parent { get; set; }
        public string URL { get; set; }
        public List<Page> Links { get; set; }
        public Page(string url, Website Parent)
        {
            this.URL = url;
        }
        public void AddLink(Page link)
        {
            this.Links.Add(link);
        }
        public void AddLink(string link)
        {
            this.Links.Add(new Page(link, this.Parent));
        }
        public void AddAllLinks()
        {
            string pageContent = new System.Net.WebClient().DownloadString(this.URL);
            //https://stackoverflow.com/questions/4750015/regular-expression-to-find-urls-within-a-string
            Regex regx = new Regex(Parent.Domain + "+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);
            MatchCollection matches = regx.Matches(pageContent);
            foreach (Match match in matches)
            {
                if (this.Links.Contains(new Page(match.ToString(), this.Parent))) //Links already contain a page with this url
                {
                    Page existingPage = Parent.Pages.Find(x => x.URL == match.ToString());
                    AddLink(existingPage);
                }
                else
                {
                    AddLink(match.ToString());
                }
            }
        }
        public bool Equals(Page other)
        {
            if (this.URL == other.URL)
            {
                return true;
            }
            else { return false; }
        }
    }

    class Website : IEquatable<Website>
    {
        public string Domain { get; set; }
        public List<Page> Pages { get; set; }
        public Website(string domain)
        {
            this.Domain = domain;
            AddPage(domain);
        }
        public void AddPage(Page link)
        {
            this.Pages.Add(link);
        }
        public void AddPage(string link)
        {
            this.Pages.Add(new Page(link, this));
        }
        public void AddAllPages()
        {
            foreach (Page p in Pages)
            {
                p.AddAllLinks();
            }
        }
        public bool Equals(Website other)
        {
            if (this.Domain == other.Domain)
            {
                return true;
            }
            else { return false; }
        }
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
