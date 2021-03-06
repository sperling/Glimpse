﻿using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Glimpse.Core.Extensibility;
using MvcMusicStore.Models;

namespace MvcMusicStore
{
    [GlimpseConverter]
    public class CartConverter : IGlimpseConverter
    {
        public IDictionary<string, object> Serialize(object obj)
        {
            var source = obj as Cart;
            if (source == null) return null;

            return new Dictionary<string, object>
                       {
                           {"Id", source.CartId},
                           {"Count", source.Count},
                           {"Created", source.DateCreated},
                           {"RecordId", source.RecordId},
                           {"Album", new Dictionary<string, object>
                                            {
                                                {"Artist", source.Album.Artist.Name},
                                                {"Genre", source.Album.Genre.Name},
                                                {"Price", source.Album.Price.ToString("c")},
                                                {"Title", source.Album.Title},
                                            }
                               },
                       };
        }

        public IEnumerable<Type> SupportedTypes
        {
            get
            {
                yield return typeof (Cart);
                yield break;
            }
        }
    }
}