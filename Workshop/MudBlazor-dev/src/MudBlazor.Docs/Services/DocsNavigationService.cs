﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Components;
using MudBlazor.Docs.Extensions;
using MudBlazor.Docs.Models;

namespace MudBlazor.Docs.Services
{
    public interface IDocsNavigationService
    {
        NavigationFooterLink Next { get; }
        NavigationFooterLink Previous { get; }
        NavigationSection? Section { get; }
    }


    /// <summary>
    /// The aim of this class is to provide the next and previous links for navigation footer
    /// </summary>
    public class DocsNavigationService : IDocsNavigationService
    {
        private readonly NavigationManager _navigationManager;
        private readonly IMenuService _menuService;

        //the last part of the url of the component;
        //often is the name of the component, like in /components/button/
        private string CurrentLink => _navigationManager.GetComponentLink();

        /// <summary>
        /// Previous link in the menu
        /// </summary>
        public NavigationFooterLink Previous => GetNavigationLink(NavigationOrder.Previous);

        /// <summary>
        /// Next link in the menu
        /// </summary>
        public NavigationFooterLink Next => GetNavigationLink(NavigationOrder.Next);

        
        /// <summary>
        /// The section of the menu: components or api
        /// </summary>
        public NavigationSection? Section
        {
            get
            {
                // return the enum corresponding to the section
                return _navigationManager.GetSection() switch
                {
                    "components" => NavigationSection.Components,
                    "api" => NavigationSection.Api,
                    "features" => NavigationSection.Features,
                    "customization" => NavigationSection.Customization,
                    "utilities" => NavigationSection.Utilities,
                    _ => null,
                };
            }
        }

        //constructor for DI
        public DocsNavigationService(NavigationManager navigationManager, IMenuService menuService)
        {
            _navigationManager = navigationManager;
            _menuService = menuService;
        }

        /// <summary>
        /// Gets the link (next or previous) for a given url and a given section
        /// </summary>
        /// <param name="order">next or previous</param>
        /// <returns></returns>
        private NavigationFooterLink GetNavigationLink(NavigationOrder order)
        {
            List<NavigationFooterLink> orderedLinks = new List<NavigationFooterLink>();
            orderedLinks = GetOrderedMenuLinks(GetCurrentSection());

            var index = orderedLinks.FindIndex(e => e.Link == CurrentLink);
            var increment =
                order == NavigationOrder.Next
                    ? 1
                    : -1;

            var position = index + increment;
            //if out of index
            if (position < 0 || position >= orderedLinks.Count)
            {
                return null;
            }

            var navigationLink = orderedLinks.ElementAt(position);
            return navigationLink;
        }

        /// <summary>
        /// Gets the last part of links from the menu in the same order as in the menu
        /// This is the part with the name of the component
        /// </summary>
        /// <param name="section"> components or api </param>
        /// <returns></returns>
        private List<NavigationFooterLink> GetOrderedMenuLinks(NavigationSection? section)
        {
            if (section == NavigationSection.Api || section == NavigationSection.Components)
            {
                var menuElements = section == NavigationSection.Components ? _menuService.Components : _menuService.Api;
                var links = new List<NavigationFooterLink>();
                foreach (var menuElement in menuElements)
                {
                    if (menuElement.Link != null)
                    {
                        var link = section == NavigationSection.Api
                            ? ApiLink.GetApiLinkFor(menuElement.Type).Split("/").Last()
                            : menuElement.Link;

                        var name = menuElement.Name;

                        links.Add(new NavigationFooterLink(name, link));
                    }

                    if (menuElement.GroupComponents != null)
                    {
                        links.AddRange(menuElement.GroupComponents.Select(i => new NavigationFooterLink(i.Name, i.Link))
                            .OrderBy(i => i.Link));
                    }
                }

                ;
                return links;
            }
            else
            {
                var potentialLinks = section switch
                {
                    NavigationSection.Customization => _menuService.Customization,
                    NavigationSection.Features => _menuService.Features,
                    NavigationSection.Utilities => _menuService.Utilities,
                    _ => Array.Empty<DocsLink>()
                };

                return potentialLinks.Select((x => new NavigationFooterLink(x.Title, x.Href.Split("/").Last())))
                    .ToList();
            }
        }

        private NavigationSection GetCurrentSection()
        {
            var thisSection = NavigationSection.Unspecified;
            switch (Section)
            {
                case NavigationSection.Api:
                    thisSection = NavigationSection.Api;
                    break;
                case NavigationSection.Components:
                    thisSection = NavigationSection.Components;
                    break;
                case NavigationSection.Features:
                    thisSection = NavigationSection.Features;
                    break;
                case NavigationSection.Customization:
                    thisSection = NavigationSection.Customization;
                    break;
                case NavigationSection.Utilities:
                    thisSection = NavigationSection.Utilities;
                    break;
            }

            return thisSection;
        }
    }

    #region ENUMS

    public enum NavigationOrder { Previous, Next }

    public enum NavigationSection { Api, Components, Features, Customization, Utilities, Unspecified }

    #endregion
}
