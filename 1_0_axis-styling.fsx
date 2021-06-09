(**
// can't yet format YamlFrontmatter (["title: Axis styling"; "category: Chart Layout"; "categoryindex: 2"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Axis styling

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=1_0_axis-styling.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/1_0_axis-styling.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/1_0_axis-styling.ipynb)

*Summary:* This example shows how to style chart axes in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 
  
let x = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
let y' = y |> List.map (fun y -> y * 2.) |> List.rev
(**
## Single axis styling

To style a specific axis of a plot, use the respective `Chart.with*_AxisStyle` function:


*)
let plot1 =
    Chart.Point(x,y)
    |> Chart.withX_AxisStyle ("X axis title", MinMax = (-1.,10.))
    |> Chart.withY_AxisStyle ("Y axis title", MinMax = (-1.,10.))(* output: 
<div id="f60e9b86-f499-442e-b676-ff77410f7c10" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f60e9b86f499442eb676ff77410f7c10 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{}}];
            var layout = {"xaxis":{"title":"X axis title","range":[-1.0,10.0]},"yaxis":{"title":"Y axis title","range":[-1.0,10.0]}};
            var config = {};
            Plotly.newPlot('f60e9b86-f499-442e-b676-ff77410f7c10', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f60e9b86f499442eb676ff77410f7c10();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f60e9b86f499442eb676ff77410f7c10();
            }
</script>
*)
(**
for even more fine-grained control, initialize a new axis and replace the old one of the plot with ````.
The following example creates two mirrored axes with inside ticks, one of them with a log scale:

*)
let mirroredXAxis =
    Axis.LinearAxis.init(
        Title ="Log axis",
        Showline = true,
        Mirror = StyleParam.Mirror.AllTicks,
        Showgrid = false,
        Ticks = StyleParam.TickOptions.Inside
    )

let mirroredLogYAxis = 
    Axis.LinearAxis.init(
        Title ="Log axis",
        AxisType = StyleParam.AxisType.Log,
        Showline = true,
        Mirror = StyleParam.Mirror.AllTicks,
        Showgrid = false,
        Ticks = StyleParam.TickOptions.Inside
    )

let plot2 =
    Chart.Point(x,y)
    |> Chart.withX_Axis mirroredXAxis
    |> Chart.withY_Axis mirroredLogYAxis(* output: 
<div id="e6cef6c2-ac7d-4a63-bf19-3d2c4526b5a2" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_e6cef6c2ac7d4a63bf193d2c4526b5a2 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"markers","marker":{}}];
            var layout = {"xaxis":{"title":"Log axis","ticks":"inside","mirror":"allticks","showline":true,"showgrid":false},"yaxis":{"type":"log","title":"Log axis","ticks":"inside","mirror":"allticks","showline":true,"showgrid":false}};
            var config = {};
            Plotly.newPlot('e6cef6c2-ac7d-4a63-bf19-3d2c4526b5a2', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_e6cef6c2ac7d4a63bf193d2c4526b5a2();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_e6cef6c2ac7d4a63bf193d2c4526b5a2();
            }
</script>
*)
(**
## Multiple axes

Assign different axis anchors to subplots to map them to different axes.

### Multiple axes on different sides of the chart

The following example first creates a multichart containing two plots with different axis anchors.
Subsequently, multiple axes with the respective anchors are added to the plot. 
Note that the same can be done as above, defining axes beforehand.


*)
let anchoredAt1 =
    Chart.Line (x,y,Name="anchor 1")
        |> Chart.withAxisAnchor(Y=1)

let anchoredAt2 =
     Chart.Line (x,y',Name="anchor 2")
        |> Chart.withAxisAnchor(Y=2)

let twoXAxes1 = 
    [
       anchoredAt1
       anchoredAt2
    ]
    |> Chart.Combine
    |> Chart.withY_AxisStyle(
        "axis 1",
        Side=StyleParam.Side.Left,
        Id=1
    )
    |> Chart.withY_AxisStyle(
        "axis2",
        Side=StyleParam.Side.Right,
        Id=2,
        Overlaying=StyleParam.AxisAnchorId.Y 1
    )
        (* output: 
<div id="a1cffcec-11ad-4465-b670-05967f4754a1" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_a1cffcec11ad4465b67005967f4754a1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"name":"anchor 1","marker":{},"yaxis":"y"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,7.0,3.0,5.0,5.0,6.0,3.0,10.0,3.0,4.0],"mode":"lines","line":{},"name":"anchor 2","marker":{},"yaxis":"y2"}];
            var layout = {"yaxis":{"title":"axis 1","side":"left"},"yaxis2":{"title":"axis2","side":"right","overlaying":"y"}};
            var config = {};
            Plotly.newPlot('a1cffcec-11ad-4465-b670-05967f4754a1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_a1cffcec11ad4465b67005967f4754a1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_a1cffcec11ad4465b67005967f4754a1();
            }
</script>
*)
(**
### Multiple axes on the same side of the chart

Analogous to above, but move the whole plot to the right by adjusting its domain, and then add a second axis to the left:


*)
let twoXAxes2 =
    [
        anchoredAt1
        anchoredAt2
    ]
    |> Chart.Combine
    |> Chart.withY_AxisStyle(
            "first y-axis",
            Showline=true
            )
    |> Chart.withX_AxisStyle(
        "x-axis",
        Domain=(0.3, 1.0) // moves the first axis and the whole plot to the right
    ) 
    |> Chart.withY_AxisStyle(
        "second y-axis",
        Side=StyleParam.Side.Left,
        Id=2,
        Overlaying=StyleParam.AxisAnchorId.Y 1,
        Position=0.10, // position the axis beteen the leftmost edge and the firt axis at 0.3
        Anchor=StyleParam.AxisAnchorId.Free,
        Showline=true
    )(* output: 
<div id="553ac1f3-f1f1-493f-884a-8a1c1e416363" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_553ac1f3f1f1493f884a8a1c1e416363 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines","line":{},"name":"anchor 1","marker":{},"yaxis":"y"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,7.0,3.0,5.0,5.0,6.0,3.0,10.0,3.0,4.0],"mode":"lines","line":{},"name":"anchor 2","marker":{},"yaxis":"y2"}];
            var layout = {"yaxis":{"title":"first y-axis","side":"left","showline":true},"yaxis2":{"title":"second y-axis","side":"left","overlaying":"y","showline":true,"anchor":"free","position":0.1},"xaxis":{"title":"x-axis","domain":[0.3,1.0]}};
            var config = {};
            Plotly.newPlot('553ac1f3-f1f1-493f-884a-8a1c1e416363', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_553ac1f3f1f1493f884a8a1c1e416363();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_553ac1f3f1f1493f884a8a1c1e416363();
            }
</script>
*)

