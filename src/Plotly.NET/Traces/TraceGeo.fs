﻿namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices


//Figures can include two different types of map subplots: geo subplots for outline maps and mapbox subplots for tile maps.
///The following trace types support attributes named geo or mapbox, whose values must refer to corresponding objects in the layout
///i.e. geo="geo2" etc. Note that attributes such as layout.geo2 and layout.mapbox etc do not have to be explicitly defined, in which
///case default values will be inferred. Multiple traces of a compatible type can be placed on the same subplot.
///
/// The following trace types are compatible with geo subplots via the geo attribute:
///
/// - scattergeo, which can be used to draw individual markers, line and curves and filled areas on outline maps
///
/// - choropleth: colored polygons on outline maps
///
/// The following trace types are compatible with mapbox subplots via the mapbox attribute:
///
/// - scattermapbox, which can be used to draw individual markers, lines and curves and filled areas on tile maps
///
/// - choroplethmapbox: colored polygons on tile maps
///
/// - densitymapbox: density heatmaps on tile maps

type TraceGeo(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "scattergeo" applying the given trace styling function
    static member initScatterGeo(applyStyle: TraceGeo -> TraceGeo) = TraceGeo("scattergeo") |> applyStyle

    ///initializes a trace of type "choropleth" applying the given trace styling function
    static member initChoroplethMap(applyStyle: TraceGeo -> TraceGeo) = TraceGeo("choropleth") |> applyStyle

type TraceGeoStyle() =

    static member SetGeo([<Optional; DefaultParameterValue(null)>] ?GeoId: StyleParam.SubPlotId) =
        (fun (trace: TraceGeo) ->

            GeoId |> DynObj.setValueOptBy trace "geo" StyleParam.SubPlotId.toString

            trace)

    /// <summary>
    /// Creates a function that applies the styles of a choropleth map to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Z">Sets the color values.</param>
    /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
    /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
    /// <param name="Locations">Sets the coordinates via location IDs or names. See `locationmode` for more info.</param>
    /// <param name="Text">Sets the text elements associated with each location.</param>
    /// <param name="MultiText">Sets the text elements associated with each location.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Geo">Sets a reference between this trace's geospatial coordinates and a geographic map. If "geo" (the default value), the geospatial coordinates refer to `layout.geo`. If "geo2", the geospatial coordinates refer to `layout.geo2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="ColorBar">Sets the colorbar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`zmin` and `zmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
    /// <param name="Zmin">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="Zmid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
    /// <param name="Zmax">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ChoroplethMap
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Z: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
            [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
            [<Optional; DefaultParameterValue(null)>] ?Locations: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Geo: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: ColorBar,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorScale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ZAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?Zmin: float,
            [<Optional; DefaultParameterValue(null)>] ?Zmid: float,
            [<Optional; DefaultParameterValue(null)>] ?Zmax: float,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: #Trace) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Ids |> DynObj.setValueOpt trace "ids"
            Z |> DynObj.setValueOpt trace "z"
            GeoJson |> DynObj.setValueOpt trace "geojson"
            FeatureIdKey |> DynObj.setValueOpt trace "featureidkey"
            Locations |> DynObj.setValueOpt trace "locations"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Geo |> DynObj.setValueOptBy trace "geo" StyleParam.SubPlotId.convert
            ColorAxis |> DynObj.setValueOptBy trace "coloraxis" StyleParam.SubPlotId.convert
            Marker |> DynObj.setValueOpt trace "marker"
            ColorBar |> DynObj.setValueOpt trace "colorbar"
            AutoColorScale |> DynObj.setValueOpt trace "autocolorscale"
            ColorScale |> DynObj.setValueOptBy trace "colorscale" StyleParam.Colorscale.convert
            ShowScale |> DynObj.setValueOpt trace "showscale"
            ReverseScale |> DynObj.setValueOpt trace "reversescale"
            ZAuto |> DynObj.setValueOpt trace "zauto"
            Zmin |> DynObj.setValueOpt trace "zmin"
            Zmid |> DynObj.setValueOpt trace "zmid"
            Zmax |> DynObj.setValueOpt trace "zmax"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            Selected |> DynObj.setValueOpt trace "selected"
            Unselected |> DynObj.setValueOpt trace "unselected"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            LocationMode |> DynObj.setValueOptBy trace "locationmode" StyleParam.LocationFormat.convert
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace)

    /// <summary>
    /// Creates a function that applies the styles of a scattergeo plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Lat">Sets the latitude coordinates (in degrees North).</param>
    /// <param name="GeoJson">Sets optional GeoJSON data associated with this trace. If not given, the features on the base map are used when `locations` is set. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
    /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Only has an effect when `geojson` is set. Support nested property, for example "properties.name".</param>
    /// <param name="Locations">Sets the coordinates via location IDs or names. Coordinates correspond to the centroid of each location given. See `locationmode` for more info.</param>
    /// <param name="Lon">Sets the longitude coordinates (in degrees East).</param>
    /// <param name="Text">Sets text elements associated with each (lon,lat) pair or item in `locations`. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) or `locations` coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (lon,lat) pair or item in `locations`. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) or `locations` coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variables `lat`, `lon`, `location` and `text`.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variables `lat`, `lon`, `location` and `text`.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (lon,lat) pair or item in `locations`. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) or `locations` coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (lon,lat) pair or item in `locations`. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) or `locations` coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Geo">Sets a reference between this trace's geospatial coordinates and a geographic map. If "geo" (the default value), the geospatial coordinates refer to `layout.geo`. If "geo2", the geospatial coordinates refer to `layout.geo2`, and so on.</param>
    /// <param name="Marker">Sets the marker of the trace.</param>
    /// <param name="Line">Sets the Line of the trace.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
    /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape.</param>
    /// <param name="FillColor">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="LocationMode">Determines the set of locations used to match entries in `locations` to regions on the map. Values "ISO-3", "USA-states", "country names" correspond to features on the base map and value "geojson-id" corresponds to features from a custom GeoJSON linked to the `geojson` attribute.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ScatterGeo
        (
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional; DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional; DefaultParameterValue(null)>] ?LegendRank: int,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroup: string,
            [<Optional; DefaultParameterValue(null)>] ?LegendGroupTitle: Title,
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Mode: StyleParam.Mode,
            [<Optional; DefaultParameterValue(null)>] ?Ids: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Lat: #IConvertible seq,
            [<Optional; DefaultParameterValue(null)>] ?GeoJson: obj,
            [<Optional; DefaultParameterValue(null)>] ?FeatureIdKey: string,
            [<Optional; DefaultParameterValue(null)>] ?Locations: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Lon: #IConvertible seq,
            [<Optional; DefaultParameterValue(null)>] ?Text: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextPosition: seq<StyleParam.TextPosition>,
            [<Optional; DefaultParameterValue(null)>] ?TextTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiTextTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverText: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverText: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?HoverInfo: StyleParam.HoverInfo,
            [<Optional; DefaultParameterValue(null)>] ?HoverTemplate: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Meta: string,
            [<Optional; DefaultParameterValue(null)>] ?CustomData: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Geo: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Marker: Marker,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?SelectedPoints: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Selected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?Unselected: TraceSelection,
            [<Optional; DefaultParameterValue(null)>] ?ConnectGaps: bool,
            [<Optional; DefaultParameterValue(null)>] ?Fill: StyleParam.Fill,
            [<Optional; DefaultParameterValue(null)>] ?FillColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?HoverLabel: Hoverlabel,
            [<Optional; DefaultParameterValue(null)>] ?LocationMode: StyleParam.LocationFormat,
            [<Optional; DefaultParameterValue(null)>] ?UIRevision: string
        ) =
        (fun (trace: #Trace) ->

            Name |> DynObj.setValueOpt trace "name"
            Visible |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
            ShowLegend |> DynObj.setValueOpt trace "showlegend"
            LegendRank |> DynObj.setValueOpt trace "legendrank"
            LegendGroup |> DynObj.setValueOpt trace "legendgroup"
            LegendGroupTitle |> DynObj.setValueOpt trace "legendgrouptitle"
            Opacity |> DynObj.setValueOpt trace "opacity"
            Mode |> DynObj.setValueOptBy trace "mode" StyleParam.Mode.convert
            Ids |> DynObj.setValueOpt trace "ids"
            Lat |> DynObj.setValueOpt trace "lat"
            GeoJson |> DynObj.setValueOpt trace "geojson"
            FeatureIdKey |> DynObj.setValueOpt trace "featureidkey"
            Locations |> DynObj.setValueOpt trace "locations"
            Lon |> DynObj.setValueOpt trace "lon"
            (Text, MultiText) |> DynObj.setSingleOrMultiOpt trace "text"

            (TextPosition, MultiTextPosition)
            |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert

            (TextTemplate, MultiTextTemplate) |> DynObj.setSingleOrMultiOpt trace "texttemplate"
            (HoverText, MultiHoverText) |> DynObj.setSingleOrMultiOpt trace "hovertext"
            HoverInfo |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
            (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
            Meta |> DynObj.setValueOpt trace "meta"
            CustomData |> DynObj.setValueOpt trace "customdata"
            Geo |> DynObj.setValueOptBy trace "geo" StyleParam.SubPlotId.convert
            Marker |> DynObj.setValueOpt trace "marker"
            Line |> DynObj.setValueOpt trace "line"
            TextFont |> DynObj.setValueOpt trace "textfont"
            SelectedPoints |> DynObj.setValueOpt trace "selectedpoints"
            Selected |> DynObj.setValueOpt trace "selected"
            Unselected |> DynObj.setValueOpt trace "unselected"
            ConnectGaps |> DynObj.setValueOpt trace "connectgaps"
            Fill |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
            FillColor |> DynObj.setValueOpt trace "fillcolor"
            HoverLabel |> DynObj.setValueOpt trace "hoverlabel"
            LocationMode |> DynObj.setValueOptBy trace "locationmode" StyleParam.LocationFormat.convert
            UIRevision |> DynObj.setValueOpt trace "uirevision"

            trace

            )
