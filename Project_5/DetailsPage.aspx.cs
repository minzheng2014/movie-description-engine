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
    public partial class DetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Search"] != null) {
                string movie = Request.QueryString["i"];
                setUpWebPage(movie);
            } else
            {
                Response.Redirect("Search_Movies.aspx");
            }
        }

        public MovieDetails searchMovieDetails(string imdbID)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.omdbapi.com/?i=" + imdbID);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string contents = reader.ReadToEnd();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MovieDetails));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(contents));
            MovieDetails movieDetails = (MovieDetails)js.ReadObject(stream);
            return movieDetails;
        }

        public void setUpWebPage(string movie)
        {
                display.InnerHtml +=
                    "<img src='" + searchMovieDetails(movie).Poster + "'/>" + "<br/>" +
                    "Title: " + searchMovieDetails(movie).Title + "<br/>" +
                    "Year: " + searchMovieDetails(movie).Year + "<br/>" +
                    "Rated: " + searchMovieDetails(movie).Rated + "<br/>" +
                    "Released: " + searchMovieDetails(movie).Released + "<br/>" +
                    "Runtime: " + searchMovieDetails(movie).Runtime + "<br/>" +
                    "Genre: " + searchMovieDetails(movie).Genre + "<br/>" +
                    "Director: " + searchMovieDetails(movie).Director + "<br/>" +
                    "Writer: " + searchMovieDetails(movie).Writer + "<br/>" +
                    "Actors: " + searchMovieDetails(movie).Actors + "<br/>" +
                    "Plot: " + searchMovieDetails(movie).Plot + "<br/>" +
                    "Language: " + searchMovieDetails(movie).Language + "<br/>" +
                    "Country: " + searchMovieDetails(movie).Country + "<br/>" +
                    "Awards: " + searchMovieDetails(movie).Awards + "<br/>" +
                    "Ratings: " + ratingsToString(searchMovieDetails(movie).Ratings) + "<br/>" +
                    "Metascore: " + searchMovieDetails(movie).Metascore + "<br/>" +
                    "IMDB Rating: " + searchMovieDetails(movie).imdbRating + "<br/>" +
                    "IMDB Votes: " + searchMovieDetails(movie).imdbVotes + "<br/>" +
                    "IMDBID: " + searchMovieDetails(movie).imdbID + "<br/>" +
                    "Type: " + searchMovieDetails(movie).Type + "<br/>" +
                    "DVD: " + searchMovieDetails(movie).DVD + "<br/>" +
                    "Box Office: " + searchMovieDetails(movie).BoxOffice + "<br/>" +
                    "Production: " + searchMovieDetails(movie).Production + "<br/>" +
                    "Website: " + searchMovieDetails(movie).Website + "<br/>" +
                    "<br/>"
                    ;
        }

        public string ratingsToString(List<Rating> ratings)
        {
            string retVal = "";
            if (ratings != null) {
                
                foreach (Rating rating in ratings)
                {
                    retVal += ratingToString(rating) + " ";
                }
            }
            return retVal;
        }

        public string ratingToString(Rating rating)
        {
            return rating.Source + ": " + rating.Value;
        }
    }


    [DataContract]
    public class Rating
    {

        [DataMember(Name = "Source")]
        public string Source { get; set; }

        [DataMember(Name = "Value")]
        public string Value { get; set; }
    }

    [DataContract]
    public class MovieDetails
    {

        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Year")]
        public string Year { get; set; }

        [DataMember(Name = "Rated")]
        public string Rated { get; set; }

        [DataMember(Name = "Released")]
        public string Released { get; set; }

        [DataMember(Name = "Runtime")]
        public string Runtime { get; set; }

        [DataMember(Name = "Genre")]
        public string Genre { get; set; }

        [DataMember(Name = "Director")]
        public string Director { get; set; }

        [DataMember(Name = "Writer")]
        public string Writer { get; set; }

        [DataMember(Name = "Actors")]
        public string Actors { get; set; }

        [DataMember(Name = "Plot")]
        public string Plot { get; set; }

        [DataMember(Name = "Language")]
        public string Language { get; set; }

        [DataMember(Name = "Country")]
        public string Country { get; set; }

        [DataMember(Name = "Awards")]
        public string Awards { get; set; }

        [DataMember(Name = "Poster")]
        public string Poster { get; set; }

        [DataMember(Name = "Ratings")]
        public List<Rating> Ratings { get; set; }

        [DataMember(Name = "Metascore")]
        public string Metascore { get; set; }

        [DataMember(Name = "imdbRating")]
        public string imdbRating { get; set; }

        [DataMember(Name = "imdbVotes")]
        public string imdbVotes { get; set; }

        [DataMember(Name = "imdbID")]
        public string imdbID { get; set; }

        [DataMember(Name = "Type")]
        public string Type { get; set; }

        [DataMember(Name = "DVD")]
        public string DVD { get; set; }

        [DataMember(Name = "BoxOffice")]
        public string BoxOffice { get; set; }

        [DataMember(Name = "Production")]
        public string Production { get; set; }

        [DataMember(Name = "Website")]
        public string Website { get; set; }

        [DataMember(Name = "Response")]
        public string Response { get; set; }
    }

}