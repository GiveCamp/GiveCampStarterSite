namespace GiveCampStarterSite.ViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class PageEditModel
    {
        public Uri Referrer { get; set; }
        public EditablePage Page { get; set; }
    }

    public class EditablePage
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Content { get; set; }
    }
}