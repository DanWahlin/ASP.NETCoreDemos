using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System.Text;

namespace TagHelpersAndViewComponents.TagHelpers
{
    [TargetElement("map")]
    public class MapTagHelper : TagHelper
    {
        [HtmlAttributeName("height")]
        public int Height { get; set; }

        [HtmlAttributeName("width")]
        public int Width { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var sb = new StringBuilder();
            sb.Append(@"<p><span id='MapTagHelper-status'>looking up geolocation...</span></p><br />
                        <div id='MapTagHelper-map'></div>");
            sb.Append(@"<script>
                (function() {
                    var mapContainer = null,
                        status = null;

                    function init() {
                        status = document.getElementById('MapTagHelper-status');
                        mapContainer = document.getElementById('MapTagHelper-map');
                        mapContainer.setAttribute('style', 'height:" + Height.ToString() + "px;width:" + Width.ToString() + @"px');
                        window.navigator.geolocation.getCurrentPosition(mapLocation, geoError);
                    }

                    init();
      
                    function mapLocation(pos) {
                        status.innerHTML = 'Found your location! Longitude: ' + pos.coords.longitude +
                            ' Latitude: ' + pos.coords.latitude;

                        var latlng = new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude);
                        var options = {
                            zoom: 15,
                            center: latlng,
                            mapTypeControl: true,
                            mapTypeId:
                            google.maps.MapTypeId.ROADMAP
                        };

                        var map = new google.maps.Map(mapContainer, options);

                        var marker = new google.maps.Marker({
                            position: latlng, 
                            map: map, 
                            title:'Your location'
                        });
                    }

                    function geoError(error)
                    {
                        status.html('failed lookup ' + error.message);
                    }
                })();
                </script>");
            sb.Append("<script src='http://maps.google.com/maps/api/js?sensor=false'></script>");

            output.Content.Append(sb.ToString());
            base.Process(context, output);
        }
    }
}
