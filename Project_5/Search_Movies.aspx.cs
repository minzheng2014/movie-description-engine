using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Net;
using System.Web.Hosting;
using System.IO;

namespace Project_5
{
    public partial class Search_Movies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Return"] != null)
            {
                display.InnerHtml = Session["Return"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string searchItem = tbxSearch.Text;
            if (!searchItem.Equals(""))
            {
                display.InnerHtml = "";
                Search search = searchMovie(searchItem);
                setUpWebPage(search);
                Session["Search"] = tbxSearch.Text;
            }
        }

        public Search searchMovie(string searchItem)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.omdbapi.com/?s=%22" + searchItem + "%22");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string contents = reader.ReadToEnd();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Search));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contents));
            Search search = (Search)js.ReadObject(stream);
            return search;
        }

        public void setUpWebPage(Search search)
        {
            if (search.Response.Equals("True"))
            {
                foreach (Movie movie in search.movies)
                {
                    display.InnerHtml +=
                        "Title: " + movie.Title + "<br/>" +
                        "<a href=\"DetailsPage.aspx/?i=" + movie.imdbID + "\"><img src='" + movie.Poster + "'/></a>" + "<br/>" +
                        "<br/>"
                        ;
                }
                Session["Return"] = display.InnerHtml;
            }
        }

    }

    [DataContract]
    public class Search
    {
        [DataMember(Name = "Search")]
        public List<Movie> movies { get; set; }
        [DataMember(Name = "Response")]
        public string Response { get; set; }
    }

    [DataContract]
    public class Movie
    {

        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Year")]
        public string Year { get; set; }

        [DataMember(Name = "imdbID")]
        public string imdbID { get; set; }

        [DataMember(Name = "Type")]
        public string Type { get; set; }

        [DataMember(Name = "Poster")]
        public string Poster { get; set; }
    }
}