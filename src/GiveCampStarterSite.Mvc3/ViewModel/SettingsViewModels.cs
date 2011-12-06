namespace GiveCampStarterSite.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using GiveCampStarterSite.Models;

    public class SettingsIndexViewModels
    {
        public EventSetting Settings { get; set; }
    }

    public class SiteSettingsViewModel
    {
        public string Title { get; set; }

        [Display(Name = "Sub-title")]
        public string SubTitle { get; set; }

        public string Theme { get; set; }

        public SelectList Themes { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

    }
}