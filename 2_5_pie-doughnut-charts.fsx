(**
// can't yet format YamlFrontmatter (["title: Pie and doughnut Charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 6"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Pie and doughnut Charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_5_pie-doughnut-charts.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/2_5_pie-doughnut-charts.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/2_5_pie-doughnut-charts.ipynb)

*Summary:* This example shows how to create pie and doughnut charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
  
let values = [19; 26; 55;]
let labels = ["Residential"; "Non-Residential"; "Utility"]
(**
A pie, doughnut, or sunburst chart can be created using the `Chart.Pie`, `Chart.Doughnut`, and `Chart.Sunburst` functions.
When creating pie charts, it is usually desirable to provide both labels and values.


*)
let pie1 =
    Chart.Pie(values,labels)(* output: 
<div id="2960f085-6a6e-45f8-a5d9-2ee5faa6f78b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_2960f0856a6e45f8a5d92ee5faa6f78b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"marker":{},"text":["Residential","Non-Residential","Utility"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('2960f085-6a6e-45f8-a5d9-2ee5faa6f78b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_2960f0856a6e45f8a5d92ee5faa6f78b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_2960f0856a6e45f8a5d92ee5faa6f78b();
            }
</script>
*)
let doughnut1 =
    Chart.Doughnut(
        values,
        labels,
        Hole=0.3,
        Textinfo=labels
    )(* output: 
<div id="acd039ab-b669-4c25-8f02-1db063d5838f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_acd039abb6694c258f021db063d5838f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"textinfo":["Residential","Non-Residential","Utility"],"hole":0.3,"marker":{},"text":["Residential","Non-Residential","Utility"]}];
            var layout = {};
            var config = {};
            Plotly.newPlot('acd039ab-b669-4c25-8f02-1db063d5838f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_acd039abb6694c258f021db063d5838f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_acd039abb6694c258f021db063d5838f();
            }
</script>
*)
let sunburst1 =
    Chart.Sunburst(
        ["A";"B";"C";"D";"E"],
        ["";"";"B";"B";""],
        Values=[5.;0.;3.;2.;3.],
        Text=["At";"Bt";"Ct";"Dt";"Et"]
    )(* output: 
<div id="aef5f738-2884-445c-b6b6-ed1a83e04823" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_aef5f7382884445cb6b6ed1a83e04823 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"sunburst","labels":["A","B","C","D","E"],"parents":["","","B","B",""],"values":[5.0,0.0,3.0,2.0,3.0],"text":["At","Bt","Ct","Dt","Et"],"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('aef5f738-2884-445c-b6b6-ed1a83e04823', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_aef5f7382884445cb6b6ed1a83e04823();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_aef5f7382884445cb6b6ed1a83e04823();
            }
</script>
*)

