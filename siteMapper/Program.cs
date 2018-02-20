using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace siteMapper
{
    //objects
    class Page
    {
        public string URL { get; set; }
        public IList<Page> Links { get; set; }
        public Page(string url)
        {
            this.URL = url;
        }
        public void AddLink(Page link)
        {
            this.Links.Add(link);
        }
        public void AddLink(string link)
        {
            this.Links.Add(new Page(link));
        }
    }

    class Website
    {
        public string Domain { get; }
        public IList<Page> Pages { get; set; }

    }

    //methods


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
