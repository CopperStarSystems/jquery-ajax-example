//  --------------------------------------------------------------------------------------
// jquery-ajax-example.HomeController.cs
// 2017/06/14
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using jquery_ajax_example.Model;

namespace jquery_ajax_example.Controllers
{
    public class HomeController : Controller
    {
        IList<string> searchData;

        public HomeController()
        {
            CreateSearchData();
        }

        [HttpPost]
        public ActionResult Search(SearchModel searchModel)
        {
            IEnumerable<SearchResult> output;

            if (string.IsNullOrEmpty(searchModel.SearchTerm))
            {
                output = GetSearchResults(searchData);
            }
            else
            {
                var filteredData = FilterData(searchModel);
                output = GetSearchResults(filteredData);
            }
            Debug.WriteLine($"Search Invoked with Search Term: {searchModel.SearchTerm} - {output.Count()} records found.");
            return Json(output.ToList());
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Echo(string input)
        {
            Debug.WriteLine($"Echo Invoked with Input: {input}");
            return Json(input);
        }

        void CreateSearchData()
        {
            searchData = new List<string>
                         {
                             "Albany, New York",
                             "Annapolis, Maryland",
                             "Atlanta, Georgia",
                             "Augusta, Maine",
                             "Austin, Texas",
                             "Baton Rouge, Louisiana",
                             "Bismarck, North Dakota",
                             "Boise, Idaho",
                             "Boston, Massachusetts",
                             "Carson City, Nevada",
                             "Charleston, West Virginia",
                             "Cheyenne, Wyoming",
                             "Columbia, South Carolina",
                             "Columbus, Ohio",
                             "Concord, New Hampshire",
                             "Denver, Colorado",
                             "Des Moines, Iowa",
                             "Dover, Delaware",
                             "Frankfort, Kentucky",
                             "Harrisburg, Pennsylvania",
                             "Hartford, Connecticut",
                             "Helena, Montana",
                             "Honolulu, Hawaii",
                             "Indianapolis, Indiana",
                             "Jackson, Mississippi",
                             "Jefferson City, Missouri",
                             "Juneau, Alaska",
                             "Lansing, Michigan",
                             "Lincoln, Nebraska",
                             "Little Rock, Arkansas",
                             "Madison, Wisconsin",
                             "Montgomery, Alabama",
                             "Montpelier, Vermont",
                             "Nashville, Tennesee",
                             "Oklahoma City, Oklahoma",
                             "Olympia, Washington",
                             "Phoenix, Arizona",
                             "Pierre, South Dakota",
                             "Providence, Rhode Island",
                             "Raleigh, North Carolina",
                             "Richmond, Virginia",
                             "Sacramento, California",
                             "Salem, Oregon",
                             "Salt Lake City, Utah",
                             "Santa Fe, New Mexico",
                             "Springfield, Illinois",
                             "St. Paul, Minnesota",
                             "Tallahassee, Florida",
                             "Topeka, Kansas",
                             "Trenton, New Jersey"
                         };
        }

        IEnumerable<string> FilterData(SearchModel searchModel)
        {
            var filteredData =
                searchData.Where(p => p.ToLower().StartsWith(searchModel.SearchTerm));
            return filteredData;
        }

        IList<SearchResult> GetSearchResults(IEnumerable<string> input)
        {
            return input.Select(p => new SearchResult(p)).ToList();
        }
    }
}