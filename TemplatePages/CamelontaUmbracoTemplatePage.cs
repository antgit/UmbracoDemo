﻿using Camelonta.Boilerplate.Classes;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Camelonta.Boilerplate.TemplatePages
{
    public abstract class CamelontaUmbracoTemplatePage : UmbracoTemplatePage
    {
        public IPublishedContent CurrentSite
        {
            get
            {
                if (_currentSite == null)
                {
                    _currentSite = Model.Content.AncestorOrSelf(1);
                }
                return _currentSite;
            }
        }
        private IPublishedContent _currentSite;

        /// <summary>
        /// The current sites search page
        /// </summary>
        public IPublishedContent SearchPage
        {
            get { return Umbraco.TypedContent(Model.Content.AncestorOrSelf(1).GetPropertyValue<int>("searchPage")); }
        }

        public List<IPublishedContent> LeftNavigation
        {
            get
            {
                return Model.Content.GetPropertyValue<bool>("hideLeftNav") ? new List<IPublishedContent>() : Model.Content.AncestorOrSelf(2).Children.FilterInvalidPages();
            }
        }
    }
}