(**
// can't yet format YamlFrontmatter (["title: Range plots"; "category: Simple Charts"; "categoryindex: 3"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Range plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_3_range-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/2_3_range-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/2_3_range-plots.ipynb)

*Summary:* This example shows how to create Range plot charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 

let rnd = System.Random()

let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let yUpper = y |> List.map (fun v -> v + rnd.NextDouble())
let yLower = y |> List.map (fun v -> v - rnd.NextDouble())
(**
A range plot is commonly used to indicate some property of data that lies in a certain range around a central value,
for example the range of all predictions from different models, scattering around a central tendency.

*)
let range1 =
    Chart.Range(
        x,y,yUpper,yLower,
        StyleParam.Mode.Lines_Markers,
        Color="grey",
        RangeColor="lightblue")(* output: 
<div id="90f201c0-60ea-463c-9513-46b70dea6364" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_90f201c060ea463c951346b70dea6364 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[1.2483151751795387,1.4542874633121712,4.7934899254671715,0.9089387359139224,2.9447319572534094,2.12421171209971,1.9230412246766693,0.5617524870027567,3.04882854202242,0.6577825013817207],"mode":"lines","fillcolor":"lightblue","name":"lower","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.2513753116370063,1.8702466927330228,5.982838340095634,2.2817503850822107,3.962346031778653,2.9497062128268676,3.2840405110195467,2.13469098491347,4.011263143509283,1.5442921293640008],"mode":"lines","fill":"tonexty","fillcolor":"lightblue","name":"upper","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"mode":"lines+markers","fillcolor":"grey","line":{"color":"grey"},"marker":{"color":"grey"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('90f201c0-60ea-463c-9513-46b70dea6364', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_90f201c060ea463c951346b70dea6364();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_90f201c060ea463c951346b70dea6364();
            }
</script>
*)

